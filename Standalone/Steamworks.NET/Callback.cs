using System;
using System.Runtime.InteropServices;

namespace Steamworks.Steamworks.NET
{
    public sealed class Callback<T> {
        private CCallbackBaseVTable _vTable;
        private IntPtr _pVTable = IntPtr.Zero;
        private CallbackBase _callbackBase;
        private GCHandle _pCCallbackBase;

        public delegate void DispatchDelegate(T param);
        private event DispatchDelegate Func;

        private readonly bool _gameServer;
        private readonly int _size = Marshal.SizeOf(typeof(T));

        /// <summary>
        /// Creates a new Callback. You must be calling SteamAPI.RunCallbacks() to retrieve the callbacks.
        /// <para>Returns a handle to the Callback. This must be assigned to a member variable to prevent the GC from cleaning it up.</para>
        /// </summary>
        public static Callback<T> Create(DispatchDelegate func) => new Callback<T>(func);

        /// <summary>
        /// Creates a new GameServer Callback. You must be calling GameServer.RunCallbacks() to retrieve the callbacks.
        /// <para>Returns a handle to the Callback. This must be assigned to a member variable to prevent the GC from cleaning it up.</para>
        /// </summary>
        public static Callback<T> CreateGameServer(DispatchDelegate func) => new Callback<T>(func, true);

        public Callback(DispatchDelegate func, bool bGameServer = false) {
            _gameServer = bGameServer;
            BuildCCallbackBase();
            Register(func);
        }

        ~Callback() {
            Unregister();

            if (_pVTable != IntPtr.Zero) {
                Marshal.FreeHGlobal(_pVTable);
            }

            if (_pCCallbackBase.IsAllocated) {
                _pCCallbackBase.Free();
            }
        }

        // Manual registration of the callback
        public void Register(DispatchDelegate func) {
            if (func == null) {
                throw new Exception("Callback function must not be null.");
            }

            if ((_callbackBase.CallbackFlags & CallbackBase.ECallbackFlagsRegistered) == CallbackBase.ECallbackFlagsRegistered) {
                Unregister();
            }

            if (_gameServer) {
                SetGameserverFlag();
            }

            Func = func;

            // ECallbackFlagsRegistered is set by SteamAPI_RegisterCallback.
            NativeMethods.SteamAPI_RegisterCallback(_pCCallbackBase.AddrOfPinnedObject(), CallbackIdentities.GetCallbackIdentity(typeof(T)));
        }

        public void Unregister() => NativeMethods.SteamAPI_UnregisterCallback(_pCCallbackBase.AddrOfPinnedObject());

        public void SetGameserverFlag() { _callbackBase.CallbackFlags |= CallbackBase.ECallbackFlagsGameServer; }

        private void OnRunCallback(
#if !STDCALL
            IntPtr thisptr,
#endif
            IntPtr pvParam) {
            try {
                Func((T)Marshal.PtrToStructure(pvParam, typeof(T)));
            }
            catch (Exception e) {
                CallbackDispatcher.ExceptionHandler(e);
            }
            }

        // Shouldn't get ever get called here, but this is what C++ Steamworks does!
        private void OnRunCallResult(
#if !STDCALL
            IntPtr thisptr,
#endif
            IntPtr pvParam, bool bFailed, ulong hSteamApiCall) {
            try { 
                Func((T)Marshal.PtrToStructure(pvParam, typeof(T)));
            }
            catch (Exception e) {
                CallbackDispatcher.ExceptionHandler(e);
            }
            }

        private int OnGetCallbackSizeBytes(
#if !STDCALL
            IntPtr thisptr
#endif
            ) {
            return _size;
            }

        // Steamworks.NET Specific
        private void BuildCCallbackBase() {
            _vTable = new CCallbackBaseVTable
            {
                RunCallResult = OnRunCallResult,
                RunCallback = OnRunCallback,
                GetCallbackSizeBytes = OnGetCallbackSizeBytes
            };
            _pVTable = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(CCallbackBaseVTable)));
            Marshal.StructureToPtr(_vTable, _pVTable, false);

            _callbackBase = new CallbackBase
            {
                VFPtr = _pVTable,
                CallbackFlags = 0,
                Callback = CallbackIdentities.GetCallbackIdentity(typeof(T))
            };
            _pCCallbackBase = GCHandle.Alloc(_callbackBase, GCHandleType.Pinned);
        }
    }
}
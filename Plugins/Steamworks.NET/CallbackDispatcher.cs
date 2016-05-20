// This file is provided under The MIT License as part of Steamworks.NET.
// Copyright (c) 2013-2015 Riley Labrecque
// Please see the included LICENSE.txt for additional information.

// Changes to this file will be reverted when you update Steamworks.NET


#if UNITY_3_5 || UNITY_4_0 || UNITY_4_1 || UNITY_4_2 || UNITY_4_3 || UNITY_4_5
	#error Unsupported Unity platform. Steamworks.NET requires Unity 4.6 or higher.
#elif UNITY_4_6 || UNITY_5
	#if UNITY_EDITOR_WIN || (UNITY_STANDALONE_WIN && !UNITY_EDITOR)
		#define WINDOWS_BUILD
	#endif
#elif STEAMWORKS_WIN
	#define WINDOWS_BUILD
#elif STEAMWORKS_LIN_OSX
	// So that we don't trigger the else.
#else
	#error You need to define STEAMWORKS_WIN, or STEAMWORKS_LIN_OSX. Refer to the readme for more details.
#endif

// Unity 32bit Mono on Windows crashes with ThisCall/Cdecl for some reason, StdCall without the 'this' ptr is the only thing that works..? 
#if (UNITY_EDITOR_WIN && !UNITY_EDITOR_64) || (!UNITY_EDITOR && UNITY_STANDALONE_WIN && !UNITY_64)
	#define STDCALL
#elif STEAMWORKS_WIN
	#define THISCALL
#endif

// Calling Conventions:
// Unity x86 Windows        - StdCall (No this pointer)
// Unity x86 Linux          - Cdecl
// Unity x86 OSX            - Cdecl
// Unity x64 Windows        - Cdecl
// Unity x64 Linux          - Cdecl
// Unity x64 OSX            - Cdecl
// Microsoft x86 Windows    - ThisCall
// Microsoft x64 Windows    - ThisCall
// Mono x86 Linux           - Cdecl
// Mono x86 OSX             - Cdecl
// Mono x64 Linux           - Cdecl
// Mono x64 OSX             - Cdecl
// Mono on Windows is probably not supported.

using System;
using System.Runtime.InteropServices;

namespace Steamworks {
	public static class CallbackDispatcher {
		// We catch exceptions inside callbacks and reroute them here.
		// For some reason throwing an exception causes RunCallbacks() to break otherwise.
		// If you have a custom ExceptionHandler in your engine you can register it here manually until we get something more elegant hooked up.
		public static void ExceptionHandler(Exception e) {
#if UNITY_BUILD
			UnityEngine.Debug.LogException(e);
#else
			Console.WriteLine(e.Message);
#endif
		}
	}

	public sealed class Callback<T> {
		private CCallbackBaseVTable VTable;
		private IntPtr _pVTable = IntPtr.Zero;
		private CCallbackBase _CCallbackBase;
		private GCHandle _pCCallbackBase;

		public delegate void DispatchDelegate(T param);
		private event DispatchDelegate _Func;

		private readonly bool _bGameServer;
		private readonly int _size = Marshal.SizeOf(typeof(T));

		/// <summary>
		/// Creates a new Callback. You must be calling SteamAPI.RunCallbacks() to retrieve the callbacks.
		/// <para>Returns a handle to the Callback. This must be assigned to a member variable to prevent the GC from cleaning it up.</para>
		/// </summary>
		public static Callback<T> Create(DispatchDelegate func) => new Callback<T>(func, bGameServer: false);

	    /// <summary>
		/// Creates a new GameServer Callback. You must be calling GameServer.RunCallbacks() to retrieve the callbacks.
		/// <para>Returns a handle to the Callback. This must be assigned to a member variable to prevent the GC from cleaning it up.</para>
		/// </summary>
		public static Callback<T> CreateGameServer(DispatchDelegate func) => new Callback<T>(func, bGameServer: true);

	    public Callback(DispatchDelegate func, bool bGameServer = false) {
			_bGameServer = bGameServer;
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

			if ((_CCallbackBase._nCallbackFlags & CCallbackBase.k_ECallbackFlagsRegistered) == CCallbackBase.k_ECallbackFlagsRegistered) {
				Unregister();
			}

			if (_bGameServer) {
				SetGameserverFlag();
			}

			_Func = func;

			// k_ECallbackFlagsRegistered is set by SteamAPI_RegisterCallback.
			NativeMethods.SteamAPI_RegisterCallback(_pCCallbackBase.AddrOfPinnedObject(), CallbackIdentities.GetCallbackIdentity(typeof(T)));
		}

		public void Unregister() => NativeMethods.SteamAPI_UnregisterCallback(_pCCallbackBase.AddrOfPinnedObject());

	    public void SetGameserverFlag() { _CCallbackBase._nCallbackFlags |= CCallbackBase.k_ECallbackFlagsGameServer; }

		private void OnRunCallback(
#if !STDCALL
			IntPtr thisptr,
#endif
			IntPtr pvParam) {
			try {
				_Func((T)Marshal.PtrToStructure(pvParam, typeof(T)));
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
			IntPtr pvParam, bool bFailed, ulong hSteamAPICall) {
			try { 
				_Func((T)Marshal.PtrToStructure(pvParam, typeof(T)));
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
			VTable = new CCallbackBaseVTable
			{
				_RunCallResult = OnRunCallResult,
				_RunCallback = OnRunCallback,
				_GetCallbackSizeBytes = OnGetCallbackSizeBytes
			};
			_pVTable = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(CCallbackBaseVTable)));
			Marshal.StructureToPtr(VTable, _pVTable, false);

			_CCallbackBase = new CCallbackBase
			{
				_vfptr = _pVTable,
				_nCallbackFlags = 0,
				_iCallback = CallbackIdentities.GetCallbackIdentity(typeof(T))
			};
			_pCCallbackBase = GCHandle.Alloc(_CCallbackBase, GCHandleType.Pinned);
		}
	}

	public sealed class CallResult<T> {
		private CCallbackBaseVTable VTable;
		private IntPtr _pVTable = IntPtr.Zero;
		private CCallbackBase _CCallbackBase;
		private GCHandle _pCCallbackBase;

		public delegate void APIDispatchDelegate(T param, bool bIOFailure);
		private event APIDispatchDelegate _Func;

		private SteamAPICall_t _hAPICall = SteamAPICall_t.Invalid;
		public SteamAPICall_t Handle => _hAPICall;

	    private readonly int _size = Marshal.SizeOf(typeof(T));

		/// <summary>
		/// Creates a new async CallResult. You must be calling SteamAPI.RunCallbacks() to retrieve the callback.
		/// <para>Returns a handle to the CallResult. This must be assigned to a member variable to prevent the GC from cleaning it up.</para>
		/// </summary>
		public static CallResult<T> Create(APIDispatchDelegate func = null) => new CallResult<T>(func);

	    public CallResult(APIDispatchDelegate func = null) {
			_Func = func;
			BuildCCallbackBase();
		}

		~CallResult() {
			Cancel();

			if (_pVTable != IntPtr.Zero) {
				Marshal.FreeHGlobal(_pVTable);
			}

			if (_pCCallbackBase.IsAllocated) {
				_pCCallbackBase.Free();
			}
		}

		public void Set(SteamAPICall_t hAPICall, APIDispatchDelegate func = null) {
			// Unlike the official SDK we let the user assign a single function during creation,
			// and allow them to skip having to do so every time that they call .Set()
			if (func != null) {
				_Func = func;
			}

			if (_Func == null) {
				throw new Exception("CallResult function was null, you must either set it in the CallResult Constructor or in Set()");
			}

			if (_hAPICall != SteamAPICall_t.Invalid) {
				NativeMethods.SteamAPI_UnregisterCallResult(_pCCallbackBase.AddrOfPinnedObject(), (ulong)_hAPICall);
			}

			_hAPICall = hAPICall;

			if (hAPICall != SteamAPICall_t.Invalid) {
				NativeMethods.SteamAPI_RegisterCallResult(_pCCallbackBase.AddrOfPinnedObject(), (ulong)hAPICall);
			}
		}

		public bool IsActive() => (_hAPICall != SteamAPICall_t.Invalid);

	    public void Cancel() {
			if (_hAPICall != SteamAPICall_t.Invalid) {
				NativeMethods.SteamAPI_UnregisterCallResult(_pCCallbackBase.AddrOfPinnedObject(), (ulong)_hAPICall);
				_hAPICall = SteamAPICall_t.Invalid;
			}
		}

		public void SetGameserverFlag() { _CCallbackBase._nCallbackFlags |= CCallbackBase.k_ECallbackFlagsGameServer; }

		// Shouldn't get ever get called here, but this is what C++ Steamworks does!
		private void OnRunCallback(
#if !STDCALL
			IntPtr thisptr,
#endif
			IntPtr pvParam) {
			_hAPICall = SteamAPICall_t.Invalid; // Caller unregisters for us
			try {
				_Func((T)Marshal.PtrToStructure(pvParam, typeof(T)), false);
			}
			catch (Exception e) {
				CallbackDispatcher.ExceptionHandler(e);
			}
		}


		private void OnRunCallResult(
#if !STDCALL
			IntPtr thisptr,
#endif
			IntPtr pvParam, bool bFailed, ulong hSteamAPICall) {
			var hAPICall = (SteamAPICall_t)hSteamAPICall;
			if (hAPICall == _hAPICall) {
				try {
					_Func((T)Marshal.PtrToStructure(pvParam, typeof(T)), bFailed);
				}
				catch (Exception e) {
					CallbackDispatcher.ExceptionHandler(e);
				}

				// The official SDK sets _hAPICall to invalid before calling the callresult function,
				// this doesn't let us access .Handle from within the function though.
				if (hAPICall == _hAPICall) { // Ensure that _hAPICall has not been changed in _Func
					_hAPICall = SteamAPICall_t.Invalid; // Caller unregisters for us
				}
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
			VTable = new CCallbackBaseVTable
			{
				_RunCallback = OnRunCallback,
				_RunCallResult = OnRunCallResult,
				_GetCallbackSizeBytes = OnGetCallbackSizeBytes
			};
			_pVTable = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(CCallbackBaseVTable)));
			Marshal.StructureToPtr(VTable, _pVTable, false);

			_CCallbackBase = new CCallbackBase
			{
				_vfptr = _pVTable,
				_nCallbackFlags = 0,
				_iCallback = CallbackIdentities.GetCallbackIdentity(typeof(T))
			};
			_pCCallbackBase = GCHandle.Alloc(_CCallbackBase, GCHandleType.Pinned);
		}
	}

	[StructLayout(LayoutKind.Sequential)]
	internal class CCallbackBase {
		public const byte k_ECallbackFlagsRegistered = 0x01;
		public const byte k_ECallbackFlagsGameServer = 0x02;
		public IntPtr _vfptr;
		public byte _nCallbackFlags;
		public int _iCallback;
	};

	[StructLayout(LayoutKind.Sequential)]
	internal class CCallbackBaseVTable {
#if STDCALL
		private const CallingConvention cc = CallingConvention.StdCall;

		[UnmanagedFunctionPointer(cc)]
		public delegate void RunCBDel(IntPtr pvParam);
		[UnmanagedFunctionPointer(cc)]
		public delegate void RunCRDel(IntPtr pvParam, [MarshalAs(UnmanagedType.I1)] bool bIOFailure, ulong hSteamAPICall);
		[UnmanagedFunctionPointer(cc)]
		public delegate int GetCallbackSizeBytesDel();
#else
	#if THISCALL
		private const CallingConvention cc = CallingConvention.ThisCall;
	#else
		private const CallingConvention cc = CallingConvention.Cdecl;
	#endif

		[UnmanagedFunctionPointer(cc)]
		public delegate void RunCBDel(IntPtr thisptr, IntPtr pvParam);
		[UnmanagedFunctionPointer(cc)]
		public delegate void RunCRDel(IntPtr thisptr, IntPtr pvParam, [MarshalAs(UnmanagedType.I1)] bool bIOFailure, ulong hSteamAPICall);
		[UnmanagedFunctionPointer(cc)]
		public delegate int GetCallbackSizeBytesDel(IntPtr thisptr);
#endif

		// RunCallback and RunCallResult are swapped in MSVC ABI
#if WINDOWS_BUILD
		[NonSerialized]
		[MarshalAs(UnmanagedType.FunctionPtr)]
		public RunCRDel _RunCallResult;
#endif
		[NonSerialized]
		[MarshalAs(UnmanagedType.FunctionPtr)]
		public RunCBDel _RunCallback;
#if !WINDOWS_BUILD
		[NonSerialized]
		[MarshalAs(UnmanagedType.FunctionPtr)]
		public RunCRDel _RunCallResult;
#endif
		[NonSerialized]
		[MarshalAs(UnmanagedType.FunctionPtr)]
		public GetCallbackSizeBytesDel _GetCallbackSizeBytes;
	}
}

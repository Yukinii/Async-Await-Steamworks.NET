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

    public sealed class CallResult<T> {
		private CCallbackBaseVTable _vTable;
		private IntPtr _pVTable = IntPtr.Zero;
		private CallbackBase _callbackBase;
		private GCHandle _pCCallbackBase;

		public delegate void ApiDispatchDelegate(T param, bool bIoFailure);
		private event ApiDispatchDelegate Func;

		private SteamAPICall _hApiCall = SteamAPICall.Invalid;
		public SteamAPICall Handle => _hApiCall;

	    private readonly int _size = Marshal.SizeOf(typeof(T));

		/// <summary>
		/// Creates a new async CallResult. You must be calling SteamAPI.RunCallbacks() to retrieve the callback.
		/// <para>Returns a handle to the CallResult. This must be assigned to a member variable to prevent the GC from cleaning it up.</para>
		/// </summary>
		public static CallResult<T> Create(ApiDispatchDelegate func = null) => new CallResult<T>(func);

	    public CallResult(ApiDispatchDelegate func = null) {
			Func = func;
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

		public void Set(SteamAPICall hApiCall, ApiDispatchDelegate func = null) {
			// Unlike the official SDK we let the user assign a single function during creation,
			// and allow them to skip having to do so every time that they call .Set()
			if (func != null) {
				Func = func;
			}

			if (Func == null) {
				throw new Exception("CallResult function was null, you must either set it in the CallResult Constructor or in Set()");
			}

			if (_hApiCall != SteamAPICall.Invalid) {
				NativeMethods.SteamAPI_UnregisterCallResult(_pCCallbackBase.AddrOfPinnedObject(), (ulong)_hApiCall);
			}

			_hApiCall = hApiCall;

			if (hApiCall != SteamAPICall.Invalid) {
				NativeMethods.SteamAPI_RegisterCallResult(_pCCallbackBase.AddrOfPinnedObject(), (ulong)hApiCall);
			}
		}

		public bool IsActive() => (_hApiCall != SteamAPICall.Invalid);

	    public void Cancel() {
	        if (_hApiCall == SteamAPICall.Invalid) return;
	        NativeMethods.SteamAPI_UnregisterCallResult(_pCCallbackBase.AddrOfPinnedObject(), (ulong)_hApiCall);
	        _hApiCall = SteamAPICall.Invalid;
	    }

		public void SetGameserverFlag() { _callbackBase.CallbackFlags |= CallbackBase.ECallbackFlagsGameServer; }

		// Shouldn't get ever get called here, but this is what C++ Steamworks does!
		private void OnRunCallback(
#if !STDCALL
			IntPtr thisptr,
#endif
			IntPtr pvParam) {
			_hApiCall = SteamAPICall.Invalid; // Caller unregisters for us
			try {
				Func((T)Marshal.PtrToStructure(pvParam, typeof(T)), false);
			}
			catch (Exception e) {
				CallbackDispatcher.ExceptionHandler(e);
			}
		}


		private void OnRunCallResult(
#if !STDCALL
			IntPtr thisptr,
#endif
			IntPtr pvParam, bool bFailed, ulong hSteamApiCall) {
			var hApiCall = (SteamAPICall)hSteamApiCall;
		    if (hApiCall != _hApiCall) return;
		    try {
		        Func((T)Marshal.PtrToStructure(pvParam, typeof(T)), bFailed);
		    }
		    catch (Exception e) {
		        CallbackDispatcher.ExceptionHandler(e);
		    }

		    // The official SDK sets _hAPICall to invalid before calling the callresult function,
		    // this doesn't let us access .Handle from within the function though.
		    if (hApiCall == _hApiCall) { // Ensure that _hAPICall has not been changed in _Func
		        _hApiCall = SteamAPICall.Invalid; // Caller unregisters for us
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
				RunCallback = OnRunCallback,
				RunCallResult = OnRunCallResult,
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

	[StructLayout(LayoutKind.Sequential)]
	internal class CallbackBase {
		public const byte ECallbackFlagsRegistered = 0x01;
		public const byte ECallbackFlagsGameServer = 0x02;
		public IntPtr VFPtr;
		public byte CallbackFlags;
		public int Callback;
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
		private const CallingConvention Cc = CallingConvention.ThisCall;
	#else
		private const CallingConvention cc = CallingConvention.Cdecl;
	#endif

		[UnmanagedFunctionPointer(Cc)]
		public delegate void RunCbDel(IntPtr thisptr, IntPtr pvParam);
		[UnmanagedFunctionPointer(Cc)]
		public delegate void RunCrDel(IntPtr thisptr, IntPtr pvParam, [MarshalAs(UnmanagedType.I1)] bool bIoFailure, ulong hSteamApiCall);
		[UnmanagedFunctionPointer(Cc)]
		public delegate int GetCallbackSizeBytesDel(IntPtr thisptr);
#endif

		// RunCallback and RunCallResult are swapped in MSVC ABI
#if WINDOWS_BUILD
		[NonSerialized]
		[MarshalAs(UnmanagedType.FunctionPtr)]
		public RunCrDel RunCallResult;
#endif
		[NonSerialized]
		[MarshalAs(UnmanagedType.FunctionPtr)]
		public RunCbDel RunCallback;
#if !WINDOWS_BUILD
		[NonSerialized]
		[MarshalAs(UnmanagedType.FunctionPtr)]
		public RunCRDel RunCallResult;
#endif
		[NonSerialized]
		[MarshalAs(UnmanagedType.FunctionPtr)]
		public GetCallbackSizeBytesDel GetCallbackSizeBytes;
	}
}

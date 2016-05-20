// This file is provided under The MIT License as part of Steamworks.NET.
// Copyright (c) 2013-2015 Riley Labrecque
// Please see the included LICENSE.txt for additional information.

// Changes to this file will be reverted when you update Steamworks.NET

// Unity 32bit Mono on Windows crashes with ThisCall for some reason, StdCall without the 'this' ptr is the only thing that works..?
#if (UNITY_EDITOR_WIN && !UNITY_EDITOR_64) || (!UNITY_EDITOR && UNITY_STANDALONE_WIN && !UNITY_64)
	#define NOTHISPTR
#endif

using System;
using System.Runtime.InteropServices;

namespace Steamworks {
	//-----------------------------------------------------------------------------
	// Purpose: Callback interface for receiving responses after a server list refresh
	// or an individual server update.
	//
	// Since you get these callbacks after requesting full list refreshes you will
	// usually implement this interface inside an object like CServerBrowser.  If that
	// object is getting destructed you should use ISteamMatchMakingServers()->CancelQuery()
	// to cancel any in-progress queries so you don't get a callback into the destructed
	// object and crash.
	//-----------------------------------------------------------------------------
	public class SteamMatchmakingServerListResponse {
		// Server has responded ok with updated data
		public delegate void ServerResponded(HServerListRequest hRequest, int iServer);
		// Server has failed to respond
		public delegate void ServerFailedToRespond(HServerListRequest hRequest, int iServer);
		// A list refresh you had initiated is now 100% completed
		public delegate void RefreshComplete(HServerListRequest hRequest, EMatchMakingServerResponse response);

		private readonly VTable _VTable;
		private readonly IntPtr _pVTable;
		private GCHandle _pGCHandle;
		private readonly ServerResponded _ServerResponded;
		private readonly ServerFailedToRespond _ServerFailedToRespond;
		private readonly RefreshComplete _RefreshComplete;

		public SteamMatchmakingServerListResponse(ServerResponded onServerResponded, ServerFailedToRespond onServerFailedToRespond, RefreshComplete onRefreshComplete) {
			if (onServerResponded == null || onServerFailedToRespond == null || onRefreshComplete == null) {
				throw new ArgumentNullException();
			}
			_ServerResponded = onServerResponded;
			_ServerFailedToRespond = onServerFailedToRespond;
			_RefreshComplete = onRefreshComplete;

			_VTable = new VTable
			{
				VTServerResponded = InternalOnServerResponded,
				VTServerFailedToRespond = InternalOnServerFailedToRespond,
				VTRefreshComplete = InternalOnRefreshComplete
			};
			_pVTable = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(VTable)));
			Marshal.StructureToPtr(_VTable, _pVTable, false);

			_pGCHandle = GCHandle.Alloc(_pVTable, GCHandleType.Pinned);
		}

		~SteamMatchmakingServerListResponse() {
			if (_pVTable != IntPtr.Zero) {
				Marshal.FreeHGlobal(_pVTable);
			}

			if (_pGCHandle.IsAllocated) {
				_pGCHandle.Free();
			}
		}
		
#if NOTHISPTR
		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate void InternalServerResponded(HServerListRequest hRequest, int iServer);
		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate void InternalServerFailedToRespond(HServerListRequest hRequest, int iServer);
		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate void InternalRefreshComplete(HServerListRequest hRequest, EMatchMakingServerResponse response);
		private void InternalOnServerResponded(HServerListRequest hRequest, int iServer) {
			_ServerResponded(hRequest, iServer);
		}
		private void InternalOnServerFailedToRespond(HServerListRequest hRequest, int iServer) {
			_ServerFailedToRespond(hRequest, iServer);
		}
		private void InternalOnRefreshComplete(HServerListRequest hRequest, EMatchMakingServerResponse response) {
			_RefreshComplete(hRequest, response);
		}
#else
		[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
		private delegate void InternalServerResponded(IntPtr thisptr, HServerListRequest hRequest, int iServer);
		[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
		private delegate void InternalServerFailedToRespond(IntPtr thisptr, HServerListRequest hRequest, int iServer);
		[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
		private delegate void InternalRefreshComplete(IntPtr thisptr, HServerListRequest hRequest, EMatchMakingServerResponse response);
		private void InternalOnServerResponded(IntPtr thisptr, HServerListRequest hRequest, int iServer) => _ServerResponded(hRequest, iServer);

	    private void InternalOnServerFailedToRespond(IntPtr thisptr, HServerListRequest hRequest, int iServer) => _ServerFailedToRespond(hRequest, iServer);
	    private void InternalOnRefreshComplete(IntPtr thisptr, HServerListRequest hRequest, EMatchMakingServerResponse response) => _RefreshComplete(hRequest, response);
#endif

		[StructLayout(LayoutKind.Sequential)]
		private class VTable {
			[NonSerialized]
			[MarshalAs(UnmanagedType.FunctionPtr)]
			public InternalServerResponded VTServerResponded;

			[NonSerialized]
			[MarshalAs(UnmanagedType.FunctionPtr)]
			public InternalServerFailedToRespond VTServerFailedToRespond;

			[NonSerialized]
			[MarshalAs(UnmanagedType.FunctionPtr)]
			public InternalRefreshComplete VTRefreshComplete;
		}

		public static explicit operator IntPtr(SteamMatchmakingServerListResponse that) => that._pGCHandle.AddrOfPinnedObject();
	};

	//-----------------------------------------------------------------------------
	// Purpose: Callback interface for receiving responses after pinging an individual server 
	//
	// These callbacks all occur in response to querying an individual server
	// via the ISteamMatchmakingServers()->PingServer() call below.  If you are 
	// destructing an object that implements this interface then you should call 
	// ISteamMatchmakingServers()->CancelServerQuery() passing in the handle to the query
	// which is in progress.  Failure to cancel in progress queries when destructing
	// a callback handler may result in a crash when a callback later occurs.
	//-----------------------------------------------------------------------------

    //-----------------------------------------------------------------------------
	// Purpose: Callback interface for receiving responses after requesting details on
	// who is playing on a particular server.
	//
	// These callbacks all occur in response to querying an individual server
	// via the ISteamMatchmakingServers()->PlayerDetails() call below.  If you are 
	// destructing an object that implements this interface then you should call 
	// ISteamMatchmakingServers()->CancelServerQuery() passing in the handle to the query
	// which is in progress.  Failure to cancel in progress queries when destructing
	// a callback handler may result in a crash when a callback later occurs.
	//-----------------------------------------------------------------------------

    //-----------------------------------------------------------------------------
	// Purpose: Callback interface for receiving responses after requesting rules
	// details on a particular server.
	//
	// These callbacks all occur in response to querying an individual server
	// via the ISteamMatchmakingServers()->ServerRules() call below.  If you are 
	// destructing an object that implements this interface then you should call 
	// ISteamMatchmakingServers()->CancelServerQuery() passing in the handle to the query
	// which is in progress.  Failure to cancel in progress queries when destructing
	// a callback handler may result in a crash when a callback later occurs.
	//-----------------------------------------------------------------------------
}

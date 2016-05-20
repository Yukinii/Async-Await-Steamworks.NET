using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
    public class SteamMatchmakingPlayersResponse {
        // Got data on a new player on the server -- you'll get this callback once per player
        // on the server which you have requested player data on.
        public delegate void AddPlayerToList(string name, int nScore, float flTimePlayed);

        // The server failed to respond to the request for player details
        public delegate void PlayersFailedToRespond();

        // The server has finished responding to the player details request 
        // (ie, you won't get anymore AddPlayerToList callbacks)
        public delegate void PlayersRefreshComplete();

        private readonly VTable _VTable;
        private readonly IntPtr _pVTable;
        private GCHandle _pGCHandle;
        private readonly AddPlayerToList _AddPlayerToList;
        private readonly PlayersFailedToRespond _PlayersFailedToRespond;
        private readonly PlayersRefreshComplete _PlayersRefreshComplete;

        public SteamMatchmakingPlayersResponse(AddPlayerToList onAddPlayerToList, PlayersFailedToRespond onPlayersFailedToRespond, PlayersRefreshComplete onPlayersRefreshComplete) {
            if (onAddPlayerToList == null || onPlayersFailedToRespond == null || onPlayersRefreshComplete == null) {
                throw new ArgumentNullException();
            }
            _AddPlayerToList = onAddPlayerToList;
            _PlayersFailedToRespond = onPlayersFailedToRespond;
            _PlayersRefreshComplete = onPlayersRefreshComplete;
			
            _VTable = new VTable
            {
                _VTAddPlayerToList = InternalOnAddPlayerToList,
                _VTPlayersFailedToRespond = InternalOnPlayersFailedToRespond,
                _VTPlayersRefreshComplete = InternalOnPlayersRefreshComplete
            };
            _pVTable = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(VTable)));
            Marshal.StructureToPtr(_VTable, _pVTable, false);

            _pGCHandle = GCHandle.Alloc(_pVTable, GCHandleType.Pinned);
        }

        ~SteamMatchmakingPlayersResponse() {
            if (_pVTable != IntPtr.Zero) {
                Marshal.FreeHGlobal(_pVTable);
            }

            if (_pGCHandle.IsAllocated) {
                _pGCHandle.Free();
            }
        }
		
#if NOTHISPTR
		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		public delegate void InternalAddPlayerToList(IntPtr name, int nScore, float flTimePlayed);
		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		public delegate void InternalPlayersFailedToRespond();
		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		public delegate void InternalPlayersRefreshComplete();
		private void InternalOnAddPlayerToList(IntPtr name, int nScore, float flTimePlayed) {
			_AddPlayerToList(InteropHelp.PtrToStringUTF8(name), nScore, flTimePlayed);
		}
		private void InternalOnPlayersFailedToRespond() {
			_PlayersFailedToRespond();
		}
		private void InternalOnPlayersRefreshComplete() {
			_PlayersRefreshComplete();
		}
#else
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate void InternalAddPlayerToList(IntPtr thisptr, IntPtr name, int nScore, float flTimePlayed);
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate void InternalPlayersFailedToRespond(IntPtr thisptr);
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate void InternalPlayersRefreshComplete(IntPtr thisptr);
        private void InternalOnAddPlayerToList(IntPtr thisptr, IntPtr name, int nScore, float flTimePlayed) => _AddPlayerToList(InteropHelp.PtrToStringUTF8(name), nScore, flTimePlayed);

        private void InternalOnPlayersFailedToRespond(IntPtr thisptr) => _PlayersFailedToRespond();

        private void InternalOnPlayersRefreshComplete(IntPtr thisptr) => _PlayersRefreshComplete();
#endif

        [StructLayout(LayoutKind.Sequential)]
        private class VTable {
            [NonSerialized]
            [MarshalAs(UnmanagedType.FunctionPtr)]
            public InternalAddPlayerToList _VTAddPlayerToList;

            [NonSerialized]
            [MarshalAs(UnmanagedType.FunctionPtr)]
            public InternalPlayersFailedToRespond _VTPlayersFailedToRespond;

            [NonSerialized]
            [MarshalAs(UnmanagedType.FunctionPtr)]
            public InternalPlayersRefreshComplete _VTPlayersRefreshComplete;
        }

        public static explicit operator IntPtr(SteamMatchmakingPlayersResponse that) => that._pGCHandle.AddrOfPinnedObject();
    };
}
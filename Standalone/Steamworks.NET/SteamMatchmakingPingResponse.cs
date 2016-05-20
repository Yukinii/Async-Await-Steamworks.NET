using System;
using System.Runtime.InteropServices;

namespace Steamworks.Steamworks.NET
{
    public class SteamMatchmakingPingResponse {
        // Server has responded successfully and has updated data
        public delegate void ServerResponded(gameserverite server);

        // Server failed to respond to the ping request
        public delegate void ServerFailedToRespond();

        private readonly VTable _VTable;
        private readonly IntPtr _pVTable;
        private GCHandle _pGCHandle;
        private readonly ServerResponded _ServerResponded;
        private readonly ServerFailedToRespond _ServerFailedToRespond;

        public SteamMatchmakingPingResponse(ServerResponded onServerResponded, ServerFailedToRespond onServerFailedToRespond) {
            if (onServerResponded == null || onServerFailedToRespond == null) {
                throw new ArgumentNullException();
            }
            _ServerResponded = onServerResponded;
            _ServerFailedToRespond = onServerFailedToRespond;

            _VTable = new VTable
            {
                VTServerResponded = InternalOnServerResponded,
                VTServerFailedToRespond = InternalOnServerFailedToRespond,
            };
            _pVTable = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(VTable)));
            Marshal.StructureToPtr(_VTable, _pVTable, false);

            _pGCHandle = GCHandle.Alloc(_pVTable, GCHandleType.Pinned);
        }

        ~SteamMatchmakingPingResponse() {
            if (_pVTable != IntPtr.Zero) {
                Marshal.FreeHGlobal(_pVTable);
            }

            if (_pGCHandle.IsAllocated) {
                _pGCHandle.Free();
            }
        }

#if NOTHISPTR
		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate void InternalServerResponded(gameserverite server);
		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate void InternalServerFailedToRespond();
		private void InternalOnServerResponded(gameserverite server) {
			_ServerResponded(server);
		}
		private void InternalOnServerFailedToRespond() {
			_ServerFailedToRespond();
		}
#else
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate void InternalServerResponded(IntPtr thisptr, gameserverite server);
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate void InternalServerFailedToRespond(IntPtr thisptr);
        private void InternalOnServerResponded(IntPtr thisptr, gameserverite server) => _ServerResponded(server);
        private void InternalOnServerFailedToRespond(IntPtr thisptr) => _ServerFailedToRespond();
#endif

        [StructLayout(LayoutKind.Sequential)]
        private class VTable {
            [NonSerialized]
            [MarshalAs(UnmanagedType.FunctionPtr)]
            public InternalServerResponded VTServerResponded;

            [NonSerialized]
            [MarshalAs(UnmanagedType.FunctionPtr)]
            public InternalServerFailedToRespond VTServerFailedToRespond;
        }

        public static explicit operator IntPtr(SteamMatchmakingPingResponse that) => that._pGCHandle.AddrOfPinnedObject();
    };
}
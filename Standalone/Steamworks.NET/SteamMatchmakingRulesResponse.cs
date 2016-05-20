using System;
using System.Runtime.InteropServices;

namespace Steamworks.Steamworks.NET
{
    public class SteamMatchmakingRulesResponse {
        // Got data on a rule on the server -- you'll get one of these per rule defined on
        // the server you are querying
        public delegate void RulesResponded(string pchRule, string pchValue);

        // The server failed to respond to the request for rule details
        public delegate void RulesFailedToRespond();

        // The server has finished responding to the rule details request 
        // (ie, you won't get anymore RulesResponded callbacks)
        public delegate void RulesRefreshComplete();

        private readonly VTable _VTable;
        private readonly IntPtr _pVTable;
        private GCHandle _pGCHandle;
        private readonly RulesResponded _RulesResponded;
        private readonly RulesFailedToRespond _RulesFailedToRespond;
        private readonly RulesRefreshComplete _RulesRefreshComplete;

        public SteamMatchmakingRulesResponse(RulesResponded onRulesResponded, RulesFailedToRespond onRulesFailedToRespond, RulesRefreshComplete onRulesRefreshComplete) {
            if (onRulesResponded == null || onRulesFailedToRespond == null || onRulesRefreshComplete == null) {
                throw new ArgumentNullException();
            }
            _RulesResponded = onRulesResponded;
            _RulesFailedToRespond = onRulesFailedToRespond;
            _RulesRefreshComplete = onRulesRefreshComplete;

            _VTable = new VTable
            {
                _VTRulesResponded = InternalOnRulesResponded,
                _VTRulesFailedToRespond = InternalOnRulesFailedToRespond,
                _VTRulesRefreshComplete = InternalOnRulesRefreshComplete
            };
            _pVTable = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(VTable)));
            Marshal.StructureToPtr(_VTable, _pVTable, false);

            _pGCHandle = GCHandle.Alloc(_pVTable, GCHandleType.Pinned);
        }

        ~SteamMatchmakingRulesResponse() {
            if (_pVTable != IntPtr.Zero) {
                Marshal.FreeHGlobal(_pVTable);
            }

            if (_pGCHandle.IsAllocated) {
                _pGCHandle.Free();
            }
        }
		
#if NOTHISPTR
		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		public delegate void InternalRulesResponded(IntPtr pchRule, IntPtr pchValue);
		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		public delegate void InternalRulesFailedToRespond();
		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		public delegate void InternalRulesRefreshComplete();
		private void InternalOnRulesResponded(IntPtr pchRule, IntPtr pchValue) {
			_RulesResponded(InteropHelp.PtrToStringUTF8(pchRule), InteropHelp.PtrToStringUTF8(pchValue));
		}
		private void InternalOnRulesFailedToRespond() {
			_RulesFailedToRespond();
		}
		private void InternalOnRulesRefreshComplete() {
			_RulesRefreshComplete();
		}
#else
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate void InternalRulesResponded(IntPtr thisptr, IntPtr pchRule, IntPtr pchValue);
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate void InternalRulesFailedToRespond(IntPtr thisptr);
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate void InternalRulesRefreshComplete(IntPtr thisptr);
        private void InternalOnRulesResponded(IntPtr thisptr, IntPtr pchRule, IntPtr pchValue) => _RulesResponded(InteropHelp.PtrToStringUTF8(pchRule), InteropHelp.PtrToStringUTF8(pchValue));
        private void InternalOnRulesFailedToRespond(IntPtr thisptr) => _RulesFailedToRespond();

        private void InternalOnRulesRefreshComplete(IntPtr thisptr) => _RulesRefreshComplete();
#endif

        [StructLayout(LayoutKind.Sequential)]
        private class VTable {
            [NonSerialized]
            [MarshalAs(UnmanagedType.FunctionPtr)]
            public InternalRulesResponded _VTRulesResponded;

            [NonSerialized]
            [MarshalAs(UnmanagedType.FunctionPtr)]
            public InternalRulesFailedToRespond _VTRulesFailedToRespond;

            [NonSerialized]
            [MarshalAs(UnmanagedType.FunctionPtr)]
            public InternalRulesRefreshComplete _VTRulesRefreshComplete;
        }

        public static explicit operator IntPtr(SteamMatchmakingRulesResponse that) => that._pGCHandle.AddrOfPinnedObject();
    };
}
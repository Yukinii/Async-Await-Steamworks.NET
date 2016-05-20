using System;
using System.Runtime.InteropServices;

namespace Steamworks.Steamworks.NET
{
    public class MmkvpMarshaller {
        private readonly IntPtr _pNativeArray;
        private readonly IntPtr _pArrayEntries;

        public MmkvpMarshaller(MatchMakingKeyValuePair[] filters) {
            if (filters == null) {
                return;
            }

            var sizeOfMMKVP = Marshal.SizeOf(typeof(MatchMakingKeyValuePair));

            _pNativeArray = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(IntPtr)) * filters.Length);
            _pArrayEntries = Marshal.AllocHGlobal(sizeOfMMKVP * filters.Length);
            for (var i = 0; i < filters.Length; ++i) {
                Marshal.StructureToPtr(filters[i], new IntPtr(_pArrayEntries.ToInt64() + (i * sizeOfMMKVP)), false);
            }

            Marshal.WriteIntPtr(_pNativeArray, _pArrayEntries);
        }

        ~MmkvpMarshaller() {
            if (_pArrayEntries != IntPtr.Zero) {
                Marshal.FreeHGlobal(_pArrayEntries);
            }
            if (_pNativeArray != IntPtr.Zero) {
                Marshal.FreeHGlobal(_pNativeArray);
            }
        }

        public static implicit operator IntPtr(MmkvpMarshaller that) => that._pNativeArray;
    }
}
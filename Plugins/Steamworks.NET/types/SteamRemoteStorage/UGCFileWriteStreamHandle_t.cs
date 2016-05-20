// This file is provided under The MIT License as part of Steamworks.NET.
// Copyright (c) 2013-2015 Riley Labrecque
// Please see the included LICENSE.txt for additional information.

// Changes to this file will be reverted when you update Steamworks.NET

namespace Steamworks {
	public struct UGCFileWriteStreamHandle : System.IEquatable<UGCFileWriteStreamHandle>, System.IComparable<UGCFileWriteStreamHandle> {
		public static readonly UGCFileWriteStreamHandle Invalid = new UGCFileWriteStreamHandle(0xffffffffffffffff);
		public ulong _UGCFileWriteStreamHandle;

		public UGCFileWriteStreamHandle(ulong value) {
			_UGCFileWriteStreamHandle = value;
		}

		public override string ToString() => _UGCFileWriteStreamHandle.ToString();

	    public override bool Equals(object other) => other is UGCFileWriteStreamHandle && this == (UGCFileWriteStreamHandle)other;

	    public override int GetHashCode() => _UGCFileWriteStreamHandle.GetHashCode();

	    public static bool operator ==(UGCFileWriteStreamHandle x, UGCFileWriteStreamHandle y) => x._UGCFileWriteStreamHandle == y._UGCFileWriteStreamHandle;

	    public static bool operator !=(UGCFileWriteStreamHandle x, UGCFileWriteStreamHandle y) => !(x == y);

	    public static explicit operator UGCFileWriteStreamHandle(ulong value) => new UGCFileWriteStreamHandle(value);

	    public static explicit operator ulong(UGCFileWriteStreamHandle that) => that._UGCFileWriteStreamHandle;

	    public bool Equals(UGCFileWriteStreamHandle other) => _UGCFileWriteStreamHandle == other._UGCFileWriteStreamHandle;

	    public int CompareTo(UGCFileWriteStreamHandle other) => _UGCFileWriteStreamHandle.CompareTo(other._UGCFileWriteStreamHandle);
	}
}

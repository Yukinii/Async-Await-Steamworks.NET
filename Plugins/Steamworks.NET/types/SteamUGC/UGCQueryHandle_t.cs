// This file is provided under The MIT License as part of Steamworks.NET.
// Copyright (c) 2013-2015 Riley Labrecque
// Please see the included LICENSE.txt for additional information.

// Changes to this file will be reverted when you update Steamworks.NET

namespace Steamworks {
	public struct UGCQueryHandle : System.IEquatable<UGCQueryHandle>, System.IComparable<UGCQueryHandle> {
		public static readonly UGCQueryHandle Invalid = new UGCQueryHandle(0xffffffffffffffff);
		public readonly ulong _UGCQueryHandle;

		public UGCQueryHandle(ulong value) {
			_UGCQueryHandle = value;
		}

		public override string ToString() => _UGCQueryHandle.ToString();

	    public override bool Equals(object other) => other is UGCQueryHandle && this == (UGCQueryHandle)other;

	    public override int GetHashCode() => _UGCQueryHandle.GetHashCode();

	    public static bool operator ==(UGCQueryHandle x, UGCQueryHandle y) => x._UGCQueryHandle == y._UGCQueryHandle;

	    public static bool operator !=(UGCQueryHandle x, UGCQueryHandle y) => !(x == y);

	    public static explicit operator UGCQueryHandle(ulong value) => new UGCQueryHandle(value);

	    public static explicit operator ulong(UGCQueryHandle that) => that._UGCQueryHandle;

	    public bool Equals(UGCQueryHandle other) => _UGCQueryHandle == other._UGCQueryHandle;

	    public int CompareTo(UGCQueryHandle other) => _UGCQueryHandle.CompareTo(other._UGCQueryHandle);
	}
}

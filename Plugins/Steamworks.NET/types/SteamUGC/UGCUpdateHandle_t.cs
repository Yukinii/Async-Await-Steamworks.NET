// This file is provided under The MIT License as part of Steamworks.NET.
// Copyright (c) 2013-2015 Riley Labrecque
// Please see the included LICENSE.txt for additional information.

// Changes to this file will be reverted when you update Steamworks.NET

namespace Steamworks {
	public struct UGCUpdateHandle : System.IEquatable<UGCUpdateHandle>, System.IComparable<UGCUpdateHandle> {
		public static readonly UGCUpdateHandle Invalid = new UGCUpdateHandle(0xffffffffffffffff);
		public ulong _UGCUpdateHandle;

		public UGCUpdateHandle(ulong value) {
			_UGCUpdateHandle = value;
		}

		public override string ToString() => _UGCUpdateHandle.ToString();

	    public override bool Equals(object other) => other is UGCUpdateHandle && this == (UGCUpdateHandle)other;

	    public override int GetHashCode() => _UGCUpdateHandle.GetHashCode();

	    public static bool operator ==(UGCUpdateHandle x, UGCUpdateHandle y) => x._UGCUpdateHandle == y._UGCUpdateHandle;

	    public static bool operator !=(UGCUpdateHandle x, UGCUpdateHandle y) => !(x == y);

	    public static explicit operator UGCUpdateHandle(ulong value) => new UGCUpdateHandle(value);

	    public static explicit operator ulong(UGCUpdateHandle that) => that._UGCUpdateHandle;

	    public bool Equals(UGCUpdateHandle other) => _UGCUpdateHandle == other._UGCUpdateHandle;

	    public int CompareTo(UGCUpdateHandle other) => _UGCUpdateHandle.CompareTo(other._UGCUpdateHandle);
	}
}

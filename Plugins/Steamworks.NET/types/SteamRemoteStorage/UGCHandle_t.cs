// This file is provided under The MIT License as part of Steamworks.NET.
// Copyright (c) 2013-2015 Riley Labrecque
// Please see the included LICENSE.txt for additional information.

// Changes to this file will be reverted when you update Steamworks.NET

namespace Steamworks {
	public struct UGCHandle : System.IEquatable<UGCHandle>, System.IComparable<UGCHandle> {
		public static readonly UGCHandle Invalid = new UGCHandle(0xffffffffffffffff);
	    public readonly ulong Handle;

		public UGCHandle(ulong value) {
			Handle = value;
		}

		public override string ToString() => Handle.ToString();

	    public override bool Equals(object other) => other is UGCHandle && this == (UGCHandle)other;

	    public override int GetHashCode() => Handle.GetHashCode();

	    public static bool operator ==(UGCHandle x, UGCHandle y) => x.Handle == y.Handle;

	    public static bool operator !=(UGCHandle x, UGCHandle y) => !(x == y);

	    public static explicit operator UGCHandle(ulong value) => new UGCHandle(value);

	    public static explicit operator ulong(UGCHandle that) => that.Handle;

	    public bool Equals(UGCHandle other) => Handle == other.Handle;

	    public int CompareTo(UGCHandle other) => Handle.CompareTo(other.Handle);
	}
}

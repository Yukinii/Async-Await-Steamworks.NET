// This file is provided under The MIT License as part of Steamworks.NET.
// Copyright (c) 2013-2015 Riley Labrecque
// Please see the included LICENSE.txt for additional information.

// Changes to this file will be reverted when you update Steamworks.NET

namespace Steamworks {
	public struct UGCFileWriteStreamHandle : System.IEquatable<UGCFileWriteStreamHandle>, System.IComparable<UGCFileWriteStreamHandle> {
		public static readonly UGCFileWriteStreamHandle Invalid = new UGCFileWriteStreamHandle(0xffffffffffffffff);
	    public readonly ulong StreamHandle;

		public UGCFileWriteStreamHandle(ulong value) {
			StreamHandle = value;
		}

		public override string ToString() => StreamHandle.ToString();

	    public override bool Equals(object other) => other is UGCFileWriteStreamHandle && this == (UGCFileWriteStreamHandle)other;

	    public override int GetHashCode() => StreamHandle.GetHashCode();

	    public static bool operator ==(UGCFileWriteStreamHandle x, UGCFileWriteStreamHandle y) => x.StreamHandle == y.StreamHandle;

	    public static bool operator !=(UGCFileWriteStreamHandle x, UGCFileWriteStreamHandle y) => !(x == y);

	    public static explicit operator UGCFileWriteStreamHandle(ulong value) => new UGCFileWriteStreamHandle(value);

	    public static explicit operator ulong(UGCFileWriteStreamHandle that) => that.StreamHandle;

	    public bool Equals(UGCFileWriteStreamHandle other) => StreamHandle == other.StreamHandle;

	    public int CompareTo(UGCFileWriteStreamHandle other) => StreamHandle.CompareTo(other.StreamHandle);
	}
}

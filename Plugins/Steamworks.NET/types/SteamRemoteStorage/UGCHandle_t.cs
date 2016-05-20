// This file is provided under The MIT License as part of Steamworks.NET.
// Copyright (c) 2013-2015 Riley Labrecque
// Please see the included LICENSE.txt for additional information.

// Changes to this file will be reverted when you update Steamworks.NET

namespace Steamworks {
	public struct UGCHandle_t : System.IEquatable<UGCHandle_t>, System.IComparable<UGCHandle_t> {
		public static readonly UGCHandle_t Invalid = new UGCHandle_t(0xffffffffffffffff);
		public ulong _UGCHandle;

		public UGCHandle_t(ulong value) {
			_UGCHandle = value;
		}

		public override string ToString() => _UGCHandle.ToString();

	    public override bool Equals(object other) => other is UGCHandle_t && this == (UGCHandle_t)other;

	    public override int GetHashCode() => _UGCHandle.GetHashCode();

	    public static bool operator ==(UGCHandle_t x, UGCHandle_t y) => x._UGCHandle == y._UGCHandle;

	    public static bool operator !=(UGCHandle_t x, UGCHandle_t y) => !(x == y);

	    public static explicit operator UGCHandle_t(ulong value) => new UGCHandle_t(value);

	    public static explicit operator ulong(UGCHandle_t that) => that._UGCHandle;

	    public bool Equals(UGCHandle_t other) => _UGCHandle == other._UGCHandle;

	    public int CompareTo(UGCHandle_t other) => _UGCHandle.CompareTo(other._UGCHandle);
	}
}

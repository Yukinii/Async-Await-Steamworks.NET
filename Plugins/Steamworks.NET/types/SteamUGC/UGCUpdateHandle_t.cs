// This file is provided under The MIT License as part of Steamworks.NET.
// Copyright (c) 2013-2015 Riley Labrecque
// Please see the included LICENSE.txt for additional information.

// Changes to this file will be reverted when you update Steamworks.NET

namespace Steamworks {
	public struct UGCUpdateHandle_t : System.IEquatable<UGCUpdateHandle_t>, System.IComparable<UGCUpdateHandle_t> {
		public static readonly UGCUpdateHandle_t Invalid = new UGCUpdateHandle_t(0xffffffffffffffff);
		public ulong _UGCUpdateHandle;

		public UGCUpdateHandle_t(ulong value) {
			_UGCUpdateHandle = value;
		}

		public override string ToString() => _UGCUpdateHandle.ToString();

	    public override bool Equals(object other) => other is UGCUpdateHandle_t && this == (UGCUpdateHandle_t)other;

	    public override int GetHashCode() => _UGCUpdateHandle.GetHashCode();

	    public static bool operator ==(UGCUpdateHandle_t x, UGCUpdateHandle_t y) => x._UGCUpdateHandle == y._UGCUpdateHandle;

	    public static bool operator !=(UGCUpdateHandle_t x, UGCUpdateHandle_t y) => !(x == y);

	    public static explicit operator UGCUpdateHandle_t(ulong value) => new UGCUpdateHandle_t(value);

	    public static explicit operator ulong(UGCUpdateHandle_t that) => that._UGCUpdateHandle;

	    public bool Equals(UGCUpdateHandle_t other) => _UGCUpdateHandle == other._UGCUpdateHandle;

	    public int CompareTo(UGCUpdateHandle_t other) => _UGCUpdateHandle.CompareTo(other._UGCUpdateHandle);
	}
}

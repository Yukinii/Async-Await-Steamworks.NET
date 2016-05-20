// This file is provided under The MIT License as part of Steamworks.NET.
// Copyright (c) 2013-2015 Riley Labrecque
// Please see the included LICENSE.txt for additional information.

// Changes to this file will be reverted when you update Steamworks.NET

namespace Steamworks {
	public struct UGCQueryHandle_t : System.IEquatable<UGCQueryHandle_t>, System.IComparable<UGCQueryHandle_t> {
		public static readonly UGCQueryHandle_t Invalid = new UGCQueryHandle_t(0xffffffffffffffff);
		public ulong _UGCQueryHandle;

		public UGCQueryHandle_t(ulong value) {
			_UGCQueryHandle = value;
		}

		public override string ToString() => _UGCQueryHandle.ToString();

	    public override bool Equals(object other) => other is UGCQueryHandle_t && this == (UGCQueryHandle_t)other;

	    public override int GetHashCode() => _UGCQueryHandle.GetHashCode();

	    public static bool operator ==(UGCQueryHandle_t x, UGCQueryHandle_t y) => x._UGCQueryHandle == y._UGCQueryHandle;

	    public static bool operator !=(UGCQueryHandle_t x, UGCQueryHandle_t y) => !(x == y);

	    public static explicit operator UGCQueryHandle_t(ulong value) => new UGCQueryHandle_t(value);

	    public static explicit operator ulong(UGCQueryHandle_t that) => that._UGCQueryHandle;

	    public bool Equals(UGCQueryHandle_t other) => _UGCQueryHandle == other._UGCQueryHandle;

	    public int CompareTo(UGCQueryHandle_t other) => _UGCQueryHandle.CompareTo(other._UGCQueryHandle);
	}
}

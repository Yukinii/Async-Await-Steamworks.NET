// This file is provided under The MIT License as part of Steamworks.NET.
// Copyright (c) 2013-2015 Riley Labrecque
// Please see the included LICENSE.txt for additional information.

// Changes to this file will be reverted when you update Steamworks.NET

namespace Steamworks {
	public struct UGCFileWriteStreamHandle_t : System.IEquatable<UGCFileWriteStreamHandle_t>, System.IComparable<UGCFileWriteStreamHandle_t> {
		public static readonly UGCFileWriteStreamHandle_t Invalid = new UGCFileWriteStreamHandle_t(0xffffffffffffffff);
		public ulong _UGCFileWriteStreamHandle;

		public UGCFileWriteStreamHandle_t(ulong value) {
			_UGCFileWriteStreamHandle = value;
		}

		public override string ToString() => _UGCFileWriteStreamHandle.ToString();

	    public override bool Equals(object other) => other is UGCFileWriteStreamHandle_t && this == (UGCFileWriteStreamHandle_t)other;

	    public override int GetHashCode() => _UGCFileWriteStreamHandle.GetHashCode();

	    public static bool operator ==(UGCFileWriteStreamHandle_t x, UGCFileWriteStreamHandle_t y) => x._UGCFileWriteStreamHandle == y._UGCFileWriteStreamHandle;

	    public static bool operator !=(UGCFileWriteStreamHandle_t x, UGCFileWriteStreamHandle_t y) => !(x == y);

	    public static explicit operator UGCFileWriteStreamHandle_t(ulong value) => new UGCFileWriteStreamHandle_t(value);

	    public static explicit operator ulong(UGCFileWriteStreamHandle_t that) => that._UGCFileWriteStreamHandle;

	    public bool Equals(UGCFileWriteStreamHandle_t other) => _UGCFileWriteStreamHandle == other._UGCFileWriteStreamHandle;

	    public int CompareTo(UGCFileWriteStreamHandle_t other) => _UGCFileWriteStreamHandle.CompareTo(other._UGCFileWriteStreamHandle);
	}
}

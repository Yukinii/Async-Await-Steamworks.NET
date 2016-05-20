// This file is provided under The MIT License as part of Steamworks.NET.
// Copyright (c) 2013-2015 Riley Labrecque
// Please see the included LICENSE.txt for additional information.

// Changes to this file will be reverted when you update Steamworks.NET

namespace Steamworks {
	public struct DepotId_t : System.IEquatable<DepotId_t>, System.IComparable<DepotId_t> {
		public static readonly DepotId_t Invalid = new DepotId_t(0x0);
		public uint _DepotId;

		public DepotId_t(uint value) {
			_DepotId = value;
		}

		public override string ToString() => _DepotId.ToString();

	    public override bool Equals(object other) => other is DepotId_t && this == (DepotId_t)other;

	    public override int GetHashCode() => _DepotId.GetHashCode();

	    public static bool operator ==(DepotId_t x, DepotId_t y) => x._DepotId == y._DepotId;

	    public static bool operator !=(DepotId_t x, DepotId_t y) => !(x == y);

	    public static explicit operator DepotId_t(uint value) => new DepotId_t(value);

	    public static explicit operator uint(DepotId_t that) => that._DepotId;

	    public bool Equals(DepotId_t other) => _DepotId == other._DepotId;

	    public int CompareTo(DepotId_t other) => _DepotId.CompareTo(other._DepotId);
	}
}

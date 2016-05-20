// This file is provided under The MIT License as part of Steamworks.NET.
// Copyright (c) 2013-2015 Riley Labrecque
// Please see the included LICENSE.txt for additional information.

// Changes to this file will be reverted when you update Steamworks.NET

namespace Steamworks {
	public struct DepotId : System.IEquatable<DepotId>, System.IComparable<DepotId> {
		public static readonly DepotId Invalid = new DepotId(0x0);
		public uint _DepotId;

		public DepotId(uint value) {
			_DepotId = value;
		}

		public override string ToString() => _DepotId.ToString();

	    public override bool Equals(object other) => other is DepotId && this == (DepotId)other;

	    public override int GetHashCode() => _DepotId.GetHashCode();

	    public static bool operator ==(DepotId x, DepotId y) => x._DepotId == y._DepotId;

	    public static bool operator !=(DepotId x, DepotId y) => !(x == y);

	    public static explicit operator DepotId(uint value) => new DepotId(value);

	    public static explicit operator uint(DepotId that) => that._DepotId;

	    public bool Equals(DepotId other) => _DepotId == other._DepotId;

	    public int CompareTo(DepotId other) => _DepotId.CompareTo(other._DepotId);
	}
}

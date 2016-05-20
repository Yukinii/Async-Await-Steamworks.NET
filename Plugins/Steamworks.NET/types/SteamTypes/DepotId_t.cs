// This file is provided under The MIT License as part of Steamworks.NET.
// Copyright (c) 2013-2015 Riley Labrecque
// Please see the included LICENSE.txt for additional information.

// Changes to this file will be reverted when you update Steamworks.NET

namespace Steamworks {
	public struct DepotId : System.IEquatable<DepotId>, System.IComparable<DepotId> {
		public static readonly DepotId Invalid = new DepotId(0x0);
		public readonly uint Id;

		public DepotId(uint value) {
			Id = value;
		}

		public override string ToString() => Id.ToString();

	    public override bool Equals(object other) => other is DepotId && this == (DepotId)other;

	    public override int GetHashCode() => Id.GetHashCode();

	    public static bool operator ==(DepotId x, DepotId y) => x.Id == y.Id;

	    public static bool operator !=(DepotId x, DepotId y) => !(x == y);

	    public static explicit operator DepotId(uint value) => new DepotId(value);

	    public static explicit operator uint(DepotId that) => that.Id;

	    public bool Equals(DepotId other) => Id == other.Id;

	    public int CompareTo(DepotId other) => Id.CompareTo(other.Id);
	}
}

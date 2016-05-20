// This file is provided under The MIT License as part of Steamworks.NET.
// Copyright (c) 2013-2015 Riley Labrecque
// Please see the included LICENSE.txt for additional information.

// Changes to this file will be reverted when you update Steamworks.NET

namespace Steamworks {
	public struct HAuthTicket : System.IEquatable<HAuthTicket>, System.IComparable<HAuthTicket> {
		public static readonly HAuthTicket Invalid = new HAuthTicket(0);
		public uint _HAuthTicket;

		public HAuthTicket(uint value) {
			_HAuthTicket = value;
		}

		public override string ToString() => _HAuthTicket.ToString();

	    public override bool Equals(object other) => other is HAuthTicket && this == (HAuthTicket)other;

	    public override int GetHashCode() => _HAuthTicket.GetHashCode();

	    public static bool operator ==(HAuthTicket x, HAuthTicket y) => x._HAuthTicket == y._HAuthTicket;

	    public static bool operator !=(HAuthTicket x, HAuthTicket y) => !(x == y);

	    public static explicit operator HAuthTicket(uint value) => new HAuthTicket(value);

	    public static explicit operator uint(HAuthTicket that) => that._HAuthTicket;

	    public bool Equals(HAuthTicket other) => _HAuthTicket == other._HAuthTicket;

	    public int CompareTo(HAuthTicket other) => _HAuthTicket.CompareTo(other._HAuthTicket);
	}
}

// This file is provided under The MIT License as part of Steamworks.NET.
// Copyright (c) 2013-2015 Riley Labrecque
// Please see the included LICENSE.txt for additional information.

// Changes to this file will be reverted when you update Steamworks.NET

namespace Steamworks {
	public struct HAuthTicket : System.IEquatable<HAuthTicket>, System.IComparable<HAuthTicket> {
		public static readonly HAuthTicket Invalid = new HAuthTicket(0);
		public readonly uint Ticket;

		public HAuthTicket(uint value) {
			Ticket = value;
		}

		public override string ToString() => Ticket.ToString();

	    public override bool Equals(object other) => other is HAuthTicket && this == (HAuthTicket)other;

	    public override int GetHashCode() => Ticket.GetHashCode();

	    public static bool operator ==(HAuthTicket x, HAuthTicket y) => x.Ticket == y.Ticket;

	    public static bool operator !=(HAuthTicket x, HAuthTicket y) => !(x == y);

	    public static explicit operator HAuthTicket(uint value) => new HAuthTicket(value);

	    public static explicit operator uint(HAuthTicket that) => that.Ticket;

	    public bool Equals(HAuthTicket other) => Ticket == other.Ticket;

	    public int CompareTo(HAuthTicket other) => Ticket.CompareTo(other.Ticket);
	}
}

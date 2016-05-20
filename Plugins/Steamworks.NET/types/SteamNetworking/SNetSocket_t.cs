// This file is provided under The MIT License as part of Steamworks.NET.
// Copyright (c) 2013-2015 Riley Labrecque
// Please see the included LICENSE.txt for additional information.

// Changes to this file will be reverted when you update Steamworks.NET

namespace Steamworks {
	public struct SNetSocket : System.IEquatable<SNetSocket>, System.IComparable<SNetSocket> {
		public readonly uint Socket;

		public SNetSocket(uint value) {
			Socket = value;
		}

		public override string ToString() => Socket.ToString();

	    public override bool Equals(object other) => other is SNetSocket && this == (SNetSocket)other;

	    public override int GetHashCode() => Socket.GetHashCode();

	    public static bool operator ==(SNetSocket x, SNetSocket y) => x.Socket == y.Socket;

	    public static bool operator !=(SNetSocket x, SNetSocket y) => !(x == y);

	    public static explicit operator SNetSocket(uint value) => new SNetSocket(value);

	    public static explicit operator uint(SNetSocket that) => that.Socket;

	    public bool Equals(SNetSocket other) => Socket == other.Socket;

	    public int CompareTo(SNetSocket other) => Socket.CompareTo(other.Socket);
	}
}

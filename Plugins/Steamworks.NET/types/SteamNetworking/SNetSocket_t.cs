// This file is provided under The MIT License as part of Steamworks.NET.
// Copyright (c) 2013-2015 Riley Labrecque
// Please see the included LICENSE.txt for additional information.

// Changes to this file will be reverted when you update Steamworks.NET

namespace Steamworks {
	public struct SNetSocket : System.IEquatable<SNetSocket>, System.IComparable<SNetSocket> {
		public uint _SNetSocket;

		public SNetSocket(uint value) {
			_SNetSocket = value;
		}

		public override string ToString() => _SNetSocket.ToString();

	    public override bool Equals(object other) => other is SNetSocket && this == (SNetSocket)other;

	    public override int GetHashCode() => _SNetSocket.GetHashCode();

	    public static bool operator ==(SNetSocket x, SNetSocket y) => x._SNetSocket == y._SNetSocket;

	    public static bool operator !=(SNetSocket x, SNetSocket y) => !(x == y);

	    public static explicit operator SNetSocket(uint value) => new SNetSocket(value);

	    public static explicit operator uint(SNetSocket that) => that._SNetSocket;

	    public bool Equals(SNetSocket other) => _SNetSocket == other._SNetSocket;

	    public int CompareTo(SNetSocket other) => _SNetSocket.CompareTo(other._SNetSocket);
	}
}

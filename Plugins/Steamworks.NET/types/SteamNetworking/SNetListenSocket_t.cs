// This file is provided under The MIT License as part of Steamworks.NET.
// Copyright (c) 2013-2015 Riley Labrecque
// Please see the included LICENSE.txt for additional information.

// Changes to this file will be reverted when you update Steamworks.NET

namespace Steamworks {
	public struct SNetListenSocket : System.IEquatable<SNetListenSocket>, System.IComparable<SNetListenSocket> {
		public uint _SNetListenSocket;

		public SNetListenSocket(uint value) {
			_SNetListenSocket = value;
		}

		public override string ToString() => _SNetListenSocket.ToString();

	    public override bool Equals(object other) => other is SNetListenSocket && this == (SNetListenSocket)other;

	    public override int GetHashCode() => _SNetListenSocket.GetHashCode();

	    public static bool operator ==(SNetListenSocket x, SNetListenSocket y) => x._SNetListenSocket == y._SNetListenSocket;

	    public static bool operator !=(SNetListenSocket x, SNetListenSocket y) => !(x == y);

	    public static explicit operator SNetListenSocket(uint value) => new SNetListenSocket(value);

	    public static explicit operator uint(SNetListenSocket that) => that._SNetListenSocket;

	    public bool Equals(SNetListenSocket other) => _SNetListenSocket == other._SNetListenSocket;

	    public int CompareTo(SNetListenSocket other) => _SNetListenSocket.CompareTo(other._SNetListenSocket);
	}
}

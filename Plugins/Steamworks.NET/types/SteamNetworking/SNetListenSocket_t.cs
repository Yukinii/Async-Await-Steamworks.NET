// This file is provided under The MIT License as part of Steamworks.NET.
// Copyright (c) 2013-2015 Riley Labrecque
// Please see the included LICENSE.txt for additional information.

// Changes to this file will be reverted when you update Steamworks.NET

namespace Steamworks {
	public struct SNetListenSocket_t : System.IEquatable<SNetListenSocket_t>, System.IComparable<SNetListenSocket_t> {
		public uint _SNetListenSocket;

		public SNetListenSocket_t(uint value) {
			_SNetListenSocket = value;
		}

		public override string ToString() => _SNetListenSocket.ToString();

	    public override bool Equals(object other) => other is SNetListenSocket_t && this == (SNetListenSocket_t)other;

	    public override int GetHashCode() => _SNetListenSocket.GetHashCode();

	    public static bool operator ==(SNetListenSocket_t x, SNetListenSocket_t y) => x._SNetListenSocket == y._SNetListenSocket;

	    public static bool operator !=(SNetListenSocket_t x, SNetListenSocket_t y) => !(x == y);

	    public static explicit operator SNetListenSocket_t(uint value) => new SNetListenSocket_t(value);

	    public static explicit operator uint(SNetListenSocket_t that) => that._SNetListenSocket;

	    public bool Equals(SNetListenSocket_t other) => _SNetListenSocket == other._SNetListenSocket;

	    public int CompareTo(SNetListenSocket_t other) => _SNetListenSocket.CompareTo(other._SNetListenSocket);
	}
}

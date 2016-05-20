// This file is provided under The MIT License as part of Steamworks.NET.
// Copyright (c) 2013-2015 Riley Labrecque
// Please see the included LICENSE.txt for additional information.

// Changes to this file will be reverted when you update Steamworks.NET

namespace Steamworks {
	public struct SNetSocket_t : System.IEquatable<SNetSocket_t>, System.IComparable<SNetSocket_t> {
		public uint _SNetSocket;

		public SNetSocket_t(uint value) {
			_SNetSocket = value;
		}

		public override string ToString() => _SNetSocket.ToString();

	    public override bool Equals(object other) => other is SNetSocket_t && this == (SNetSocket_t)other;

	    public override int GetHashCode() => _SNetSocket.GetHashCode();

	    public static bool operator ==(SNetSocket_t x, SNetSocket_t y) => x._SNetSocket == y._SNetSocket;

	    public static bool operator !=(SNetSocket_t x, SNetSocket_t y) => !(x == y);

	    public static explicit operator SNetSocket_t(uint value) => new SNetSocket_t(value);

	    public static explicit operator uint(SNetSocket_t that) => that._SNetSocket;

	    public bool Equals(SNetSocket_t other) => _SNetSocket == other._SNetSocket;

	    public int CompareTo(SNetSocket_t other) => _SNetSocket.CompareTo(other._SNetSocket);
	}
}

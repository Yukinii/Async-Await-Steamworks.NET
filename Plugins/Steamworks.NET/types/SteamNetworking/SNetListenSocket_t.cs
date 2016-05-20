// This file is provided under The MIT License as part of Steamworks.NET.
// Copyright (c) 2013-2015 Riley Labrecque
// Please see the included LICENSE.txt for additional information.

// Changes to this file will be reverted when you update Steamworks.NET

namespace Steamworks {
	public struct SNetListenSocket : System.IEquatable<SNetListenSocket>, System.IComparable<SNetListenSocket> {
		public readonly uint ListenSocket;

		public SNetListenSocket(uint value) {
			ListenSocket = value;
		}

		public override string ToString() => ListenSocket.ToString();

	    public override bool Equals(object other) => other is SNetListenSocket && this == (SNetListenSocket)other;

	    public override int GetHashCode() => ListenSocket.GetHashCode();

	    public static bool operator ==(SNetListenSocket x, SNetListenSocket y) => x.ListenSocket == y.ListenSocket;

	    public static bool operator !=(SNetListenSocket x, SNetListenSocket y) => !(x == y);

	    public static explicit operator SNetListenSocket(uint value) => new SNetListenSocket(value);

	    public static explicit operator uint(SNetListenSocket that) => that.ListenSocket;

	    public bool Equals(SNetListenSocket other) => ListenSocket == other.ListenSocket;

	    public int CompareTo(SNetListenSocket other) => ListenSocket.CompareTo(other.ListenSocket);
	}
}

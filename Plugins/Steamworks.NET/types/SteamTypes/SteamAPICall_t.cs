// This file is provided under The MIT License as part of Steamworks.NET.
// Copyright (c) 2013-2015 Riley Labrecque
// Please see the included LICENSE.txt for additional information.

// Changes to this file will be reverted when you update Steamworks.NET

namespace Steamworks {
	public struct SteamAPICall : System.IEquatable<SteamAPICall>, System.IComparable<SteamAPICall> {
		public static readonly SteamAPICall Invalid = new SteamAPICall(0x0);
		public ulong _SteamAPICall;

		public SteamAPICall(ulong value) {
			_SteamAPICall = value;
		}

		public override string ToString() => _SteamAPICall.ToString();

	    public override bool Equals(object other) => other is SteamAPICall && this == (SteamAPICall)other;

	    public override int GetHashCode() => _SteamAPICall.GetHashCode();

	    public static bool operator ==(SteamAPICall x, SteamAPICall y) => x._SteamAPICall == y._SteamAPICall;

	    public static bool operator !=(SteamAPICall x, SteamAPICall y) => !(x == y);

	    public static explicit operator SteamAPICall(ulong value) => new SteamAPICall(value);

	    public static explicit operator ulong(SteamAPICall that) => that._SteamAPICall;

	    public bool Equals(SteamAPICall other) => _SteamAPICall == other._SteamAPICall;

	    public int CompareTo(SteamAPICall other) => _SteamAPICall.CompareTo(other._SteamAPICall);
	}
}

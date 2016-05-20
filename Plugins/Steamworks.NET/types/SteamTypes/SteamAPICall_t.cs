// This file is provided under The MIT License as part of Steamworks.NET.
// Copyright (c) 2013-2015 Riley Labrecque
// Please see the included LICENSE.txt for additional information.

// Changes to this file will be reverted when you update Steamworks.NET

namespace Steamworks {
	public struct SteamAPICall_t : System.IEquatable<SteamAPICall_t>, System.IComparable<SteamAPICall_t> {
		public static readonly SteamAPICall_t Invalid = new SteamAPICall_t(0x0);
		public ulong _SteamAPICall;

		public SteamAPICall_t(ulong value) {
			_SteamAPICall = value;
		}

		public override string ToString() => _SteamAPICall.ToString();

	    public override bool Equals(object other) => other is SteamAPICall_t && this == (SteamAPICall_t)other;

	    public override int GetHashCode() => _SteamAPICall.GetHashCode();

	    public static bool operator ==(SteamAPICall_t x, SteamAPICall_t y) => x._SteamAPICall == y._SteamAPICall;

	    public static bool operator !=(SteamAPICall_t x, SteamAPICall_t y) => !(x == y);

	    public static explicit operator SteamAPICall_t(ulong value) => new SteamAPICall_t(value);

	    public static explicit operator ulong(SteamAPICall_t that) => that._SteamAPICall;

	    public bool Equals(SteamAPICall_t other) => _SteamAPICall == other._SteamAPICall;

	    public int CompareTo(SteamAPICall_t other) => _SteamAPICall.CompareTo(other._SteamAPICall);
	}
}

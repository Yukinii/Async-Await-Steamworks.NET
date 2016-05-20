// This file is provided under The MIT License as part of Steamworks.NET.
// Copyright (c) 2013-2015 Riley Labrecque
// Please see the included LICENSE.txt for additional information.

// Changes to this file will be reverted when you update Steamworks.NET

namespace Steamworks {
	public struct SteamAPICall : System.IEquatable<SteamAPICall>, System.IComparable<SteamAPICall> {
		public static readonly SteamAPICall Invalid = new SteamAPICall(0x0);
		public readonly ulong SteamApiCall;

		public SteamAPICall(ulong value) {
			SteamApiCall = value;
		}

		public override string ToString() => SteamApiCall.ToString();

	    public override bool Equals(object other) => other is SteamAPICall && this == (SteamAPICall)other;

	    public override int GetHashCode() => SteamApiCall.GetHashCode();

	    public static bool operator ==(SteamAPICall x, SteamAPICall y) => x.SteamApiCall == y.SteamApiCall;

	    public static bool operator !=(SteamAPICall x, SteamAPICall y) => !(x == y);

	    public static explicit operator SteamAPICall(ulong value) => new SteamAPICall(value);

	    public static explicit operator ulong(SteamAPICall that) => that.SteamApiCall;

	    public bool Equals(SteamAPICall other) => SteamApiCall == other.SteamApiCall;

	    public int CompareTo(SteamAPICall other) => SteamApiCall.CompareTo(other.SteamApiCall);
	}
}

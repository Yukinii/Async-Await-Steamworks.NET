// This file is provided under The MIT License as part of Steamworks.NET.
// Copyright (c) 2013-2015 Riley Labrecque
// Please see the included LICENSE.txt for additional information.

// Changes to this file will be reverted when you update Steamworks.NET

namespace Steamworks {
	public struct SteamLeaderboardEntries_t : System.IEquatable<SteamLeaderboardEntries_t>, System.IComparable<SteamLeaderboardEntries_t> {
		public ulong _SteamLeaderboardEntries;

		public SteamLeaderboardEntries_t(ulong value) {
			_SteamLeaderboardEntries = value;
		}

		public override string ToString() => _SteamLeaderboardEntries.ToString();

	    public override bool Equals(object other) => other is SteamLeaderboardEntries_t && this == (SteamLeaderboardEntries_t)other;

	    public override int GetHashCode() => _SteamLeaderboardEntries.GetHashCode();

	    public static bool operator ==(SteamLeaderboardEntries_t x, SteamLeaderboardEntries_t y) => x._SteamLeaderboardEntries == y._SteamLeaderboardEntries;

	    public static bool operator !=(SteamLeaderboardEntries_t x, SteamLeaderboardEntries_t y) => !(x == y);

	    public static explicit operator SteamLeaderboardEntries_t(ulong value) => new SteamLeaderboardEntries_t(value);

	    public static explicit operator ulong(SteamLeaderboardEntries_t that) => that._SteamLeaderboardEntries;

	    public bool Equals(SteamLeaderboardEntries_t other) => _SteamLeaderboardEntries == other._SteamLeaderboardEntries;

	    public int CompareTo(SteamLeaderboardEntries_t other) => _SteamLeaderboardEntries.CompareTo(other._SteamLeaderboardEntries);
	}
}

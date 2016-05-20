// This file is provided under The MIT License as part of Steamworks.NET.
// Copyright (c) 2013-2015 Riley Labrecque
// Please see the included LICENSE.txt for additional information.

// Changes to this file will be reverted when you update Steamworks.NET

namespace Steamworks {
	public struct SteamLeaderboardEntries : System.IEquatable<SteamLeaderboardEntries>, System.IComparable<SteamLeaderboardEntries> {
		public ulong _SteamLeaderboardEntries;

		public SteamLeaderboardEntries(ulong value) {
			_SteamLeaderboardEntries = value;
		}

		public override string ToString() => _SteamLeaderboardEntries.ToString();

	    public override bool Equals(object other) => other is SteamLeaderboardEntries && this == (SteamLeaderboardEntries)other;

	    public override int GetHashCode() => _SteamLeaderboardEntries.GetHashCode();

	    public static bool operator ==(SteamLeaderboardEntries x, SteamLeaderboardEntries y) => x._SteamLeaderboardEntries == y._SteamLeaderboardEntries;

	    public static bool operator !=(SteamLeaderboardEntries x, SteamLeaderboardEntries y) => !(x == y);

	    public static explicit operator SteamLeaderboardEntries(ulong value) => new SteamLeaderboardEntries(value);

	    public static explicit operator ulong(SteamLeaderboardEntries that) => that._SteamLeaderboardEntries;

	    public bool Equals(SteamLeaderboardEntries other) => _SteamLeaderboardEntries == other._SteamLeaderboardEntries;

	    public int CompareTo(SteamLeaderboardEntries other) => _SteamLeaderboardEntries.CompareTo(other._SteamLeaderboardEntries);
	}
}

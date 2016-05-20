// This file is provided under The MIT License as part of Steamworks.NET.
// Copyright (c) 2013-2015 Riley Labrecque
// Please see the included LICENSE.txt for additional information.

// Changes to this file will be reverted when you update Steamworks.NET

namespace Steamworks {
	public struct SteamLeaderboard_t : System.IEquatable<SteamLeaderboard_t>, System.IComparable<SteamLeaderboard_t> {
		public ulong _SteamLeaderboard;

		public SteamLeaderboard_t(ulong value) {
			_SteamLeaderboard = value;
		}

		public override string ToString() => _SteamLeaderboard.ToString();

	    public override bool Equals(object other) => other is SteamLeaderboard_t && this == (SteamLeaderboard_t)other;

	    public override int GetHashCode() => _SteamLeaderboard.GetHashCode();

	    public static bool operator ==(SteamLeaderboard_t x, SteamLeaderboard_t y) => x._SteamLeaderboard == y._SteamLeaderboard;

	    public static bool operator !=(SteamLeaderboard_t x, SteamLeaderboard_t y) => !(x == y);

	    public static explicit operator SteamLeaderboard_t(ulong value) => new SteamLeaderboard_t(value);

	    public static explicit operator ulong(SteamLeaderboard_t that) => that._SteamLeaderboard;

	    public bool Equals(SteamLeaderboard_t other) => _SteamLeaderboard == other._SteamLeaderboard;

	    public int CompareTo(SteamLeaderboard_t other) => _SteamLeaderboard.CompareTo(other._SteamLeaderboard);
	}
}

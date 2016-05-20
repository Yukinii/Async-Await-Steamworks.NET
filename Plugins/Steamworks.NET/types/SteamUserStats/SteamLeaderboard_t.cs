// This file is provided under The MIT License as part of Steamworks.NET.
// Copyright (c) 2013-2015 Riley Labrecque
// Please see the included LICENSE.txt for additional information.

// Changes to this file will be reverted when you update Steamworks.NET

namespace Steamworks {
	public struct SteamLeaderboard : System.IEquatable<SteamLeaderboard>, System.IComparable<SteamLeaderboard> {
	    private readonly ulong _SteamLeaderboard;

		public SteamLeaderboard(ulong value) {
			_SteamLeaderboard = value;
		}

		public override string ToString() => _SteamLeaderboard.ToString();

	    public override bool Equals(object other) => other is SteamLeaderboard && this == (SteamLeaderboard)other;

	    public override int GetHashCode() => _SteamLeaderboard.GetHashCode();

	    public static bool operator ==(SteamLeaderboard x, SteamLeaderboard y) => x._SteamLeaderboard == y._SteamLeaderboard;

	    public static bool operator !=(SteamLeaderboard x, SteamLeaderboard y) => !(x == y);

	    public static explicit operator SteamLeaderboard(ulong value) => new SteamLeaderboard(value);

	    public static explicit operator ulong(SteamLeaderboard that) => that._SteamLeaderboard;

	    public bool Equals(SteamLeaderboard other) => _SteamLeaderboard == other._SteamLeaderboard;

	    public int CompareTo(SteamLeaderboard other) => _SteamLeaderboard.CompareTo(other._SteamLeaderboard);
	}
}

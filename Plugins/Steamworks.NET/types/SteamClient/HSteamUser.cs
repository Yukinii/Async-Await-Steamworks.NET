// This file is provided under The MIT License as part of Steamworks.NET.
// Copyright (c) 2013-2015 Riley Labrecque
// Please see the included LICENSE.txt for additional information.

// Changes to this file will be reverted when you update Steamworks.NET

namespace Steamworks {
	public struct HSteamUser : System.IEquatable<HSteamUser>, System.IComparable<HSteamUser> {
		public int _HSteamUser;

		public HSteamUser(int value) {
			_HSteamUser = value;
		}

		public override string ToString() => _HSteamUser.ToString();

	    public override bool Equals(object other) => other is HSteamUser && this == (HSteamUser)other;

	    public override int GetHashCode() => _HSteamUser.GetHashCode();

	    public static bool operator ==(HSteamUser x, HSteamUser y) => x._HSteamUser == y._HSteamUser;

	    public static bool operator !=(HSteamUser x, HSteamUser y) => !(x == y);

	    public static explicit operator HSteamUser(int value) => new HSteamUser(value);

	    public static explicit operator int(HSteamUser that) => that._HSteamUser;

	    public bool Equals(HSteamUser other) => _HSteamUser == other._HSteamUser;

	    public int CompareTo(HSteamUser other) => _HSteamUser.CompareTo(other._HSteamUser);
	}
}

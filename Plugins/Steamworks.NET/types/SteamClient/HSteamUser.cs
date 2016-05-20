// This file is provided under The MIT License as part of Steamworks.NET.
// Copyright (c) 2013-2015 Riley Labrecque
// Please see the included LICENSE.txt for additional information.

// Changes to this file will be reverted when you update Steamworks.NET

namespace Steamworks {
	public struct HSteamUser : System.IEquatable<HSteamUser>, System.IComparable<HSteamUser> {
		public readonly int User;

		public HSteamUser(int value) {
			User = value;
		}

		public override string ToString() => User.ToString();

	    public override bool Equals(object other) => other is HSteamUser && this == (HSteamUser)other;

	    public override int GetHashCode() => User.GetHashCode();

	    public static bool operator ==(HSteamUser x, HSteamUser y) => x.User == y.User;

	    public static bool operator !=(HSteamUser x, HSteamUser y) => !(x == y);

	    public static explicit operator HSteamUser(int value) => new HSteamUser(value);

	    public static explicit operator int(HSteamUser that) => that.User;

	    public bool Equals(HSteamUser other) => User == other.User;

	    public int CompareTo(HSteamUser other) => User.CompareTo(other.User);
	}
}

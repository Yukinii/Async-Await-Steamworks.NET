// This file is provided under The MIT License as part of Steamworks.NET.
// Copyright (c) 2013-2015 Riley Labrecque
// Please see the included LICENSE.txt for additional information.

// Changes to this file will be reverted when you update Steamworks.NET

namespace Steamworks {
	public struct HSteamPipe : System.IEquatable<HSteamPipe>, System.IComparable<HSteamPipe> {
		public int _HSteamPipe;

		public HSteamPipe(int value) {
			_HSteamPipe = value;
		}

		public override string ToString() => _HSteamPipe.ToString();

	    public override bool Equals(object other) => other is HSteamPipe && this == (HSteamPipe)other;

	    public override int GetHashCode() => _HSteamPipe.GetHashCode();

	    public static bool operator ==(HSteamPipe x, HSteamPipe y) => x._HSteamPipe == y._HSteamPipe;

	    public static bool operator !=(HSteamPipe x, HSteamPipe y) => !(x == y);

	    public static explicit operator HSteamPipe(int value) => new HSteamPipe(value);

	    public static explicit operator int(HSteamPipe that) => that._HSteamPipe;

	    public bool Equals(HSteamPipe other) => _HSteamPipe == other._HSteamPipe;

	    public int CompareTo(HSteamPipe other) => _HSteamPipe.CompareTo(other._HSteamPipe);
	}
}

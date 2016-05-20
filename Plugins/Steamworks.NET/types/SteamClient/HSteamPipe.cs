// This file is provided under The MIT License as part of Steamworks.NET.
// Copyright (c) 2013-2015 Riley Labrecque
// Please see the included LICENSE.txt for additional information.

// Changes to this file will be reverted when you update Steamworks.NET

namespace Steamworks {
	public struct HSteamPipe : System.IEquatable<HSteamPipe>, System.IComparable<HSteamPipe> {
		public readonly int Pipe;

		public HSteamPipe(int value) {
			Pipe = value;
		}

		public override string ToString() => Pipe.ToString();

	    public override bool Equals(object other) => other is HSteamPipe && this == (HSteamPipe)other;

	    public override int GetHashCode() => Pipe.GetHashCode();

	    public static bool operator ==(HSteamPipe x, HSteamPipe y) => x.Pipe == y.Pipe;

	    public static bool operator !=(HSteamPipe x, HSteamPipe y) => !(x == y);

	    public static explicit operator HSteamPipe(int value) => new HSteamPipe(value);

	    public static explicit operator int(HSteamPipe that) => that.Pipe;

	    public bool Equals(HSteamPipe other) => Pipe == other.Pipe;

	    public int CompareTo(HSteamPipe other) => Pipe.CompareTo(other.Pipe);
	}
}

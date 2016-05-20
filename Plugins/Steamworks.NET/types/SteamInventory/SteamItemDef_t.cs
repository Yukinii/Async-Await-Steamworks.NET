// This file is provided under The MIT License as part of Steamworks.NET.
// Copyright (c) 2013-2015 Riley Labrecque
// Please see the included LICENSE.txt for additional information.

// Changes to this file will be reverted when you update Steamworks.NET

namespace Steamworks {
	public struct SteamItemDef : System.IEquatable<SteamItemDef>, System.IComparable<SteamItemDef> {
		public readonly int Definition;

		public SteamItemDef(int value) {
			Definition = value;
		}

		public override string ToString() => Definition.ToString();

	    public override bool Equals(object other) => other is SteamItemDef && this == (SteamItemDef)other;

	    public override int GetHashCode() => Definition.GetHashCode();

	    public static bool operator ==(SteamItemDef x, SteamItemDef y) => x.Definition == y.Definition;

	    public static bool operator !=(SteamItemDef x, SteamItemDef y) => !(x == y);

	    public static explicit operator SteamItemDef(int value) => new SteamItemDef(value);

	    public static explicit operator int(SteamItemDef that) => that.Definition;

	    public bool Equals(SteamItemDef other) => Definition == other.Definition;

	    public int CompareTo(SteamItemDef other) => Definition.CompareTo(other.Definition);
	}
}

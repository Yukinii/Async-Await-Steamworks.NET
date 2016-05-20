// This file is provided under The MIT License as part of Steamworks.NET.
// Copyright (c) 2013-2015 Riley Labrecque
// Please see the included LICENSE.txt for additional information.

// Changes to this file will be reverted when you update Steamworks.NET

namespace Steamworks {
	public struct SteamItemDef : System.IEquatable<SteamItemDef>, System.IComparable<SteamItemDef> {
		public int _SteamItemDef;

		public SteamItemDef(int value) {
			_SteamItemDef = value;
		}

		public override string ToString() => _SteamItemDef.ToString();

	    public override bool Equals(object other) => other is SteamItemDef && this == (SteamItemDef)other;

	    public override int GetHashCode() => _SteamItemDef.GetHashCode();

	    public static bool operator ==(SteamItemDef x, SteamItemDef y) => x._SteamItemDef == y._SteamItemDef;

	    public static bool operator !=(SteamItemDef x, SteamItemDef y) => !(x == y);

	    public static explicit operator SteamItemDef(int value) => new SteamItemDef(value);

	    public static explicit operator int(SteamItemDef that) => that._SteamItemDef;

	    public bool Equals(SteamItemDef other) => _SteamItemDef == other._SteamItemDef;

	    public int CompareTo(SteamItemDef other) => _SteamItemDef.CompareTo(other._SteamItemDef);
	}
}

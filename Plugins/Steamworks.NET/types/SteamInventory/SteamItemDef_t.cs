// This file is provided under The MIT License as part of Steamworks.NET.
// Copyright (c) 2013-2015 Riley Labrecque
// Please see the included LICENSE.txt for additional information.

// Changes to this file will be reverted when you update Steamworks.NET

namespace Steamworks {
	public struct SteamItemDef_t : System.IEquatable<SteamItemDef_t>, System.IComparable<SteamItemDef_t> {
		public int _SteamItemDef;

		public SteamItemDef_t(int value) {
			_SteamItemDef = value;
		}

		public override string ToString() => _SteamItemDef.ToString();

	    public override bool Equals(object other) => other is SteamItemDef_t && this == (SteamItemDef_t)other;

	    public override int GetHashCode() => _SteamItemDef.GetHashCode();

	    public static bool operator ==(SteamItemDef_t x, SteamItemDef_t y) => x._SteamItemDef == y._SteamItemDef;

	    public static bool operator !=(SteamItemDef_t x, SteamItemDef_t y) => !(x == y);

	    public static explicit operator SteamItemDef_t(int value) => new SteamItemDef_t(value);

	    public static explicit operator int(SteamItemDef_t that) => that._SteamItemDef;

	    public bool Equals(SteamItemDef_t other) => _SteamItemDef == other._SteamItemDef;

	    public int CompareTo(SteamItemDef_t other) => _SteamItemDef.CompareTo(other._SteamItemDef);
	}
}

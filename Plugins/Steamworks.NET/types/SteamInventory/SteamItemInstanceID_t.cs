// This file is provided under The MIT License as part of Steamworks.NET.
// Copyright (c) 2013-2015 Riley Labrecque
// Please see the included LICENSE.txt for additional information.

// Changes to this file will be reverted when you update Steamworks.NET

namespace Steamworks {
	public struct SteamItemInstanceID_t : System.IEquatable<SteamItemInstanceID_t>, System.IComparable<SteamItemInstanceID_t> {
		public static readonly SteamItemInstanceID_t Invalid = new SteamItemInstanceID_t(0xFFFFFFFFFFFFFFFF);
		public ulong _SteamItemInstanceID;

		public SteamItemInstanceID_t(ulong value) {
			_SteamItemInstanceID = value;
		}

		public override string ToString() => _SteamItemInstanceID.ToString();

	    public override bool Equals(object other) => other is SteamItemInstanceID_t && this == (SteamItemInstanceID_t)other;

	    public override int GetHashCode() => _SteamItemInstanceID.GetHashCode();

	    public static bool operator ==(SteamItemInstanceID_t x, SteamItemInstanceID_t y) => x._SteamItemInstanceID == y._SteamItemInstanceID;

	    public static bool operator !=(SteamItemInstanceID_t x, SteamItemInstanceID_t y) => !(x == y);

	    public static explicit operator SteamItemInstanceID_t(ulong value) => new SteamItemInstanceID_t(value);

	    public static explicit operator ulong(SteamItemInstanceID_t that) => that._SteamItemInstanceID;

	    public bool Equals(SteamItemInstanceID_t other) => _SteamItemInstanceID == other._SteamItemInstanceID;

	    public int CompareTo(SteamItemInstanceID_t other) => _SteamItemInstanceID.CompareTo(other._SteamItemInstanceID);
	}
}

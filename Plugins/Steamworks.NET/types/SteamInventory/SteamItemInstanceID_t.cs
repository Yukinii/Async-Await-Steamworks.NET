// This file is provided under The MIT License as part of Steamworks.NET.
// Copyright (c) 2013-2015 Riley Labrecque
// Please see the included LICENSE.txt for additional information.

// Changes to this file will be reverted when you update Steamworks.NET

namespace Steamworks {
	public struct SteamItemInstanceID : System.IEquatable<SteamItemInstanceID>, System.IComparable<SteamItemInstanceID> {
		public static readonly SteamItemInstanceID Invalid = new SteamItemInstanceID(0xFFFFFFFFFFFFFFFF);
		public ulong _SteamItemInstanceID;

		public SteamItemInstanceID(ulong value) {
			_SteamItemInstanceID = value;
		}

		public override string ToString() => _SteamItemInstanceID.ToString();

	    public override bool Equals(object other) => other is SteamItemInstanceID && this == (SteamItemInstanceID)other;

	    public override int GetHashCode() => _SteamItemInstanceID.GetHashCode();

	    public static bool operator ==(SteamItemInstanceID x, SteamItemInstanceID y) => x._SteamItemInstanceID == y._SteamItemInstanceID;

	    public static bool operator !=(SteamItemInstanceID x, SteamItemInstanceID y) => !(x == y);

	    public static explicit operator SteamItemInstanceID(ulong value) => new SteamItemInstanceID(value);

	    public static explicit operator ulong(SteamItemInstanceID that) => that._SteamItemInstanceID;

	    public bool Equals(SteamItemInstanceID other) => _SteamItemInstanceID == other._SteamItemInstanceID;

	    public int CompareTo(SteamItemInstanceID other) => _SteamItemInstanceID.CompareTo(other._SteamItemInstanceID);
	}
}

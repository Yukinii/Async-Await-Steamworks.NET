// This file is provided under The MIT License as part of Steamworks.NET.
// Copyright (c) 2013-2015 Riley Labrecque
// Please see the included LICENSE.txt for additional information.

// Changes to this file will be reverted when you update Steamworks.NET

namespace Steamworks {
	public struct SteamInventoryResult_t : System.IEquatable<SteamInventoryResult_t>, System.IComparable<SteamInventoryResult_t> {
		public static readonly SteamInventoryResult_t Invalid = new SteamInventoryResult_t(-1);
		public int _SteamInventoryResult;

		public SteamInventoryResult_t(int value) {
			_SteamInventoryResult = value;
		}

		public override string ToString() => _SteamInventoryResult.ToString();

	    public override bool Equals(object other) => other is SteamInventoryResult_t && this == (SteamInventoryResult_t)other;

	    public override int GetHashCode() => _SteamInventoryResult.GetHashCode();

	    public static bool operator ==(SteamInventoryResult_t x, SteamInventoryResult_t y) => x._SteamInventoryResult == y._SteamInventoryResult;

	    public static bool operator !=(SteamInventoryResult_t x, SteamInventoryResult_t y) => !(x == y);

	    public static explicit operator SteamInventoryResult_t(int value) => new SteamInventoryResult_t(value);

	    public static explicit operator int(SteamInventoryResult_t that) => that._SteamInventoryResult;

	    public bool Equals(SteamInventoryResult_t other) => _SteamInventoryResult == other._SteamInventoryResult;

	    public int CompareTo(SteamInventoryResult_t other) => _SteamInventoryResult.CompareTo(other._SteamInventoryResult);
	}
}

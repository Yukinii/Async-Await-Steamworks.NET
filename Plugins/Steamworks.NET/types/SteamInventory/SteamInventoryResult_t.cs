// This file is provided under The MIT License as part of Steamworks.NET.
// Copyright (c) 2013-2015 Riley Labrecque
// Please see the included LICENSE.txt for additional information.

// Changes to this file will be reverted when you update Steamworks.NET

namespace Steamworks {
	public struct SteamInventoryResult : System.IEquatable<SteamInventoryResult>, System.IComparable<SteamInventoryResult> {
		public static readonly SteamInventoryResult Invalid = new SteamInventoryResult(-1);
		public int _SteamInventoryResult;

		public SteamInventoryResult(int value) {
			_SteamInventoryResult = value;
		}

		public override string ToString() => _SteamInventoryResult.ToString();

	    public override bool Equals(object other) => other is SteamInventoryResult && this == (SteamInventoryResult)other;

	    public override int GetHashCode() => _SteamInventoryResult.GetHashCode();

	    public static bool operator ==(SteamInventoryResult x, SteamInventoryResult y) => x._SteamInventoryResult == y._SteamInventoryResult;

	    public static bool operator !=(SteamInventoryResult x, SteamInventoryResult y) => !(x == y);

	    public static explicit operator SteamInventoryResult(int value) => new SteamInventoryResult(value);

	    public static explicit operator int(SteamInventoryResult that) => that._SteamInventoryResult;

	    public bool Equals(SteamInventoryResult other) => _SteamInventoryResult == other._SteamInventoryResult;

	    public int CompareTo(SteamInventoryResult other) => _SteamInventoryResult.CompareTo(other._SteamInventoryResult);
	}
}

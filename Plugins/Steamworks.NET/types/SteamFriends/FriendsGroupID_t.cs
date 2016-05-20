// This file is provided under The MIT License as part of Steamworks.NET.
// Copyright (c) 2013-2015 Riley Labrecque
// Please see the included LICENSE.txt for additional information.

// Changes to this file will be reverted when you update Steamworks.NET

namespace Steamworks {
	public struct FriendsGroupID_t : System.IEquatable<FriendsGroupID_t>, System.IComparable<FriendsGroupID_t> {
		public static readonly FriendsGroupID_t Invalid = new FriendsGroupID_t(-1);
		public short _FriendsGroupID;

		public FriendsGroupID_t(short value) {
			_FriendsGroupID = value;
		}

		public override string ToString() => _FriendsGroupID.ToString();

	    public override bool Equals(object other) => other is FriendsGroupID_t && this == (FriendsGroupID_t)other;

	    public override int GetHashCode() => _FriendsGroupID.GetHashCode();

	    public static bool operator ==(FriendsGroupID_t x, FriendsGroupID_t y) => x._FriendsGroupID == y._FriendsGroupID;

	    public static bool operator !=(FriendsGroupID_t x, FriendsGroupID_t y) => !(x == y);

	    public static explicit operator FriendsGroupID_t(short value) => new FriendsGroupID_t(value);

	    public static explicit operator short(FriendsGroupID_t that) => that._FriendsGroupID;

	    public bool Equals(FriendsGroupID_t other) => _FriendsGroupID == other._FriendsGroupID;

	    public int CompareTo(FriendsGroupID_t other) => _FriendsGroupID.CompareTo(other._FriendsGroupID);
	}
}

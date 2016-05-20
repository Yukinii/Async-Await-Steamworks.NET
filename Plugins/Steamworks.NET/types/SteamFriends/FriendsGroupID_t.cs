// This file is provided under The MIT License as part of Steamworks.NET.
// Copyright (c) 2013-2015 Riley Labrecque
// Please see the included LICENSE.txt for additional information.

// Changes to this file will be reverted when you update Steamworks.NET

namespace Steamworks {
	public struct FriendsGroupID : System.IEquatable<FriendsGroupID>, System.IComparable<FriendsGroupID> {
		public static readonly FriendsGroupID Invalid = new FriendsGroupID(-1);
		public short _FriendsGroupID;

		public FriendsGroupID(short value) {
			_FriendsGroupID = value;
		}

		public override string ToString() => _FriendsGroupID.ToString();

	    public override bool Equals(object other) => other is FriendsGroupID && this == (FriendsGroupID)other;

	    public override int GetHashCode() => _FriendsGroupID.GetHashCode();

	    public static bool operator ==(FriendsGroupID x, FriendsGroupID y) => x._FriendsGroupID == y._FriendsGroupID;

	    public static bool operator !=(FriendsGroupID x, FriendsGroupID y) => !(x == y);

	    public static explicit operator FriendsGroupID(short value) => new FriendsGroupID(value);

	    public static explicit operator short(FriendsGroupID that) => that._FriendsGroupID;

	    public bool Equals(FriendsGroupID other) => _FriendsGroupID == other._FriendsGroupID;

	    public int CompareTo(FriendsGroupID other) => _FriendsGroupID.CompareTo(other._FriendsGroupID);
	}
}

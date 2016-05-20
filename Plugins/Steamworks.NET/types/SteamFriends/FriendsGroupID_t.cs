// This file is provided under The MIT License as part of Steamworks.NET.
// Copyright (c) 2013-2015 Riley Labrecque
// Please see the included LICENSE.txt for additional information.

// Changes to this file will be reverted when you update Steamworks.NET

namespace Steamworks {
	public struct FriendsGroupID : System.IEquatable<FriendsGroupID>, System.IComparable<FriendsGroupID> {
		public static readonly FriendsGroupID Invalid = new FriendsGroupID(-1);
		public readonly short Id;

		public FriendsGroupID(short value) {
			Id = value;
		}

		public override string ToString() => Id.ToString();

	    public override bool Equals(object other) => other is FriendsGroupID && this == (FriendsGroupID)other;

	    public override int GetHashCode() => Id.GetHashCode();

	    public static bool operator ==(FriendsGroupID x, FriendsGroupID y) => x.Id == y.Id;

	    public static bool operator !=(FriendsGroupID x, FriendsGroupID y) => !(x == y);

	    public static explicit operator FriendsGroupID(short value) => new FriendsGroupID(value);

	    public static explicit operator short(FriendsGroupID that) => that.Id;

	    public bool Equals(FriendsGroupID other) => Id == other.Id;

	    public int CompareTo(FriendsGroupID other) => Id.CompareTo(other.Id);
	}
}

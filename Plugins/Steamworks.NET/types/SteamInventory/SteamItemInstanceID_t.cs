// This file is provided under The MIT License as part of Steamworks.NET.
// Copyright (c) 2013-2015 Riley Labrecque
// Please see the included LICENSE.txt for additional information.

// Changes to this file will be reverted when you update Steamworks.NET

namespace Steamworks {
	public struct SteamItemInstanceId : System.IEquatable<SteamItemInstanceId>, System.IComparable<SteamItemInstanceId> {
		public static readonly SteamItemInstanceId Invalid = new SteamItemInstanceId(0xFFFFFFFFFFFFFFFF);
		public readonly ulong Id;

		public SteamItemInstanceId(ulong value) {
			Id = value;
		}

		public override string ToString() => Id.ToString();

	    public override bool Equals(object other) => other is SteamItemInstanceId && this == (SteamItemInstanceId)other;

	    public override int GetHashCode() => Id.GetHashCode();

	    public static bool operator ==(SteamItemInstanceId x, SteamItemInstanceId y) => x.Id == y.Id;

	    public static bool operator !=(SteamItemInstanceId x, SteamItemInstanceId y) => !(x == y);

	    public static explicit operator SteamItemInstanceId(ulong value) => new SteamItemInstanceId(value);

	    public static explicit operator ulong(SteamItemInstanceId that) => that.Id;

	    public bool Equals(SteamItemInstanceId other) => Id == other.Id;

	    public int CompareTo(SteamItemInstanceId other) => Id.CompareTo(other.Id);
	}
}

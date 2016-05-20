// This file is provided under The MIT License as part of Steamworks.NET.
// Copyright (c) 2013-2015 Riley Labrecque
// Please see the included LICENSE.txt for additional information.

// Changes to this file will be reverted when you update Steamworks.NET

namespace Steamworks {
	public struct AppId : System.IEquatable<AppId>, System.IComparable<AppId> {
		public static readonly AppId Invalid = new AppId(0x0);
	    public readonly uint Id;

		public AppId(uint value) {
			Id = value;
		}

		public override string ToString() => Id.ToString();

	    public override bool Equals(object other) => other is AppId && this == (AppId)other;

	    public override int GetHashCode() => Id.GetHashCode();

	    public static bool operator ==(AppId x, AppId y) => x.Id == y.Id;

	    public static bool operator !=(AppId x, AppId y) => !(x == y);

	    public static explicit operator AppId(uint value) => new AppId(value);

	    public static explicit operator uint(AppId that) => that.Id;

	    public bool Equals(AppId other) => Id == other.Id;

	    public int CompareTo(AppId other) => Id.CompareTo(other.Id);
	}
}

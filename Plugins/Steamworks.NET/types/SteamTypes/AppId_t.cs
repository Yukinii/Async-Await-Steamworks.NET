// This file is provided under The MIT License as part of Steamworks.NET.
// Copyright (c) 2013-2015 Riley Labrecque
// Please see the included LICENSE.txt for additional information.

// Changes to this file will be reverted when you update Steamworks.NET

namespace Steamworks {
	public struct AppId_t : System.IEquatable<AppId_t>, System.IComparable<AppId_t> {
		public static readonly AppId_t Invalid = new AppId_t(0x0);
		public uint _AppId;

		public AppId_t(uint value) {
			_AppId = value;
		}

		public override string ToString() => _AppId.ToString();

	    public override bool Equals(object other) => other is AppId_t && this == (AppId_t)other;

	    public override int GetHashCode() => _AppId.GetHashCode();

	    public static bool operator ==(AppId_t x, AppId_t y) => x._AppId == y._AppId;

	    public static bool operator !=(AppId_t x, AppId_t y) => !(x == y);

	    public static explicit operator AppId_t(uint value) => new AppId_t(value);

	    public static explicit operator uint(AppId_t that) => that._AppId;

	    public bool Equals(AppId_t other) => _AppId == other._AppId;

	    public int CompareTo(AppId_t other) => _AppId.CompareTo(other._AppId);
	}
}

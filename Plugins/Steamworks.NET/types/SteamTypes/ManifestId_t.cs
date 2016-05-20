// This file is provided under The MIT License as part of Steamworks.NET.
// Copyright (c) 2013-2015 Riley Labrecque
// Please see the included LICENSE.txt for additional information.

// Changes to this file will be reverted when you update Steamworks.NET

namespace Steamworks {
	public struct ManifestId_t : System.IEquatable<ManifestId_t>, System.IComparable<ManifestId_t> {
		public static readonly ManifestId_t Invalid = new ManifestId_t(0x0);
		public ulong _ManifestId;

		public ManifestId_t(ulong value) {
			_ManifestId = value;
		}

		public override string ToString() => _ManifestId.ToString();

	    public override bool Equals(object other) => other is ManifestId_t && this == (ManifestId_t)other;

	    public override int GetHashCode() => _ManifestId.GetHashCode();

	    public static bool operator ==(ManifestId_t x, ManifestId_t y) => x._ManifestId == y._ManifestId;

	    public static bool operator !=(ManifestId_t x, ManifestId_t y) => !(x == y);

	    public static explicit operator ManifestId_t(ulong value) => new ManifestId_t(value);

	    public static explicit operator ulong(ManifestId_t that) => that._ManifestId;

	    public bool Equals(ManifestId_t other) => _ManifestId == other._ManifestId;

	    public int CompareTo(ManifestId_t other) => _ManifestId.CompareTo(other._ManifestId);
	}
}

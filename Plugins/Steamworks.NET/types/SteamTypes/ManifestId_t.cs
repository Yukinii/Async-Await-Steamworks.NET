// This file is provided under The MIT License as part of Steamworks.NET.
// Copyright (c) 2013-2015 Riley Labrecque
// Please see the included LICENSE.txt for additional information.

// Changes to this file will be reverted when you update Steamworks.NET

namespace Steamworks {
	public struct ManifestId : System.IEquatable<ManifestId>, System.IComparable<ManifestId> {
		public static readonly ManifestId Invalid = new ManifestId(0x0);
	    public readonly ulong Id;

		public ManifestId(ulong value) {
			Id = value;
		}

		public override string ToString() => Id.ToString();

	    public override bool Equals(object other) => other is ManifestId && this == (ManifestId)other;

	    public override int GetHashCode() => Id.GetHashCode();

	    public static bool operator ==(ManifestId x, ManifestId y) => x.Id == y.Id;

	    public static bool operator !=(ManifestId x, ManifestId y) => !(x == y);

	    public static explicit operator ManifestId(ulong value) => new ManifestId(value);

	    public static explicit operator ulong(ManifestId that) => that.Id;

	    public bool Equals(ManifestId other) => Id == other.Id;

	    public int CompareTo(ManifestId other) => Id.CompareTo(other.Id);
	}
}

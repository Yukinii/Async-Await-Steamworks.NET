// This file is provided under The MIT License as part of Steamworks.NET.
// Copyright (c) 2013-2015 Riley Labrecque
// Please see the included LICENSE.txt for additional information.

// Changes to this file will be reverted when you update Steamworks.NET

namespace Steamworks {
	public struct PublishedFileId : System.IEquatable<PublishedFileId>, System.IComparable<PublishedFileId> {
		public static readonly PublishedFileId Invalid = new PublishedFileId(0);
	    public readonly ulong Id;

		public PublishedFileId(ulong value) {
			Id = value;
		}

		public override string ToString() => Id.ToString();

	    public override bool Equals(object other) => other is PublishedFileId && this == (PublishedFileId)other;

	    public override int GetHashCode() => Id.GetHashCode();

	    public static bool operator ==(PublishedFileId x, PublishedFileId y) => x.Id == y.Id;

	    public static bool operator !=(PublishedFileId x, PublishedFileId y) => !(x == y);

	    public static explicit operator PublishedFileId(ulong value) => new PublishedFileId(value);

	    public static explicit operator ulong(PublishedFileId that) => that.Id;

	    public bool Equals(PublishedFileId other) => Id == other.Id;

	    public int CompareTo(PublishedFileId other) => Id.CompareTo(other.Id);
	}
}

// This file is provided under The MIT License as part of Steamworks.NET.
// Copyright (c) 2013-2015 Riley Labrecque
// Please see the included LICENSE.txt for additional information.

// Changes to this file will be reverted when you update Steamworks.NET

namespace Steamworks {
	public struct PublishedFileId : System.IEquatable<PublishedFileId>, System.IComparable<PublishedFileId> {
		public static readonly PublishedFileId Invalid = new PublishedFileId(0);
		public ulong _PublishedFileId;

		public PublishedFileId(ulong value) {
			_PublishedFileId = value;
		}

		public override string ToString() => _PublishedFileId.ToString();

	    public override bool Equals(object other) => other is PublishedFileId && this == (PublishedFileId)other;

	    public override int GetHashCode() => _PublishedFileId.GetHashCode();

	    public static bool operator ==(PublishedFileId x, PublishedFileId y) => x._PublishedFileId == y._PublishedFileId;

	    public static bool operator !=(PublishedFileId x, PublishedFileId y) => !(x == y);

	    public static explicit operator PublishedFileId(ulong value) => new PublishedFileId(value);

	    public static explicit operator ulong(PublishedFileId that) => that._PublishedFileId;

	    public bool Equals(PublishedFileId other) => _PublishedFileId == other._PublishedFileId;

	    public int CompareTo(PublishedFileId other) => _PublishedFileId.CompareTo(other._PublishedFileId);
	}
}

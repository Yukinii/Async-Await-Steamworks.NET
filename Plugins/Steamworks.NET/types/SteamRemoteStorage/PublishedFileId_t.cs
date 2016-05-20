// This file is provided under The MIT License as part of Steamworks.NET.
// Copyright (c) 2013-2015 Riley Labrecque
// Please see the included LICENSE.txt for additional information.

// Changes to this file will be reverted when you update Steamworks.NET

namespace Steamworks {
	public struct PublishedFileId_t : System.IEquatable<PublishedFileId_t>, System.IComparable<PublishedFileId_t> {
		public static readonly PublishedFileId_t Invalid = new PublishedFileId_t(0);
		public ulong _PublishedFileId;

		public PublishedFileId_t(ulong value) {
			_PublishedFileId = value;
		}

		public override string ToString() => _PublishedFileId.ToString();

	    public override bool Equals(object other) => other is PublishedFileId_t && this == (PublishedFileId_t)other;

	    public override int GetHashCode() => _PublishedFileId.GetHashCode();

	    public static bool operator ==(PublishedFileId_t x, PublishedFileId_t y) => x._PublishedFileId == y._PublishedFileId;

	    public static bool operator !=(PublishedFileId_t x, PublishedFileId_t y) => !(x == y);

	    public static explicit operator PublishedFileId_t(ulong value) => new PublishedFileId_t(value);

	    public static explicit operator ulong(PublishedFileId_t that) => that._PublishedFileId;

	    public bool Equals(PublishedFileId_t other) => _PublishedFileId == other._PublishedFileId;

	    public int CompareTo(PublishedFileId_t other) => _PublishedFileId.CompareTo(other._PublishedFileId);
	}
}

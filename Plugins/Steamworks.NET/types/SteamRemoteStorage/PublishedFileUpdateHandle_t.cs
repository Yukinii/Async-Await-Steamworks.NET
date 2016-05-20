// This file is provided under The MIT License as part of Steamworks.NET.
// Copyright (c) 2013-2015 Riley Labrecque
// Please see the included LICENSE.txt for additional information.

// Changes to this file will be reverted when you update Steamworks.NET

namespace Steamworks {
	public struct PublishedFileUpdateHandle_t : System.IEquatable<PublishedFileUpdateHandle_t>, System.IComparable<PublishedFileUpdateHandle_t> {
		public static readonly PublishedFileUpdateHandle_t Invalid = new PublishedFileUpdateHandle_t(0xffffffffffffffff);
		public ulong _PublishedFileUpdateHandle;

		public PublishedFileUpdateHandle_t(ulong value) {
			_PublishedFileUpdateHandle = value;
		}

		public override string ToString() => _PublishedFileUpdateHandle.ToString();

	    public override bool Equals(object other) => other is PublishedFileUpdateHandle_t && this == (PublishedFileUpdateHandle_t)other;

	    public override int GetHashCode() => _PublishedFileUpdateHandle.GetHashCode();

	    public static bool operator ==(PublishedFileUpdateHandle_t x, PublishedFileUpdateHandle_t y) => x._PublishedFileUpdateHandle == y._PublishedFileUpdateHandle;

	    public static bool operator !=(PublishedFileUpdateHandle_t x, PublishedFileUpdateHandle_t y) => !(x == y);

	    public static explicit operator PublishedFileUpdateHandle_t(ulong value) => new PublishedFileUpdateHandle_t(value);

	    public static explicit operator ulong(PublishedFileUpdateHandle_t that) => that._PublishedFileUpdateHandle;

	    public bool Equals(PublishedFileUpdateHandle_t other) => _PublishedFileUpdateHandle == other._PublishedFileUpdateHandle;

	    public int CompareTo(PublishedFileUpdateHandle_t other) => _PublishedFileUpdateHandle.CompareTo(other._PublishedFileUpdateHandle);
	}
}

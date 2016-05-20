// This file is provided under The MIT License as part of Steamworks.NET.
// Copyright (c) 2013-2015 Riley Labrecque
// Please see the included LICENSE.txt for additional information.

// Changes to this file will be reverted when you update Steamworks.NET

namespace Steamworks {
	public struct PublishedFileUpdateHandle : System.IEquatable<PublishedFileUpdateHandle>, System.IComparable<PublishedFileUpdateHandle> {
		public static readonly PublishedFileUpdateHandle Invalid = new PublishedFileUpdateHandle(0xffffffffffffffff);
		public ulong _PublishedFileUpdateHandle;

		public PublishedFileUpdateHandle(ulong value) {
			_PublishedFileUpdateHandle = value;
		}

		public override string ToString() => _PublishedFileUpdateHandle.ToString();

	    public override bool Equals(object other) => other is PublishedFileUpdateHandle && this == (PublishedFileUpdateHandle)other;

	    public override int GetHashCode() => _PublishedFileUpdateHandle.GetHashCode();

	    public static bool operator ==(PublishedFileUpdateHandle x, PublishedFileUpdateHandle y) => x._PublishedFileUpdateHandle == y._PublishedFileUpdateHandle;

	    public static bool operator !=(PublishedFileUpdateHandle x, PublishedFileUpdateHandle y) => !(x == y);

	    public static explicit operator PublishedFileUpdateHandle(ulong value) => new PublishedFileUpdateHandle(value);

	    public static explicit operator ulong(PublishedFileUpdateHandle that) => that._PublishedFileUpdateHandle;

	    public bool Equals(PublishedFileUpdateHandle other) => _PublishedFileUpdateHandle == other._PublishedFileUpdateHandle;

	    public int CompareTo(PublishedFileUpdateHandle other) => _PublishedFileUpdateHandle.CompareTo(other._PublishedFileUpdateHandle);
	}
}

// This file is provided under The MIT License as part of Steamworks.NET.
// Copyright (c) 2013-2015 Riley Labrecque
// Please see the included LICENSE.txt for additional information.

// Changes to this file will be reverted when you update Steamworks.NET

namespace Steamworks {
	public struct PublishedFileUpdateHandle : System.IEquatable<PublishedFileUpdateHandle>, System.IComparable<PublishedFileUpdateHandle> {
		public static readonly PublishedFileUpdateHandle Invalid = new PublishedFileUpdateHandle(0xffffffffffffffff);
	    public readonly ulong UpdateHandle;

		public PublishedFileUpdateHandle(ulong value) {
			UpdateHandle = value;
		}

		public override string ToString() => UpdateHandle.ToString();

	    public override bool Equals(object other) => other is PublishedFileUpdateHandle && this == (PublishedFileUpdateHandle)other;

	    public override int GetHashCode() => UpdateHandle.GetHashCode();

	    public static bool operator ==(PublishedFileUpdateHandle x, PublishedFileUpdateHandle y) => x.UpdateHandle == y.UpdateHandle;

	    public static bool operator !=(PublishedFileUpdateHandle x, PublishedFileUpdateHandle y) => !(x == y);

	    public static explicit operator PublishedFileUpdateHandle(ulong value) => new PublishedFileUpdateHandle(value);

	    public static explicit operator ulong(PublishedFileUpdateHandle that) => that.UpdateHandle;

	    public bool Equals(PublishedFileUpdateHandle other) => UpdateHandle == other.UpdateHandle;

	    public int CompareTo(PublishedFileUpdateHandle other) => UpdateHandle.CompareTo(other.UpdateHandle);
	}
}

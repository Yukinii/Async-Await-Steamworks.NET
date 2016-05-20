// This file is provided under The MIT License as part of Steamworks.NET.
// Copyright (c) 2013-2015 Riley Labrecque
// Please see the included LICENSE.txt for additional information.

// Changes to this file will be reverted when you update Steamworks.NET

namespace Steamworks {
	public struct HTTPRequestHandle : System.IEquatable<HTTPRequestHandle>, System.IComparable<HTTPRequestHandle> {
		public static readonly HTTPRequestHandle Invalid = new HTTPRequestHandle(0);
		public readonly uint Handle;

		public HTTPRequestHandle(uint value) {
			Handle = value;
		}

		public override string ToString() => Handle.ToString();

	    public override bool Equals(object other) => other is HTTPRequestHandle && this == (HTTPRequestHandle)other;

	    public override int GetHashCode() => Handle.GetHashCode();

	    public static bool operator ==(HTTPRequestHandle x, HTTPRequestHandle y) => x.Handle == y.Handle;

	    public static bool operator !=(HTTPRequestHandle x, HTTPRequestHandle y) => !(x == y);

	    public static explicit operator HTTPRequestHandle(uint value) => new HTTPRequestHandle(value);

	    public static explicit operator uint(HTTPRequestHandle that) => that.Handle;

	    public bool Equals(HTTPRequestHandle other) => Handle == other.Handle;

	    public int CompareTo(HTTPRequestHandle other) => Handle.CompareTo(other.Handle);
	}
}

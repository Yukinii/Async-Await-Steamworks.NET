// This file is provided under The MIT License as part of Steamworks.NET.
// Copyright (c) 2013-2015 Riley Labrecque
// Please see the included LICENSE.txt for additional information.

// Changes to this file will be reverted when you update Steamworks.NET

namespace Steamworks {
	public struct HTTPCookieContainerHandle : System.IEquatable<HTTPCookieContainerHandle>, System.IComparable<HTTPCookieContainerHandle> {
		public static readonly HTTPCookieContainerHandle Invalid = new HTTPCookieContainerHandle(0);
		public readonly uint Handle;

		public HTTPCookieContainerHandle(uint value) {
			Handle = value;
		}

		public override string ToString() => Handle.ToString();

	    public override bool Equals(object other) => other is HTTPCookieContainerHandle && this == (HTTPCookieContainerHandle)other;

	    public override int GetHashCode() => Handle.GetHashCode();

	    public static bool operator ==(HTTPCookieContainerHandle x, HTTPCookieContainerHandle y) => x.Handle == y.Handle;

	    public static bool operator !=(HTTPCookieContainerHandle x, HTTPCookieContainerHandle y) => !(x == y);

	    public static explicit operator HTTPCookieContainerHandle(uint value) => new HTTPCookieContainerHandle(value);

	    public static explicit operator uint(HTTPCookieContainerHandle that) => that.Handle;

	    public bool Equals(HTTPCookieContainerHandle other) => Handle == other.Handle;

	    public int CompareTo(HTTPCookieContainerHandle other) => Handle.CompareTo(other.Handle);
	}
}

// This file is provided under The MIT License as part of Steamworks.NET.
// Copyright (c) 2013-2015 Riley Labrecque
// Please see the included LICENSE.txt for additional information.

// Changes to this file will be reverted when you update Steamworks.NET

namespace Steamworks {
	public struct HTTPCookieContainerHandle : System.IEquatable<HTTPCookieContainerHandle>, System.IComparable<HTTPCookieContainerHandle> {
		public static readonly HTTPCookieContainerHandle Invalid = new HTTPCookieContainerHandle(0);
		public uint _HTTPCookieContainerHandle;

		public HTTPCookieContainerHandle(uint value) {
			_HTTPCookieContainerHandle = value;
		}

		public override string ToString() => _HTTPCookieContainerHandle.ToString();

	    public override bool Equals(object other) => other is HTTPCookieContainerHandle && this == (HTTPCookieContainerHandle)other;

	    public override int GetHashCode() => _HTTPCookieContainerHandle.GetHashCode();

	    public static bool operator ==(HTTPCookieContainerHandle x, HTTPCookieContainerHandle y) => x._HTTPCookieContainerHandle == y._HTTPCookieContainerHandle;

	    public static bool operator !=(HTTPCookieContainerHandle x, HTTPCookieContainerHandle y) => !(x == y);

	    public static explicit operator HTTPCookieContainerHandle(uint value) => new HTTPCookieContainerHandle(value);

	    public static explicit operator uint(HTTPCookieContainerHandle that) => that._HTTPCookieContainerHandle;

	    public bool Equals(HTTPCookieContainerHandle other) => _HTTPCookieContainerHandle == other._HTTPCookieContainerHandle;

	    public int CompareTo(HTTPCookieContainerHandle other) => _HTTPCookieContainerHandle.CompareTo(other._HTTPCookieContainerHandle);
	}
}

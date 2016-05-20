// This file is provided under The MIT License as part of Steamworks.NET.
// Copyright (c) 2013-2015 Riley Labrecque
// Please see the included LICENSE.txt for additional information.

// Changes to this file will be reverted when you update Steamworks.NET

namespace Steamworks {
	public struct HTTPRequestHandle : System.IEquatable<HTTPRequestHandle>, System.IComparable<HTTPRequestHandle> {
		public static readonly HTTPRequestHandle Invalid = new HTTPRequestHandle(0);
		public uint _HTTPRequestHandle;

		public HTTPRequestHandle(uint value) {
			_HTTPRequestHandle = value;
		}

		public override string ToString() => _HTTPRequestHandle.ToString();

	    public override bool Equals(object other) => other is HTTPRequestHandle && this == (HTTPRequestHandle)other;

	    public override int GetHashCode() => _HTTPRequestHandle.GetHashCode();

	    public static bool operator ==(HTTPRequestHandle x, HTTPRequestHandle y) => x._HTTPRequestHandle == y._HTTPRequestHandle;

	    public static bool operator !=(HTTPRequestHandle x, HTTPRequestHandle y) => !(x == y);

	    public static explicit operator HTTPRequestHandle(uint value) => new HTTPRequestHandle(value);

	    public static explicit operator uint(HTTPRequestHandle that) => that._HTTPRequestHandle;

	    public bool Equals(HTTPRequestHandle other) => _HTTPRequestHandle == other._HTTPRequestHandle;

	    public int CompareTo(HTTPRequestHandle other) => _HTTPRequestHandle.CompareTo(other._HTTPRequestHandle);
	}
}

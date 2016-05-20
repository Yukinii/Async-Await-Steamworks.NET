// This file is provided under The MIT License as part of Steamworks.NET.
// Copyright (c) 2013-2015 Riley Labrecque
// Please see the included LICENSE.txt for additional information.

// Changes to this file will be reverted when you update Steamworks.NET

namespace Steamworks {
	public struct ScreenshotHandle : System.IEquatable<ScreenshotHandle>, System.IComparable<ScreenshotHandle> {
		public static readonly ScreenshotHandle Invalid = new ScreenshotHandle(0);
	    public readonly uint Handle;

		public ScreenshotHandle(uint value) {
			Handle = value;
		}

		public override string ToString() => Handle.ToString();

	    public override bool Equals(object other) => other is ScreenshotHandle && this == (ScreenshotHandle)other;

	    public override int GetHashCode() => Handle.GetHashCode();

	    public static bool operator ==(ScreenshotHandle x, ScreenshotHandle y) => x.Handle == y.Handle;

	    public static bool operator !=(ScreenshotHandle x, ScreenshotHandle y) => !(x == y);

	    public static explicit operator ScreenshotHandle(uint value) => new ScreenshotHandle(value);

	    public static explicit operator uint(ScreenshotHandle that) => that.Handle;

	    public bool Equals(ScreenshotHandle other) => Handle == other.Handle;

	    public int CompareTo(ScreenshotHandle other) => Handle.CompareTo(other.Handle);
	}
}

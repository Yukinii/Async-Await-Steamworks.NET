// This file is provided under The MIT License as part of Steamworks.NET.
// Copyright (c) 2013-2015 Riley Labrecque
// Please see the included LICENSE.txt for additional information.

// Changes to this file will be reverted when you update Steamworks.NET

namespace Steamworks {
	public struct ControllerHandle : System.IEquatable<ControllerHandle>, System.IComparable<ControllerHandle> {
		public readonly ulong Handle;

		public ControllerHandle(ulong value) {
			Handle = value;
		}

		public override string ToString() => Handle.ToString();

	    public override bool Equals(object other) => other is ControllerHandle && this == (ControllerHandle)other;

	    public override int GetHashCode() => Handle.GetHashCode();

	    public static bool operator ==(ControllerHandle x, ControllerHandle y) => x.Handle == y.Handle;

	    public static bool operator !=(ControllerHandle x, ControllerHandle y) => !(x == y);

	    public static explicit operator ControllerHandle(ulong value) => new ControllerHandle(value);

	    public static explicit operator ulong(ControllerHandle that) => that.Handle;

	    public bool Equals(ControllerHandle other) => Handle == other.Handle;

	    public int CompareTo(ControllerHandle other) => Handle.CompareTo(other.Handle);
	}
}

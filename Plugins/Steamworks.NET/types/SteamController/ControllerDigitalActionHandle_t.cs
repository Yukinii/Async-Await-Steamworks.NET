// This file is provided under The MIT License as part of Steamworks.NET.
// Copyright (c) 2013-2015 Riley Labrecque
// Please see the included LICENSE.txt for additional information.

// Changes to this file will be reverted when you update Steamworks.NET

namespace Steamworks {
	public struct ControllerDigitalActionHandle : System.IEquatable<ControllerDigitalActionHandle>, System.IComparable<ControllerDigitalActionHandle> {
		public readonly ulong Handle;

		public ControllerDigitalActionHandle(ulong value) {
			Handle = value;
		}

		public override string ToString() => Handle.ToString();

	    public override bool Equals(object other) => other is ControllerDigitalActionHandle && this == (ControllerDigitalActionHandle)other;

	    public override int GetHashCode() => Handle.GetHashCode();

	    public static bool operator ==(ControllerDigitalActionHandle x, ControllerDigitalActionHandle y) => x.Handle == y.Handle;

	    public static bool operator !=(ControllerDigitalActionHandle x, ControllerDigitalActionHandle y) => !(x == y);

	    public static explicit operator ControllerDigitalActionHandle(ulong value) => new ControllerDigitalActionHandle(value);

	    public static explicit operator ulong(ControllerDigitalActionHandle that) => that.Handle;

	    public bool Equals(ControllerDigitalActionHandle other) => Handle == other.Handle;

	    public int CompareTo(ControllerDigitalActionHandle other) => Handle.CompareTo(other.Handle);
	}
}

// This file is provided under The MIT License as part of Steamworks.NET.
// Copyright (c) 2013-2015 Riley Labrecque
// Please see the included LICENSE.txt for additional information.

// Changes to this file will be reverted when you update Steamworks.NET

namespace Steamworks {
	public struct ControllerAnalogActionHandle : System.IEquatable<ControllerAnalogActionHandle>, System.IComparable<ControllerAnalogActionHandle> {
		public readonly ulong Handle;

		public ControllerAnalogActionHandle(ulong value) {
			Handle = value;
		}

		public override string ToString() => Handle.ToString();

	    public override bool Equals(object other) => other is ControllerAnalogActionHandle && this == (ControllerAnalogActionHandle)other;

	    public override int GetHashCode() => Handle.GetHashCode();

	    public static bool operator ==(ControllerAnalogActionHandle x, ControllerAnalogActionHandle y) => x.Handle == y.Handle;

	    public static bool operator !=(ControllerAnalogActionHandle x, ControllerAnalogActionHandle y) => !(x == y);

	    public static explicit operator ControllerAnalogActionHandle(ulong value) => new ControllerAnalogActionHandle(value);

	    public static explicit operator ulong(ControllerAnalogActionHandle that) => that.Handle;

	    public bool Equals(ControllerAnalogActionHandle other) => Handle == other.Handle;

	    public int CompareTo(ControllerAnalogActionHandle other) => Handle.CompareTo(other.Handle);
	}
}

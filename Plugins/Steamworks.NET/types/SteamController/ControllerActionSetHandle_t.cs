// This file is provided under The MIT License as part of Steamworks.NET.
// Copyright (c) 2013-2015 Riley Labrecque
// Please see the included LICENSE.txt for additional information.

// Changes to this file will be reverted when you update Steamworks.NET

namespace Steamworks {
	public struct ControllerActionSetHandle : System.IEquatable<ControllerActionSetHandle>, System.IComparable<ControllerActionSetHandle> {
		public readonly ulong Handle;

		public ControllerActionSetHandle(ulong value) {
			Handle = value;
		}

		public override string ToString() => Handle.ToString();

	    public override bool Equals(object other) => other is ControllerActionSetHandle && this == (ControllerActionSetHandle)other;

	    public override int GetHashCode() => Handle.GetHashCode();

	    public static bool operator ==(ControllerActionSetHandle x, ControllerActionSetHandle y) => x.Handle == y.Handle;

	    public static bool operator !=(ControllerActionSetHandle x, ControllerActionSetHandle y) => !(x == y);

	    public static explicit operator ControllerActionSetHandle(ulong value) => new ControllerActionSetHandle(value);

	    public static explicit operator ulong(ControllerActionSetHandle that) => that.Handle;

	    public bool Equals(ControllerActionSetHandle other) => Handle == other.Handle;

	    public int CompareTo(ControllerActionSetHandle other) => Handle.CompareTo(other.Handle);
	}
}

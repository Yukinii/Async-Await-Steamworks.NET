// This file is provided under The MIT License as part of Steamworks.NET.
// Copyright (c) 2013-2015 Riley Labrecque
// Please see the included LICENSE.txt for additional information.

// Changes to this file will be reverted when you update Steamworks.NET

namespace Steamworks {
	public struct ControllerActionSetHandle : System.IEquatable<ControllerActionSetHandle>, System.IComparable<ControllerActionSetHandle> {
		public ulong _ControllerActionSetHandle;

		public ControllerActionSetHandle(ulong value) {
			_ControllerActionSetHandle = value;
		}

		public override string ToString() => _ControllerActionSetHandle.ToString();

	    public override bool Equals(object other) => other is ControllerActionSetHandle && this == (ControllerActionSetHandle)other;

	    public override int GetHashCode() => _ControllerActionSetHandle.GetHashCode();

	    public static bool operator ==(ControllerActionSetHandle x, ControllerActionSetHandle y) => x._ControllerActionSetHandle == y._ControllerActionSetHandle;

	    public static bool operator !=(ControllerActionSetHandle x, ControllerActionSetHandle y) => !(x == y);

	    public static explicit operator ControllerActionSetHandle(ulong value) => new ControllerActionSetHandle(value);

	    public static explicit operator ulong(ControllerActionSetHandle that) => that._ControllerActionSetHandle;

	    public bool Equals(ControllerActionSetHandle other) => _ControllerActionSetHandle == other._ControllerActionSetHandle;

	    public int CompareTo(ControllerActionSetHandle other) => _ControllerActionSetHandle.CompareTo(other._ControllerActionSetHandle);
	}
}

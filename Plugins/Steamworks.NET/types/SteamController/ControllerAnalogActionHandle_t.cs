// This file is provided under The MIT License as part of Steamworks.NET.
// Copyright (c) 2013-2015 Riley Labrecque
// Please see the included LICENSE.txt for additional information.

// Changes to this file will be reverted when you update Steamworks.NET

namespace Steamworks {
	public struct ControllerAnalogActionHandle : System.IEquatable<ControllerAnalogActionHandle>, System.IComparable<ControllerAnalogActionHandle> {
		public ulong _ControllerAnalogActionHandle;

		public ControllerAnalogActionHandle(ulong value) {
			_ControllerAnalogActionHandle = value;
		}

		public override string ToString() => _ControllerAnalogActionHandle.ToString();

	    public override bool Equals(object other) => other is ControllerAnalogActionHandle && this == (ControllerAnalogActionHandle)other;

	    public override int GetHashCode() => _ControllerAnalogActionHandle.GetHashCode();

	    public static bool operator ==(ControllerAnalogActionHandle x, ControllerAnalogActionHandle y) => x._ControllerAnalogActionHandle == y._ControllerAnalogActionHandle;

	    public static bool operator !=(ControllerAnalogActionHandle x, ControllerAnalogActionHandle y) => !(x == y);

	    public static explicit operator ControllerAnalogActionHandle(ulong value) => new ControllerAnalogActionHandle(value);

	    public static explicit operator ulong(ControllerAnalogActionHandle that) => that._ControllerAnalogActionHandle;

	    public bool Equals(ControllerAnalogActionHandle other) => _ControllerAnalogActionHandle == other._ControllerAnalogActionHandle;

	    public int CompareTo(ControllerAnalogActionHandle other) => _ControllerAnalogActionHandle.CompareTo(other._ControllerAnalogActionHandle);
	}
}

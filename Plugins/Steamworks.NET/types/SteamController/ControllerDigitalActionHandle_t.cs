// This file is provided under The MIT License as part of Steamworks.NET.
// Copyright (c) 2013-2015 Riley Labrecque
// Please see the included LICENSE.txt for additional information.

// Changes to this file will be reverted when you update Steamworks.NET

namespace Steamworks {
	public struct ControllerDigitalActionHandle : System.IEquatable<ControllerDigitalActionHandle>, System.IComparable<ControllerDigitalActionHandle> {
		public ulong _ControllerDigitalActionHandle;

		public ControllerDigitalActionHandle(ulong value) {
			_ControllerDigitalActionHandle = value;
		}

		public override string ToString() => _ControllerDigitalActionHandle.ToString();

	    public override bool Equals(object other) => other is ControllerDigitalActionHandle && this == (ControllerDigitalActionHandle)other;

	    public override int GetHashCode() => _ControllerDigitalActionHandle.GetHashCode();

	    public static bool operator ==(ControllerDigitalActionHandle x, ControllerDigitalActionHandle y) => x._ControllerDigitalActionHandle == y._ControllerDigitalActionHandle;

	    public static bool operator !=(ControllerDigitalActionHandle x, ControllerDigitalActionHandle y) => !(x == y);

	    public static explicit operator ControllerDigitalActionHandle(ulong value) => new ControllerDigitalActionHandle(value);

	    public static explicit operator ulong(ControllerDigitalActionHandle that) => that._ControllerDigitalActionHandle;

	    public bool Equals(ControllerDigitalActionHandle other) => _ControllerDigitalActionHandle == other._ControllerDigitalActionHandle;

	    public int CompareTo(ControllerDigitalActionHandle other) => _ControllerDigitalActionHandle.CompareTo(other._ControllerDigitalActionHandle);
	}
}

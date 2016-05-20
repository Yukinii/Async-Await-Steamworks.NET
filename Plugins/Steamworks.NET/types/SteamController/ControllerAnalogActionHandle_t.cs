// This file is provided under The MIT License as part of Steamworks.NET.
// Copyright (c) 2013-2015 Riley Labrecque
// Please see the included LICENSE.txt for additional information.

// Changes to this file will be reverted when you update Steamworks.NET

namespace Steamworks {
	public struct ControllerAnalogActionHandle_t : System.IEquatable<ControllerAnalogActionHandle_t>, System.IComparable<ControllerAnalogActionHandle_t> {
		public ulong _ControllerAnalogActionHandle;

		public ControllerAnalogActionHandle_t(ulong value) {
			_ControllerAnalogActionHandle = value;
		}

		public override string ToString() => _ControllerAnalogActionHandle.ToString();

	    public override bool Equals(object other) => other is ControllerAnalogActionHandle_t && this == (ControllerAnalogActionHandle_t)other;

	    public override int GetHashCode() => _ControllerAnalogActionHandle.GetHashCode();

	    public static bool operator ==(ControllerAnalogActionHandle_t x, ControllerAnalogActionHandle_t y) => x._ControllerAnalogActionHandle == y._ControllerAnalogActionHandle;

	    public static bool operator !=(ControllerAnalogActionHandle_t x, ControllerAnalogActionHandle_t y) => !(x == y);

	    public static explicit operator ControllerAnalogActionHandle_t(ulong value) => new ControllerAnalogActionHandle_t(value);

	    public static explicit operator ulong(ControllerAnalogActionHandle_t that) => that._ControllerAnalogActionHandle;

	    public bool Equals(ControllerAnalogActionHandle_t other) => _ControllerAnalogActionHandle == other._ControllerAnalogActionHandle;

	    public int CompareTo(ControllerAnalogActionHandle_t other) => _ControllerAnalogActionHandle.CompareTo(other._ControllerAnalogActionHandle);
	}
}

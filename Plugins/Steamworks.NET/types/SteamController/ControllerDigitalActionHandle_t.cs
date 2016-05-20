// This file is provided under The MIT License as part of Steamworks.NET.
// Copyright (c) 2013-2015 Riley Labrecque
// Please see the included LICENSE.txt for additional information.

// Changes to this file will be reverted when you update Steamworks.NET

namespace Steamworks {
	public struct ControllerDigitalActionHandle_t : System.IEquatable<ControllerDigitalActionHandle_t>, System.IComparable<ControllerDigitalActionHandle_t> {
		public ulong _ControllerDigitalActionHandle;

		public ControllerDigitalActionHandle_t(ulong value) {
			_ControllerDigitalActionHandle = value;
		}

		public override string ToString() => _ControllerDigitalActionHandle.ToString();

	    public override bool Equals(object other) => other is ControllerDigitalActionHandle_t && this == (ControllerDigitalActionHandle_t)other;

	    public override int GetHashCode() => _ControllerDigitalActionHandle.GetHashCode();

	    public static bool operator ==(ControllerDigitalActionHandle_t x, ControllerDigitalActionHandle_t y) => x._ControllerDigitalActionHandle == y._ControllerDigitalActionHandle;

	    public static bool operator !=(ControllerDigitalActionHandle_t x, ControllerDigitalActionHandle_t y) => !(x == y);

	    public static explicit operator ControllerDigitalActionHandle_t(ulong value) => new ControllerDigitalActionHandle_t(value);

	    public static explicit operator ulong(ControllerDigitalActionHandle_t that) => that._ControllerDigitalActionHandle;

	    public bool Equals(ControllerDigitalActionHandle_t other) => _ControllerDigitalActionHandle == other._ControllerDigitalActionHandle;

	    public int CompareTo(ControllerDigitalActionHandle_t other) => _ControllerDigitalActionHandle.CompareTo(other._ControllerDigitalActionHandle);
	}
}

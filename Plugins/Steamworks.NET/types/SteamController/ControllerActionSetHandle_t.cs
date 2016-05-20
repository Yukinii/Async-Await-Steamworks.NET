// This file is provided under The MIT License as part of Steamworks.NET.
// Copyright (c) 2013-2015 Riley Labrecque
// Please see the included LICENSE.txt for additional information.

// Changes to this file will be reverted when you update Steamworks.NET

namespace Steamworks {
	public struct ControllerActionSetHandle_t : System.IEquatable<ControllerActionSetHandle_t>, System.IComparable<ControllerActionSetHandle_t> {
		public ulong _ControllerActionSetHandle;

		public ControllerActionSetHandle_t(ulong value) {
			_ControllerActionSetHandle = value;
		}

		public override string ToString() => _ControllerActionSetHandle.ToString();

	    public override bool Equals(object other) => other is ControllerActionSetHandle_t && this == (ControllerActionSetHandle_t)other;

	    public override int GetHashCode() => _ControllerActionSetHandle.GetHashCode();

	    public static bool operator ==(ControllerActionSetHandle_t x, ControllerActionSetHandle_t y) => x._ControllerActionSetHandle == y._ControllerActionSetHandle;

	    public static bool operator !=(ControllerActionSetHandle_t x, ControllerActionSetHandle_t y) => !(x == y);

	    public static explicit operator ControllerActionSetHandle_t(ulong value) => new ControllerActionSetHandle_t(value);

	    public static explicit operator ulong(ControllerActionSetHandle_t that) => that._ControllerActionSetHandle;

	    public bool Equals(ControllerActionSetHandle_t other) => _ControllerActionSetHandle == other._ControllerActionSetHandle;

	    public int CompareTo(ControllerActionSetHandle_t other) => _ControllerActionSetHandle.CompareTo(other._ControllerActionSetHandle);
	}
}

// This file is provided under The MIT License as part of Steamworks.NET.
// Copyright (c) 2013-2015 Riley Labrecque
// Please see the included LICENSE.txt for additional information.

// Changes to this file will be reverted when you update Steamworks.NET

namespace Steamworks {
	public struct ControllerHandle_t : System.IEquatable<ControllerHandle_t>, System.IComparable<ControllerHandle_t> {
		public ulong _ControllerHandle;

		public ControllerHandle_t(ulong value) {
			_ControllerHandle = value;
		}

		public override string ToString() => _ControllerHandle.ToString();

	    public override bool Equals(object other) => other is ControllerHandle_t && this == (ControllerHandle_t)other;

	    public override int GetHashCode() => _ControllerHandle.GetHashCode();

	    public static bool operator ==(ControllerHandle_t x, ControllerHandle_t y) => x._ControllerHandle == y._ControllerHandle;

	    public static bool operator !=(ControllerHandle_t x, ControllerHandle_t y) => !(x == y);

	    public static explicit operator ControllerHandle_t(ulong value) => new ControllerHandle_t(value);

	    public static explicit operator ulong(ControllerHandle_t that) => that._ControllerHandle;

	    public bool Equals(ControllerHandle_t other) => _ControllerHandle == other._ControllerHandle;

	    public int CompareTo(ControllerHandle_t other) => _ControllerHandle.CompareTo(other._ControllerHandle);
	}
}

// This file is provided under The MIT License as part of Steamworks.NET.
// Copyright (c) 2013-2015 Riley Labrecque
// Please see the included LICENSE.txt for additional information.

// Changes to this file will be reverted when you update Steamworks.NET

namespace Steamworks {
	public struct ControllerHandle : System.IEquatable<ControllerHandle>, System.IComparable<ControllerHandle> {
		public ulong _ControllerHandle;

		public ControllerHandle(ulong value) {
			_ControllerHandle = value;
		}

		public override string ToString() => _ControllerHandle.ToString();

	    public override bool Equals(object other) => other is ControllerHandle && this == (ControllerHandle)other;

	    public override int GetHashCode() => _ControllerHandle.GetHashCode();

	    public static bool operator ==(ControllerHandle x, ControllerHandle y) => x._ControllerHandle == y._ControllerHandle;

	    public static bool operator !=(ControllerHandle x, ControllerHandle y) => !(x == y);

	    public static explicit operator ControllerHandle(ulong value) => new ControllerHandle(value);

	    public static explicit operator ulong(ControllerHandle that) => that._ControllerHandle;

	    public bool Equals(ControllerHandle other) => _ControllerHandle == other._ControllerHandle;

	    public int CompareTo(ControllerHandle other) => _ControllerHandle.CompareTo(other._ControllerHandle);
	}
}

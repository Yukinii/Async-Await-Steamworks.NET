// This file is provided under The MIT License as part of Steamworks.NET.
// Copyright (c) 2013-2015 Riley Labrecque
// Please see the included LICENSE.txt for additional information.

// Changes to this file will be reverted when you update Steamworks.NET

namespace Steamworks {
	public struct ClientUnifiedMessageHandle : System.IEquatable<ClientUnifiedMessageHandle>, System.IComparable<ClientUnifiedMessageHandle> {
		public static readonly ClientUnifiedMessageHandle Invalid = new ClientUnifiedMessageHandle(0);
		public ulong _ClientUnifiedMessageHandle;

		public ClientUnifiedMessageHandle(ulong value) {
			_ClientUnifiedMessageHandle = value;
		}

		public override string ToString() => _ClientUnifiedMessageHandle.ToString();

	    public override bool Equals(object other) => other is ClientUnifiedMessageHandle && this == (ClientUnifiedMessageHandle)other;

	    public override int GetHashCode() => _ClientUnifiedMessageHandle.GetHashCode();

	    public static bool operator ==(ClientUnifiedMessageHandle x, ClientUnifiedMessageHandle y) => x._ClientUnifiedMessageHandle == y._ClientUnifiedMessageHandle;

	    public static bool operator !=(ClientUnifiedMessageHandle x, ClientUnifiedMessageHandle y) => !(x == y);

	    public static explicit operator ClientUnifiedMessageHandle(ulong value) => new ClientUnifiedMessageHandle(value);

	    public static explicit operator ulong(ClientUnifiedMessageHandle that) => that._ClientUnifiedMessageHandle;

	    public bool Equals(ClientUnifiedMessageHandle other) => _ClientUnifiedMessageHandle == other._ClientUnifiedMessageHandle;

	    public int CompareTo(ClientUnifiedMessageHandle other) => _ClientUnifiedMessageHandle.CompareTo(other._ClientUnifiedMessageHandle);
	}
}

// This file is provided under The MIT License as part of Steamworks.NET.
// Copyright (c) 2013-2015 Riley Labrecque
// Please see the included LICENSE.txt for additional information.

// Changes to this file will be reverted when you update Steamworks.NET

namespace Steamworks {
	public struct HServerListRequest : System.IEquatable<HServerListRequest> {
		public static readonly HServerListRequest Invalid = new HServerListRequest(System.IntPtr.Zero);
		public System.IntPtr _HServerListRequest;

		public HServerListRequest(System.IntPtr value) {
			_HServerListRequest = value;
		}

		public override string ToString() => _HServerListRequest.ToString();

	    public override bool Equals(object other) => other is HServerListRequest && this == (HServerListRequest)other;

	    public override int GetHashCode() => _HServerListRequest.GetHashCode();

	    public static bool operator ==(HServerListRequest x, HServerListRequest y) => x._HServerListRequest == y._HServerListRequest;

	    public static bool operator !=(HServerListRequest x, HServerListRequest y) => !(x == y);

	    public static explicit operator HServerListRequest(System.IntPtr value) => new HServerListRequest(value);

	    public static explicit operator System.IntPtr(HServerListRequest that) => that._HServerListRequest;

	    public bool Equals(HServerListRequest other) => _HServerListRequest == other._HServerListRequest;
	}
}

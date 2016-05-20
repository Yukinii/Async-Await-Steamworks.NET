// This file is provided under The MIT License as part of Steamworks.NET.
// Copyright (c) 2013-2015 Riley Labrecque
// Please see the included LICENSE.txt for additional information.

// Changes to this file will be reverted when you update Steamworks.NET

namespace Steamworks {
	public struct HServerListRequest : System.IEquatable<HServerListRequest> {
		public static readonly HServerListRequest Invalid = new HServerListRequest(System.IntPtr.Zero);
		public readonly System.IntPtr ListRequest;

		public HServerListRequest(System.IntPtr value) {
			ListRequest = value;
		}

		public override string ToString() => ListRequest.ToString();

	    public override bool Equals(object other) => other is HServerListRequest && this == (HServerListRequest)other;

	    public override int GetHashCode() => ListRequest.GetHashCode();

	    public static bool operator ==(HServerListRequest x, HServerListRequest y) => x.ListRequest == y.ListRequest;

	    public static bool operator !=(HServerListRequest x, HServerListRequest y) => !(x == y);

	    public static explicit operator HServerListRequest(System.IntPtr value) => new HServerListRequest(value);

	    public static explicit operator System.IntPtr(HServerListRequest that) => that.ListRequest;

	    public bool Equals(HServerListRequest other) => ListRequest == other.ListRequest;
	}
}

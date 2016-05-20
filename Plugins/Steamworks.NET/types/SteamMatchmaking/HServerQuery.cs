// This file is provided under The MIT License as part of Steamworks.NET.
// Copyright (c) 2013-2015 Riley Labrecque
// Please see the included LICENSE.txt for additional information.

// Changes to this file will be reverted when you update Steamworks.NET

namespace Steamworks {
	public struct HServerQuery : System.IEquatable<HServerQuery>, System.IComparable<HServerQuery> {
		public static readonly HServerQuery Invalid = new HServerQuery(-1);
		public readonly int Query;

		public HServerQuery(int value) {
			Query = value;
		}

		public override string ToString() => Query.ToString();

	    public override bool Equals(object other) => other is HServerQuery && this == (HServerQuery)other;

	    public override int GetHashCode() => Query.GetHashCode();

	    public static bool operator ==(HServerQuery x, HServerQuery y) => x.Query == y.Query;

	    public static bool operator !=(HServerQuery x, HServerQuery y) => !(x == y);

	    public static explicit operator HServerQuery(int value) => new HServerQuery(value);

	    public static explicit operator int(HServerQuery that) => that.Query;

	    public bool Equals(HServerQuery other) => Query == other.Query;

	    public int CompareTo(HServerQuery other) => Query.CompareTo(other.Query);
	}
}

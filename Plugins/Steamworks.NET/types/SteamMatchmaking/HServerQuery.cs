// This file is provided under The MIT License as part of Steamworks.NET.
// Copyright (c) 2013-2015 Riley Labrecque
// Please see the included LICENSE.txt for additional information.

// Changes to this file will be reverted when you update Steamworks.NET

namespace Steamworks {
	public struct HServerQuery : System.IEquatable<HServerQuery>, System.IComparable<HServerQuery> {
		public static readonly HServerQuery Invalid = new HServerQuery(-1);
		public int _HServerQuery;

		public HServerQuery(int value) {
			_HServerQuery = value;
		}

		public override string ToString() => _HServerQuery.ToString();

	    public override bool Equals(object other) => other is HServerQuery && this == (HServerQuery)other;

	    public override int GetHashCode() => _HServerQuery.GetHashCode();

	    public static bool operator ==(HServerQuery x, HServerQuery y) => x._HServerQuery == y._HServerQuery;

	    public static bool operator !=(HServerQuery x, HServerQuery y) => !(x == y);

	    public static explicit operator HServerQuery(int value) => new HServerQuery(value);

	    public static explicit operator int(HServerQuery that) => that._HServerQuery;

	    public bool Equals(HServerQuery other) => _HServerQuery == other._HServerQuery;

	    public int CompareTo(HServerQuery other) => _HServerQuery.CompareTo(other._HServerQuery);
	}
}

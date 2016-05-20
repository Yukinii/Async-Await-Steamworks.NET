// This file is provided under The MIT License as part of Steamworks.NET.
// Copyright (c) 2013-2015 Riley Labrecque
// Please see the included LICENSE.txt for additional information.

// Changes to this file will be reverted when you update Steamworks.NET

namespace Steamworks {
	public struct AccountId : System.IEquatable<AccountId>, System.IComparable<AccountId> {
	    public readonly uint Id;

		public AccountId(uint value) {
			Id = value;
		}

		public override string ToString() => Id.ToString();

	    public override bool Equals(object other) => other is AccountId && this == (AccountId)other;

	    public override int GetHashCode() => Id.GetHashCode();

	    public static bool operator ==(AccountId x, AccountId y) => x.Id == y.Id;

	    public static bool operator !=(AccountId x, AccountId y) => !(x == y);

	    public static explicit operator AccountId(uint value) => new AccountId(value);

	    public static explicit operator uint(AccountId that) => that.Id;

	    public bool Equals(AccountId other) => Id == other.Id;

	    public int CompareTo(AccountId other) => Id.CompareTo(other.Id);
	}
}

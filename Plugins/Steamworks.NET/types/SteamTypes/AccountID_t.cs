// This file is provided under The MIT License as part of Steamworks.NET.
// Copyright (c) 2013-2015 Riley Labrecque
// Please see the included LICENSE.txt for additional information.

// Changes to this file will be reverted when you update Steamworks.NET

namespace Steamworks {
	public struct AccountID_t : System.IEquatable<AccountID_t>, System.IComparable<AccountID_t> {
		public uint _AccountID;

		public AccountID_t(uint value) {
			_AccountID = value;
		}

		public override string ToString() => _AccountID.ToString();

	    public override bool Equals(object other) => other is AccountID_t && this == (AccountID_t)other;

	    public override int GetHashCode() => _AccountID.GetHashCode();

	    public static bool operator ==(AccountID_t x, AccountID_t y) => x._AccountID == y._AccountID;

	    public static bool operator !=(AccountID_t x, AccountID_t y) => !(x == y);

	    public static explicit operator AccountID_t(uint value) => new AccountID_t(value);

	    public static explicit operator uint(AccountID_t that) => that._AccountID;

	    public bool Equals(AccountID_t other) => _AccountID == other._AccountID;

	    public int CompareTo(AccountID_t other) => _AccountID.CompareTo(other._AccountID);
	}
}

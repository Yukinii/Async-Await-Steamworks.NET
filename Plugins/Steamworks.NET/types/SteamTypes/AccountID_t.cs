// This file is provided under The MIT License as part of Steamworks.NET.
// Copyright (c) 2013-2015 Riley Labrecque
// Please see the included LICENSE.txt for additional information.

// Changes to this file will be reverted when you update Steamworks.NET

namespace Steamworks {
	public struct AccountID : System.IEquatable<AccountID>, System.IComparable<AccountID> {
		public uint _AccountID;

		public AccountID(uint value) {
			_AccountID = value;
		}

		public override string ToString() => _AccountID.ToString();

	    public override bool Equals(object other) => other is AccountID && this == (AccountID)other;

	    public override int GetHashCode() => _AccountID.GetHashCode();

	    public static bool operator ==(AccountID x, AccountID y) => x._AccountID == y._AccountID;

	    public static bool operator !=(AccountID x, AccountID y) => !(x == y);

	    public static explicit operator AccountID(uint value) => new AccountID(value);

	    public static explicit operator uint(AccountID that) => that._AccountID;

	    public bool Equals(AccountID other) => _AccountID == other._AccountID;

	    public int CompareTo(AccountID other) => _AccountID.CompareTo(other._AccountID);
	}
}

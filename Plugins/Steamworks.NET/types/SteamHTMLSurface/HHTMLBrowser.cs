// This file is provided under The MIT License as part of Steamworks.NET.
// Copyright (c) 2013-2015 Riley Labrecque
// Please see the included LICENSE.txt for additional information.

// Changes to this file will be reverted when you update Steamworks.NET

namespace Steamworks {
	public struct HHTMLBrowser : System.IEquatable<HHTMLBrowser>, System.IComparable<HHTMLBrowser> {
		public static readonly HHTMLBrowser Invalid = new HHTMLBrowser(0);
		public uint _HHTMLBrowser;

		public HHTMLBrowser(uint value) {
			_HHTMLBrowser = value;
		}

		public override string ToString() => _HHTMLBrowser.ToString();

	    public override bool Equals(object other) => other is HHTMLBrowser && this == (HHTMLBrowser)other;

	    public override int GetHashCode() => _HHTMLBrowser.GetHashCode();

	    public static bool operator ==(HHTMLBrowser x, HHTMLBrowser y) => x._HHTMLBrowser == y._HHTMLBrowser;

	    public static bool operator !=(HHTMLBrowser x, HHTMLBrowser y) => !(x == y);

	    public static explicit operator HHTMLBrowser(uint value) => new HHTMLBrowser(value);

	    public static explicit operator uint(HHTMLBrowser that) => that._HHTMLBrowser;

	    public bool Equals(HHTMLBrowser other) => _HHTMLBrowser == other._HHTMLBrowser;

	    public int CompareTo(HHTMLBrowser other) => _HHTMLBrowser.CompareTo(other._HHTMLBrowser);
	}
}

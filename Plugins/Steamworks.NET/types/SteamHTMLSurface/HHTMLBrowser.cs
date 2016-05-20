// This file is provided under The MIT License as part of Steamworks.NET.
// Copyright (c) 2013-2015 Riley Labrecque
// Please see the included LICENSE.txt for additional information.

// Changes to this file will be reverted when you update Steamworks.NET

namespace Steamworks {
	public struct HHTMLBrowser : System.IEquatable<HHTMLBrowser>, System.IComparable<HHTMLBrowser> {
		public static readonly HHTMLBrowser Invalid = new HHTMLBrowser(0);
		public readonly uint Browser;

		public HHTMLBrowser(uint value) {
			Browser = value;
		}

		public override string ToString() => Browser.ToString();

	    public override bool Equals(object other) => other is HHTMLBrowser && this == (HHTMLBrowser)other;

	    public override int GetHashCode() => Browser.GetHashCode();

	    public static bool operator ==(HHTMLBrowser x, HHTMLBrowser y) => x.Browser == y.Browser;

	    public static bool operator !=(HHTMLBrowser x, HHTMLBrowser y) => !(x == y);

	    public static explicit operator HHTMLBrowser(uint value) => new HHTMLBrowser(value);

	    public static explicit operator uint(HHTMLBrowser that) => that.Browser;

	    public bool Equals(HHTMLBrowser other) => Browser == other.Browser;

	    public int CompareTo(HHTMLBrowser other) => Browser.CompareTo(other.Browser);
	}
}

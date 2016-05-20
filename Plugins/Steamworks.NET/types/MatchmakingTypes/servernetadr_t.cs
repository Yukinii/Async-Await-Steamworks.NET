// This file is provided under The MIT License as part of Steamworks.NET.
// Copyright (c) 2013-2015 Riley Labrecque
// Please see the included LICENSE.txt for additional information.

// Changes to this file will be reverted when you update Steamworks.NET

namespace Steamworks {
	// servernetadr is all the addressing info the serverbrowser needs to know about a game server,
	// namely: its IP, its connection port, and its query port.
	//[StructLayout(LayoutKind.Sequential)]
	public struct servernetadr {
		private ushort _usConnectionPort;	// (in HOST byte order)
		private ushort _usQueryPort;
		private uint _unIP;

		public void Init(uint ip, ushort usQueryPort, ushort usConnectionPort) {
			_unIP = ip;
			_usQueryPort = usQueryPort;
			_usConnectionPort = usConnectionPort;
		}

#if NETADR_H
		public netadr GetIPAndQueryPort() {
			return netadr( _unIP, _usQueryPort );
		}
#endif
		
		// Access the query port.
		public ushort GetQueryPort() => _usQueryPort;

	    public void SetQueryPort(ushort usPort) {
			_usQueryPort = usPort;
		}

		// Access the connection port.
		public ushort GetConnectionPort() => _usConnectionPort;

	    public void SetConnectionPort(ushort usPort) {
			_usConnectionPort = usPort;
		}

		// Access the IP
		public uint GetIP() => _unIP;

	    public void SetIP(uint unIP) {
			_unIP = unIP;
		}

		// This gets the 'a.b.c.d:port' string with the connection port (instead of the query port).
		public string GetConnectionAddressString() => ToString(_unIP, _usConnectionPort);

	    public string GetQueryAddressString() => ToString(_unIP, _usQueryPort);

	    public static string ToString(uint unIP, ushort usPort) {
#if VALVE_BIG_ENDIAN
		return string.Format("{0}.{1}.{2}.{3}:{4}", unIP & 0xFFul, (unIP >> 8) & 0xFFul, (unIP >> 16) & 0xFFul, (unIP >> 24) & 0xFFul, usPort);
#else
		return $"{(unIP >> 24) & 0xFFul}.{(unIP >> 16) & 0xFFul}.{(unIP >> 8) & 0xFFul}.{unIP & 0xFFul}:{usPort}";
#endif
		}

		public static bool operator <(servernetadr x, servernetadr y) => (x._unIP < y._unIP) || (x._unIP == y._unIP && x._usQueryPort < y._usQueryPort);

	    public static bool operator >(servernetadr x, servernetadr y) => (x._unIP > y._unIP) || (x._unIP == y._unIP && x._usQueryPort > y._usQueryPort);

	    public override bool Equals(object other) => other is servernetadr && this == (servernetadr)other;

	    public override int GetHashCode() => _unIP.GetHashCode() + _usQueryPort.GetHashCode() + _usConnectionPort.GetHashCode();

	    public static bool operator ==(servernetadr x, servernetadr y) => (x._unIP == y._unIP) && (x._usQueryPort == y._usQueryPort) && (x._usConnectionPort == y._usConnectionPort);

	    public static bool operator !=(servernetadr x, servernetadr y) => !(x == y);

	    public bool Equals(servernetadr other) => (_unIP == other._unIP) && (_usQueryPort == other._usQueryPort) && (_usConnectionPort == other._usConnectionPort);

	    public int CompareTo(servernetadr other) => _unIP.CompareTo(other._unIP) + _usQueryPort.CompareTo(other._usQueryPort) + _usConnectionPort.CompareTo(other._usConnectionPort);
	}
}

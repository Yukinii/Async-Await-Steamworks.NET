// This file is provided under The MIT License as part of Steamworks.NET.
// Copyright (c) 2013-2015 Riley Labrecque
// Please see the included LICENSE.txt for additional information.

// Changes to this file will be reverted when you update Steamworks.NET

namespace Steamworks {
	// servernetadr is all the addressing info the serverbrowser needs to know about a game server,
	// namely: its IP, its connection port, and its query port.
	//[StructLayout(LayoutKind.Sequential)]
	public struct servernetadr {
		private ushort _ConnectionPort;	// (in HOST byte order)
		private ushort _QueryPort;
		private uint _Ip;

		public void Init(uint ip, ushort usQueryPort, ushort usConnectionPort) {
			_Ip = ip;
			_QueryPort = usQueryPort;
			_ConnectionPort = usConnectionPort;
		}

#if NETADR_H
		public netadr GetIPAndQueryPort() {
			return netadr( _unIP, _QueryPort );
		}
#endif
		
		// Access the query port.
		public ushort GetQueryPort() => _QueryPort;

	    public void SetQueryPort(ushort usPort) {
			_QueryPort = usPort;
		}

		// Access the connection port.
		public ushort GetConnectionPort() => _ConnectionPort;

	    public void SetConnectionPort(ushort usPort) {
			_ConnectionPort = usPort;
		}

		// Access the IP
		public uint GetIp() => _Ip;

	    public void SetIp(uint ip) {
			_Ip = ip;
		}

		// This gets the 'a.b.c.d:port' string with the connection port (instead of the query port).
		public string GetConnectionAddressString() => ToString(_Ip, _ConnectionPort);

	    public string GetQueryAddressString() => ToString(_Ip, _QueryPort);

	    public static string ToString(uint ip, ushort usPort) {
#if VALVE_BIG_ENDIAN
		return string.Format("{0}.{1}.{2}.{3}:{4}", ip & 0xFFul, (ip >> 8) & 0xFFul, (ip >> 16) & 0xFFul, (ip >> 24) & 0xFFul, usPort);
#else
		return $"{(ip >> 24) & 0xFFul}.{(ip >> 16) & 0xFFul}.{(ip >> 8) & 0xFFul}.{ip & 0xFFul}:{usPort}";
#endif
		}

		public static bool operator <(servernetadr x, servernetadr y) => (x._Ip < y._Ip) || (x._Ip == y._Ip && x._QueryPort < y._QueryPort);

	    public static bool operator >(servernetadr x, servernetadr y) => (x._Ip > y._Ip) || (x._Ip == y._Ip && x._QueryPort > y._QueryPort);

	    public override bool Equals(object other) => other is servernetadr && this == (servernetadr)other;

	    public override int GetHashCode() => _Ip.GetHashCode() + _QueryPort.GetHashCode() + _ConnectionPort.GetHashCode();

	    public static bool operator ==(servernetadr x, servernetadr y) => (x._Ip == y._Ip) && (x._QueryPort == y._QueryPort) && (x._ConnectionPort == y._ConnectionPort);

	    public static bool operator !=(servernetadr x, servernetadr y) => !(x == y);

	    public bool Equals(servernetadr other) => (_Ip == other._Ip) && (_QueryPort == other._QueryPort) && (_ConnectionPort == other._ConnectionPort);

	    public int CompareTo(servernetadr other) => _Ip.CompareTo(other._Ip) + _QueryPort.CompareTo(other._QueryPort) + _ConnectionPort.CompareTo(other._ConnectionPort);
	}
}

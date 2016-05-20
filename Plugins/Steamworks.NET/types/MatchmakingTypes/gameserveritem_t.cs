// This file is provided under The MIT License as part of Steamworks.NET.
// Copyright (c) 2013-2015 Riley Labrecque
// Please see the included LICENSE.txt for additional information.

// Changes to this file will be reverted when you update Steamworks.NET

using System.Runtime.InteropServices;
using System.Text;

namespace Steamworks {
	//-----------------------------------------------------------------------------
	// Purpose: Data describing a single server
	//-----------------------------------------------------------------------------
	[StructLayout(LayoutKind.Sequential, Size = 372, Pack = 4)]
	public class gameserverite {
		public string GetGameDir() => Encoding.UTF8.GetString(_szGameDir, 0, System.Array.IndexOf<byte>(_szGameDir, 0));

	    public void SetGameDir(string dir) {
			_szGameDir = Encoding.UTF8.GetBytes(dir + '\0');
		}

		public string GetMap() => Encoding.UTF8.GetString(_szMap, 0, System.Array.IndexOf<byte>(_szMap, 0));

	    public void SetMap(string map) {
			_szMap = Encoding.UTF8.GetBytes(map + '\0');
		}

		public string GetGameDescription() => Encoding.UTF8.GetString(_szGameDescription, 0, System.Array.IndexOf<byte>(_szGameDescription, 0));

	    public void SetGameDescription(string desc) {
			_szGameDescription = Encoding.UTF8.GetBytes(desc + '\0');
		}

		public string GetServerName() => _szServerName[0] == 0 ? _NetAdr.GetConnectionAddressString() : Encoding.UTF8.GetString(_szServerName, 0, System.Array.IndexOf<byte>(_szServerName, 0));

	    public void SetServerName(string name) {
			_szServerName = Encoding.UTF8.GetBytes(name + '\0');
		}

		public string GetGameTags() => Encoding.UTF8.GetString(_szGameTags, 0, System.Array.IndexOf<byte>(_szGameTags, 0));

	    public void SetGameTags(string tags) {
			_szGameTags = Encoding.UTF8.GetBytes(tags + '\0');
		}

		public servernetadr _NetAdr;								
		public int Ping;											
		[MarshalAs(UnmanagedType.I1)]
		public bool HadSuccessfulResponse;						
		[MarshalAs(UnmanagedType.I1)]
		public bool DoNotRefresh;									  
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = Constants.MaxGameServerGameDir)]
		private byte[] _szGameDir;										
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = Constants.MaxGameServerMapName)]
		private byte[] _szMap;												
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = Constants.MaxGameServerGameDescription)]
		private byte[] _szGameDescription;								
		public uint _appId;												
		public int Players;											
		public int MaxPlayers;										
		public int BotPlayers;										
		[MarshalAs(UnmanagedType.I1)]
		public bool Password;											
		[MarshalAs(UnmanagedType.I1)]
		public bool Secure;											
		public uint TimeLastPlayed;									
		public int	ServerVersion;									                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                   

		// Game server name
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = Constants.MaxGameServerName)]
		private byte[] _szServerName;

		// the tags this server exposes
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = Constants.MaxGameServerTags)]
		private byte[] _szGameTags;

		// steamID of the game server - invalid if it's doesn't have one (old server, or not connected to Steam)
		public SteamId _steamID;
	}
}

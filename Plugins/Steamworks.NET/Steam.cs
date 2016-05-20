// This file is provided under The MIT License as part of Steamworks.NET.
// Copyright (c) 2013-2015 Riley Labrecque
// Please see the included LICENSE.txt for additional information.

// Changes to this file will be reverted when you update Steamworks.NET

#define VERSION_SAFE_STEAM_API_INTERFACES

namespace Steamworks {
	public static class Version {
		public const string SteamworksNetVersion = "9.0.0";
		public const string SteamworksSdkVersion = "1.36";
		public const string SteamApidllVersion = "03.27.76.74";
		public const int SteamApidllSize = 217168;
		public const int SteamAPI64DllSize = 239184;
	}

	public static class SteamAPI {
		//----------------------------------------------------------------------------------------------------------------------------------------------------------//
		//	Steam API setup & shutdown
		//
		//	These functions manage loading, initializing and shutdown of the steamclient.dll
		//
		//----------------------------------------------------------------------------------------------------------------------------------------------------------//

		// Detects if your executable was launched through the Steam client, and restarts your game through
		// the client if necessary. The Steam client will be started if it is not running.
		//
		// Returns: true if your executable was NOT launched through the Steam client. This function will
		//          then start your application through the client. Your current process should exit.
		//
		//          false if your executable was started through the Steam client or a stea_appid.txt file
		//          is present in your game's directory (for development). Your current process should continue.
		//
		// NOTE: This function should be used only if you are using CEG or not using Steam's DRM. Once applied
		//       to your executable, Steam's DRM will handle restarting through Steam if necessary.
		public static bool RestartAppIfNecessary(AppId unOwappId) {
			InteropHelp.TestIfPlatformSupported();
			return NativeMethods.SteamAPI_RestartAppIfNecessary(unOwappId);
		}

#if VERSION_SAFE_STEAM_API_INTERFACES
		public static bool InitSafe() => Init();

	    // [Steamworks.NET] This is for Ease of use, since we don't need to care about the differences between them in C#.
		public static bool Init() {
			InteropHelp.TestIfPlatformSupported();
			return NativeMethods.SteamAPI_InitSafe();
		}
#else
		public static bool Init() {
			InteropHelp.TestIfPlatformSupported();
			return NativeMethods.SteamAPI_Init();
		}
#endif

		public static void Shutdown() {
			InteropHelp.TestIfPlatformSupported();
			NativeMethods.SteamAPI_Shutdown();
		}

		// Most Steam API functions allocate some amount of thread-local memory for
		// parameter storage. The SteamAPI_ReleaseCurrentThreadMemory() function
		// will free all API-related memory associated with the calling thread.
		// This memory is also released automatically by SteamAPI_RunCallbacks(), so
		// a single-threaded program does not need to explicitly call this function.
		public static void ReleaseCurrentThreadMemory() {
			InteropHelp.TestIfPlatformSupported();
			NativeMethods.SteamAPI_ReleaseCurrentThreadMemory();
		}

		//----------------------------------------------------------------------------------------------------------------------------------------------------------//
		//	steam callback and call-result helpers
		//
		//	The following macros and classes are used to register your application for
		//	callbacks and call-results, which are delivered in a predictable manner.
		//
		//	STEAM_CALLBACK macros are meant for use inside of a C++ class definition.
		//	They map a Steam notification callback directly to a class member function
		//	which is automatically prototyped as "void func( callbactype *pParam )".
		//
		//	CCallResult is used with specific Steam APIs that return "result handles".
		//	The handle can be passed to a CCallResult object's Set function, along with
		//	an object pointer and member-function pointer. The member function will
		//	be executed once the results of the Steam API call are available.
		//
		//	CCallback and CCallbackManual classes can be used instead of STEAM_CALLBACK
		//	macros if you require finer control over registration and unregistration.
		//
		//	Callbacks and call-results are queued automatically and are only
		//	delivered/executed when your application calls SteamAPI_RunCallbacks().
		//----------------------------------------------------------------------------------------------------------------------------------------------------------//

		// SteamAPI_RunCallbacks is safe to call from multiple threads simultaneously,
		// but if you choose to do this, callback code may be executed on any thread.
		public static void RunCallbacks() {
			InteropHelp.TestIfPlatformSupported();
			NativeMethods.SteamAPI_RunCallbacks();
		}

		// checks if a local Steam client is running
		public static bool IsSteamRunning() {
			InteropHelp.TestIfPlatformSupported();
			return NativeMethods.SteamAPI_IsSteamRunning();
		}

		// returns the HSteamUser of the last user to dispatch a callback
		public static HSteamUser GetHSteamUserCurrent() {
			InteropHelp.TestIfPlatformSupported();
			return (HSteamUser)NativeMethods.Stea_GetHSteamUserCurrent();
		}
		
		// returns the pipe we are communicating to Steam with
		public static HSteamPipe GetHSteamPipe() {
			InteropHelp.TestIfPlatformSupported();
			return (HSteamPipe)NativeMethods.SteamAPI_GetHSteamPipe();
		}

		public static HSteamUser GetHSteamUser() {
			InteropHelp.TestIfPlatformSupported();
			return (HSteamUser)NativeMethods.SteamAPI_GetHSteamUser();
		}
	}

	public static class GameServer {
		// Initialize ISteamGameServer interface object, and set server properties which may not be changed.
		//
		// After calling this function, you should set any additional server parameters, and then
		// call ISteamGameServer::LogOnAnonymous() or ISteamGameServer::LogOn()
		//
		// - usSteamPort is the local port used to communicate with the steam servers.
		// - usGamePort is the port that clients will connect to for gameplay.
		// - usQueryPort is the port that will manage server browser related duties and info
		//		pings from clients.  If you pass MASTERSERVERUPDATERPORT_USEGAMESOCKETSHARE for usQueryPort, then it
		//		will use "GameSocketShare" mode, which means that the game is responsible for sending and receiving
		//		UDP packets for the master  server updater. See references to GameSocketShare in isteamgameserver.h.
		// - The version string is usually in the form x.x.x.x, and is used by the master server to detect when the
		//		server is out of date.  (Only servers with the latest version will be listed.)
#if VERSION_SAFE_STEAM_API_INTERFACES
		public static bool InitSafe(uint ip, ushort usSteamPort, ushort usGamePort, ushort usQueryPort, EServerMode eServerMode, string versionString) {
			InteropHelp.TestIfPlatformSupported();
			using (var versionString2 = new InteropHelp.UTF8StringHandle(versionString)) {
				return NativeMethods.SteamGameServer_InitSafe(ip, usSteamPort, usGamePort, usQueryPort, eServerMode, versionString2);
			}
		}

		// [Steamworks.NET] This is for Ease of use, since we don't need to care about the differences between them in C#.
		public static bool Init(uint ip, ushort usSteamPort, ushort usGamePort, ushort usQueryPort, EServerMode eServerMode, string versionString) => InitSafe(ip, usSteamPort, usGamePort, usQueryPort, eServerMode, versionString);
#else
		public static bool Init(uint ip, ushort usSteamPort, ushort usGamePort, ushort usQueryPort, EServerMode eServerMode, string VersionString) {
			InteropHelp.TestIfPlatformSupported();
			using (var VersionString2 = new InteropHelp.UTF8StringHandle(VersionString)) {
				return NativeMethods.SteamGameServer_Init(ip, usSteamPort, usGamePort, usQueryPort, eServerMode, VersionString2);
		`	}
		}
#endif
		public static void Shutdown() {
			InteropHelp.TestIfPlatformSupported();
			NativeMethods.SteamGameServer_Shutdown();
		}

		public static void RunCallbacks() {
			InteropHelp.TestIfPlatformSupported();
			NativeMethods.SteamGameServer_RunCallbacks();
		}

		public static bool BSecure() {
			InteropHelp.TestIfPlatformSupported();
			return NativeMethods.SteamGameServer_BSecure();
		}

		public static SteamId GetSteamId() {
			InteropHelp.TestIfPlatformSupported();
			return (SteamId)NativeMethods.SteamGameServer_GetSteamID();
		}

		public static HSteamPipe GetHSteamPipe() {
			InteropHelp.TestIfPlatformSupported();
			return (HSteamPipe)NativeMethods.SteamGameServer_GetHSteamPipe();
		}

		public static HSteamUser GetHSteamUser() {
			InteropHelp.TestIfPlatformSupported();
			return (HSteamUser)NativeMethods.SteamGameServer_GetHSteamUser();
		}
	}

	public static class SteamEncryptedAppTicket {
		public static bool BDecryptTicket(byte[] rgubTicketEncrypted, uint ticketEncrypted, byte[] rgubTicketDecrypted, ref uint pcubTicketDecrypted, byte[] rgubKey, int key) {
			InteropHelp.TestIfPlatformSupported();
			return NativeMethods.BDecryptTicket(rgubTicketEncrypted, ticketEncrypted, rgubTicketDecrypted, ref pcubTicketDecrypted, rgubKey, key);
		}

		public static bool BIsTicketForApp(byte[] rgubTicketDecrypted, uint ticketDecrypted, AppId appId) {
			InteropHelp.TestIfPlatformSupported();
			return NativeMethods.BIsTicketForApp(rgubTicketDecrypted, ticketDecrypted, appId);
		}

		public static uint GetTicketIssueTime(byte[] rgubTicketDecrypted, uint ticketDecrypted) {
			InteropHelp.TestIfPlatformSupported();
			return NativeMethods.GetTicketIssueTime(rgubTicketDecrypted, ticketDecrypted);
		}

		public static void GetTicketSteamId(byte[] rgubTicketDecrypted, uint ticketDecrypted, out SteamId steamId) {
			InteropHelp.TestIfPlatformSupported();
			NativeMethods.GetTicketSteamID(rgubTicketDecrypted, ticketDecrypted, out steamId);
		}

		public static uint GetTicketAppId(byte[] rgubTicketDecrypted, uint ticketDecrypted) {
			InteropHelp.TestIfPlatformSupported();
			return NativeMethods.GetTicketAppID(rgubTicketDecrypted, ticketDecrypted);
		}

		public static bool BUserOwnsAppInTicket(byte[] rgubTicketDecrypted, uint ticketDecrypted, AppId appId) {
			InteropHelp.TestIfPlatformSupported();
			return NativeMethods.BUserOwnsAppInTicket(rgubTicketDecrypted, ticketDecrypted, appId);
		}

		public static bool BUserIsVacBanned(byte[] rgubTicketDecrypted, uint ticketDecrypted) {
			InteropHelp.TestIfPlatformSupported();
			return NativeMethods.BUserIsVacBanned(rgubTicketDecrypted, ticketDecrypted);
		}

		public static byte[] GetUserVariableData(byte[] rgubTicketDecrypted, uint ticketDecrypted, out uint pcubUserData) {
			InteropHelp.TestIfPlatformSupported();
			var punSecretData = NativeMethods.GetUserVariableData(rgubTicketDecrypted, ticketDecrypted, out pcubUserData);
			var ret = new byte[pcubUserData];
			System.Runtime.InteropServices.Marshal.Copy(punSecretData, ret, 0, (int)pcubUserData);
			return ret;
		}
	}
}

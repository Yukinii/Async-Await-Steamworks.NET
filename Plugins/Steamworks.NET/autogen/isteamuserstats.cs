// This file is provided under The MIT License as part of Steamworks.NET.
// Copyright (c) 2013-2015 Riley Labrecque
// Please see the included LICENSE.txt for additional information.

// This file is automatically generated.
// Changes to this file will be reverted when you update Steamworks.NET

using System.Runtime.InteropServices;

namespace Steamworks {
	public static class SteamUserStats {
		/// <summary>
		/// <para> Ask the server to send down this user's data and achievements for this game</para>
		/// </summary>
		public static bool RequestCurrentStats() {
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUserStats_RequestCurrentStats();
		}

		/// <summary>
		/// <para> Data accessors</para>
		/// </summary>
		public static bool GetStat(string name, out int data) {
			InteropHelp.TestIfAvailableClient();
			using (var name2 = new InteropHelp.UTF8StringHandle(name)) {
				return NativeMethods.ISteamUserStats_GetStat(name2, out data);
			}
		}

		public static bool GetStat(string name, out float data) {
			InteropHelp.TestIfAvailableClient();
			using (var name2 = new InteropHelp.UTF8StringHandle(name)) {
				return NativeMethods.ISteamUserStats_GetStat_(name2, out data);
			}
		}

		/// <summary>
		/// <para> Set / update data</para>
		/// </summary>
		public static bool SetStat(string name, int nData) {
			InteropHelp.TestIfAvailableClient();
			using (var name2 = new InteropHelp.UTF8StringHandle(name)) {
				return NativeMethods.ISteamUserStats_SetStat(name2, nData);
			}
		}

		public static bool SetStat(string name, float fData) {
			InteropHelp.TestIfAvailableClient();
			using (var name2 = new InteropHelp.UTF8StringHandle(name)) {
				return NativeMethods.ISteamUserStats_SetStat_(name2, fData);
			}
		}

		public static bool UpdateAvgRateStat(string name, float flCountThisSession, double dSessionLength) {
			InteropHelp.TestIfAvailableClient();
			using (var name2 = new InteropHelp.UTF8StringHandle(name)) {
				return NativeMethods.ISteamUserStats_UpdateAvgRateStat(name2, flCountThisSession, dSessionLength);
			}
		}

		/// <summary>
		/// <para> Achievement flag accessors</para>
		/// </summary>
		public static bool GetAchievement(string name, out bool achieved) {
			InteropHelp.TestIfAvailableClient();
			using (var name2 = new InteropHelp.UTF8StringHandle(name)) {
				return NativeMethods.ISteamUserStats_GetAchievement(name2, out achieved);
			}
		}

		public static bool SetAchievement(string name) {
			InteropHelp.TestIfAvailableClient();
			using (var name2 = new InteropHelp.UTF8StringHandle(name)) {
				return NativeMethods.ISteamUserStats_SetAchievement(name2);
			}
		}

		public static bool ClearAchievement(string name) {
			InteropHelp.TestIfAvailableClient();
			using (var name2 = new InteropHelp.UTF8StringHandle(name)) {
				return NativeMethods.ISteamUserStats_ClearAchievement(name2);
			}
		}

		/// <summary>
		/// <para> Get the achievement status, and the time it was unlocked if unlocked.</para>
		/// <para> If the return value is true, but the unlock time is zero, that means it was unlocked before Steam</para>
		/// <para> began tracking achievement unlock times (December 2009). Time is seconds since January 1, 1970.</para>
		/// </summary>
		public static bool GetAchievementAndUnlockTime(string name, out bool achieved, out uint punUnlockTime) {
			InteropHelp.TestIfAvailableClient();
			using (var name2 = new InteropHelp.UTF8StringHandle(name)) {
				return NativeMethods.ISteamUserStats_GetAchievementAndUnlockTime(name2, out achieved, out punUnlockTime);
			}
		}

		/// <summary>
		/// <para> Store the current data on the server, will get a callback when set</para>
		/// <para> And one callback for every new achievement</para>
		/// <para> If the callback has a result of EResultInvalidParam, one or more stats</para>
		/// <para> uploaded has been rejected, either because they broke constraints</para>
		/// <para> or were out of date. In this case the server sends back updated values.</para>
		/// <para> The stats should be re-iterated to keep in sync.</para>
		/// </summary>
		public static bool StoreStats() {
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUserStats_StoreStats();
		}

		/// <summary>
		/// <para> Achievement / GroupAchievement metadata</para>
		/// <para> Gets the icon of the achievement, which is a handle to be used in ISteamUtils::GetImageRGBA(), or 0 if none set.</para>
		/// <para> A return value of 0 may indicate we are still fetching data, and you can wait for the UserAchievementIconFetched callback</para>
		/// <para> which will notify you when the bits are ready. If the callback still returns zero, then there is no image set for the</para>
		/// <para> specified achievement.</para>
		/// </summary>
		public static int GetAchievementIcon(string name) {
			InteropHelp.TestIfAvailableClient();
			using (var name2 = new InteropHelp.UTF8StringHandle(name)) {
				return NativeMethods.ISteamUserStats_GetAchievementIcon(name2);
			}
		}

		/// <summary>
		/// <para> Get general attributes for an achievement. Accepts the following keys:</para>
		/// <para> - "name" and "desc" for retrieving the localized achievement name and description (returned in UTF8)</para>
		/// <para> - "hidden" for retrieving if an achievement is hidden (returns "0" when not hidden, "1" when hidden)</para>
		/// </summary>
		public static string GetAchievementDisplayAttribute(string name, string Key) {
			InteropHelp.TestIfAvailableClient();
			using (var name2 = new InteropHelp.UTF8StringHandle(name))
			using (var Key2 = new InteropHelp.UTF8StringHandle(Key)) {
				return InteropHelp.PtrToStringUTF8(NativeMethods.ISteamUserStats_GetAchievementDisplayAttribute(name2, Key2));
			}
		}

		/// <summary>
		/// <para> Achievement progress - triggers an AchievementProgress callback, that is all.</para>
		/// <para> Calling this w/ N out of N progress will NOT set the achievement, the game must still do that.</para>
		/// </summary>
		public static bool IndicateAchievementProgress(string name, uint nCurProgress, uint nMaxProgress) {
			InteropHelp.TestIfAvailableClient();
			using (var name2 = new InteropHelp.UTF8StringHandle(name)) {
				return NativeMethods.ISteamUserStats_IndicateAchievementProgress(name2, nCurProgress, nMaxProgress);
			}
		}

		/// <summary>
		/// <para> Used for iterating achievements. In general games should not need these functions because they should have a</para>
		/// <para> list of existing achievements compiled into them</para>
		/// </summary>
		public static uint GetNumAchievements() {
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUserStats_GetNumAchievements();
		}

		/// <summary>
		/// <para> Get achievement name iAchievement in [0,GetNumAchievements)</para>
		/// </summary>
		public static string GetAchievementName(uint iAchievement) {
			InteropHelp.TestIfAvailableClient();
			return InteropHelp.PtrToStringUTF8(NativeMethods.ISteamUserStats_GetAchievementName(iAchievement));
		}

		/// <summary>
		/// <para> Friends stats &amp; achievements</para>
		/// <para> downloads stats for the user</para>
		/// <para> returns a UserStatsReceived received when completed</para>
		/// <para> if the other user has no stats, UserStatsReceived.ResultType will be set to EResultFail</para>
		/// <para> these stats won't be auto-updated; you'll need to call RequestUserStats() again to refresh any data</para>
		/// </summary>
		public static SteamAPICall RequestUserStats(SteamId userId) {
			InteropHelp.TestIfAvailableClient();
			return (SteamAPICall)NativeMethods.ISteamUserStats_RequestUserStats(userId);
		}

		/// <summary>
		/// <para> requests stat information for a user, usable after a successful call to RequestUserStats()</para>
		/// </summary>
		public static bool GetUserStat(SteamId userId, string name, out int data) {
			InteropHelp.TestIfAvailableClient();
			using (var name2 = new InteropHelp.UTF8StringHandle(name)) {
				return NativeMethods.ISteamUserStats_GetUserStat(userId, name2, out data);
			}
		}

		public static bool GetUserStat(SteamId userId, string name, out float data) {
			InteropHelp.TestIfAvailableClient();
			using (var name2 = new InteropHelp.UTF8StringHandle(name)) {
				return NativeMethods.ISteamUserStats_GetUserStat_(userId, name2, out data);
			}
		}

		public static bool GetUserAchievement(SteamId userId, string name, out bool achieved) {
			InteropHelp.TestIfAvailableClient();
			using (var name2 = new InteropHelp.UTF8StringHandle(name)) {
				return NativeMethods.ISteamUserStats_GetUserAchievement(userId, name2, out achieved);
			}
		}

		/// <summary>
		/// <para> See notes for GetAchievementAndUnlockTime above</para>
		/// </summary>
		public static bool GetUserAchievementAndUnlockTime(SteamId userId, string name, out bool achieved, out uint punUnlockTime) {
			InteropHelp.TestIfAvailableClient();
			using (var name2 = new InteropHelp.UTF8StringHandle(name)) {
				return NativeMethods.ISteamUserStats_GetUserAchievementAndUnlockTime(userId, name2, out achieved, out punUnlockTime);
			}
		}

		/// <summary>
		/// <para> Reset stats</para>
		/// </summary>
		public static bool ResetAllStats(bool achievementsToo) {
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUserStats_ResetAllStats(achievementsToo);
		}

		/// <summary>
		/// <para> Leaderboard functions</para>
		/// <para> asks the Steam back-end for a leaderboard by name, and will create it if it's not yet</para>
		/// <para> This call is asynchronous, with the result returned in LeaderboardFindResult</para>
		/// </summary>
		public static SteamAPICall FindOrCreateLeaderboard(string LeaderboardName, ELeaderboardSortMethod eLeaderboardSortMethod, ELeaderboardDisplayType eLeaderboardDisplayType) {
			InteropHelp.TestIfAvailableClient();
			using (var LeaderboardName2 = new InteropHelp.UTF8StringHandle(LeaderboardName)) {
				return (SteamAPICall)NativeMethods.ISteamUserStats_FindOrCreateLeaderboard(LeaderboardName2, eLeaderboardSortMethod, eLeaderboardDisplayType);
			}
		}

		/// <summary>
		/// <para> as above, but won't create the leaderboard if it's not found</para>
		/// <para> This call is asynchronous, with the result returned in LeaderboardFindResult</para>
		/// </summary>
		public static SteamAPICall FindLeaderboard(string LeaderboardName) {
			InteropHelp.TestIfAvailableClient();
			using (var LeaderboardName2 = new InteropHelp.UTF8StringHandle(LeaderboardName)) {
				return (SteamAPICall)NativeMethods.ISteamUserStats_FindLeaderboard(LeaderboardName2);
			}
		}

		/// <summary>
		/// <para> returns the name of a leaderboard</para>
		/// </summary>
		public static string GetLeaderboardName(SteamLeaderboard hSteamLeaderboard) {
			InteropHelp.TestIfAvailableClient();
			return InteropHelp.PtrToStringUTF8(NativeMethods.ISteamUserStats_GetLeaderboardName(hSteamLeaderboard));
		}

		/// <summary>
		/// <para> returns the total number of entries in a leaderboard, as of the last request</para>
		/// </summary>
		public static int GetLeaderboardEntryCount(SteamLeaderboard hSteamLeaderboard) {
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUserStats_GetLeaderboardEntryCount(hSteamLeaderboard);
		}

		/// <summary>
		/// <para> returns the sort method of the leaderboard</para>
		/// </summary>
		public static ELeaderboardSortMethod GetLeaderboardSortMethod(SteamLeaderboard hSteamLeaderboard) {
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUserStats_GetLeaderboardSortMethod(hSteamLeaderboard);
		}

		/// <summary>
		/// <para> returns the display type of the leaderboard</para>
		/// </summary>
		public static ELeaderboardDisplayType GetLeaderboardDisplayType(SteamLeaderboard hSteamLeaderboard) {
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUserStats_GetLeaderboardDisplayType(hSteamLeaderboard);
		}

		/// <summary>
		/// <para> Asks the Steam back-end for a set of rows in the leaderboard.</para>
		/// <para> This call is asynchronous, with the result returned in LeaderboardScoresDownloaded</para>
		/// <para> LeaderboardScoresDownloaded will contain a handle to pull the results from GetDownloadedLeaderboardEntries() (below)</para>
		/// <para> You can ask for more entries than exist, and it will return as many as do exist.</para>
		/// <para> ELeaderboardDataRequestGlobal requests rows in the leaderboard from the full table, with nRangeStart &amp; nRangeEnd in the range [1, TotalEntries]</para>
		/// <para> ELeaderboardDataRequestGlobalAroundUser requests rows around the current user, nRangeStart being negate</para>
		/// <para>   e.g. DownloadLeaderboardEntries( hLeaderboard, ELeaderboardDataRequestGlobalAroundUser, -3, 3 ) will return 7 rows, 3 before the user, 3 after</para>
		/// <para> ELeaderboardDataRequestFriends requests all the rows for friends of the current user</para>
		/// </summary>
		public static SteamAPICall DownloadLeaderboardEntries(SteamLeaderboard hSteamLeaderboard, ELeaderboardDataRequest eLeaderboardDataRequest, int nRangeStart, int nRangeEnd) {
			InteropHelp.TestIfAvailableClient();
			return (SteamAPICall)NativeMethods.ISteamUserStats_DownloadLeaderboardEntries(hSteamLeaderboard, eLeaderboardDataRequest, nRangeStart, nRangeEnd);
		}

		/// <summary>
		/// <para> as above, but downloads leaderboard entries for an arbitrary set of users - ELeaderboardDataRequest is ELeaderboardDataRequestUsers</para>
		/// <para> if a user doesn't have a leaderboard entry, they won't be included in the result</para>
		/// <para> a max of 100 users can be downloaded at a time, with only one outstanding call at a time</para>
		/// </summary>
		public static SteamAPICall DownloadLeaderboardEntriesForUsers(SteamLeaderboard hSteamLeaderboard, SteamId[] prgUsers, int cUsers) {
			InteropHelp.TestIfAvailableClient();
			return (SteamAPICall)NativeMethods.ISteamUserStats_DownloadLeaderboardEntriesForUsers(hSteamLeaderboard, prgUsers, cUsers);
		}

		/// <summary>
		/// <para> Returns data about a single leaderboard entry</para>
		/// <para> use a for loop from 0 to LeaderboardScoresDownloaded::_cEntryCount to get all the downloaded entries</para>
		/// <para> e.g.</para>
		/// <para>		void OnLeaderboardScoresDownloaded( LeaderboardScoresDownloaded *pLeaderboardScoresDownloaded )</para>
		/// <para>		{</para>
		/// <para>			for ( int index = 0; index &lt; pLeaderboardScoresDownloaded-&gt;_cEntryCount; index++ )</para>
		/// <para>			{</para>
		/// <para>				LeaderboardEntry leaderboardEntry;</para>
		/// <para>				int32 details[3];		// we know this is how many we've stored previously</para>
		/// <para>				GetDownloadedLeaderboardEntry( pLeaderboardScoresDownloaded-&gt;_hSteamLeaderboardEntries, index, &amp;leaderboardEntry, details, 3 );</para>
		/// <para>				assert( leaderboardEntry._cDetails == 3 );</para>
		/// <para>				...</para>
		/// <para>			}</para>
		/// <para> once you've accessed all the entries, the data will be free'd, and the SteamLeaderboardEntries handle will become invalid</para>
		/// </summary>
		public static bool GetDownloadedLeaderboardEntry(SteamLeaderboardEntries hSteamLeaderboardEntries, int index, out LeaderboardEntry pLeaderboardEntry, int[] pDetails, int cDetailsMax) {
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUserStats_GetDownloadedLeaderboardEntry(hSteamLeaderboardEntries, index, out pLeaderboardEntry, pDetails, cDetailsMax);
		}

		/// <summary>
		/// <para> Uploads a user score to the Steam back-end.</para>
		/// <para> This call is asynchronous, with the result returned in LeaderboardScoreUploaded</para>
		/// <para> Details are extra game-defined information regarding how the user got that score</para>
		/// <para> pScoreDetails points to an array of int32's, cScoreDetailsCount is the number of int32's in the list</para>
		/// </summary>
		public static SteamAPICall UploadLeaderboardScore(SteamLeaderboard hSteamLeaderboard, ELeaderboardUploadScoreMethod eLeaderboardUploadScoreMethod, int nScore, int[] pScoreDetails, int cScoreDetailsCount) {
			InteropHelp.TestIfAvailableClient();
			return (SteamAPICall)NativeMethods.ISteamUserStats_UploadLeaderboardScore(hSteamLeaderboard, eLeaderboardUploadScoreMethod, nScore, pScoreDetails, cScoreDetailsCount);
		}

		/// <summary>
		/// <para> Attaches a piece of user generated content the user's entry on a leaderboard.</para>
		/// <para> hContent is a handle to a piece of user generated content that was shared using ISteamUserRemoteStorage::FileShare().</para>
		/// <para> This call is asynchronous, with the result returned in LeaderboardUGCSet.</para>
		/// </summary>
		public static SteamAPICall AttachLeaderboardUGC(SteamLeaderboard hSteamLeaderboard, UGCHandle hUGC) {
			InteropHelp.TestIfAvailableClient();
			return (SteamAPICall)NativeMethods.ISteamUserStats_AttachLeaderboardUGC(hSteamLeaderboard, hUGC);
		}

		/// <summary>
		/// <para> Retrieves the number of players currently playing your game (online + offline)</para>
		/// <para> This call is asynchronous, with the result returned in NumberOfCurrentPlayers</para>
		/// </summary>
		public static SteamAPICall GetNumberOfCurrentPlayers() {
			InteropHelp.TestIfAvailableClient();
			return (SteamAPICall)NativeMethods.ISteamUserStats_GetNumberOfCurrentPlayers();
		}

		/// <summary>
		/// <para> Requests that Steam fetch data on the percentage of players who have received each achievement</para>
		/// <para> for the game globally.</para>
		/// <para> This call is asynchronous, with the result returned in GlobalAchievementPercentagesReady.</para>
		/// </summary>
		public static SteamAPICall RequestGlobalAchievementPercentages() {
			InteropHelp.TestIfAvailableClient();
			return (SteamAPICall)NativeMethods.ISteamUserStats_RequestGlobalAchievementPercentages();
		}

		/// <summary>
		/// <para> Get the info on the most achieved achievement for the game, returns an iterator index you can use to fetch</para>
		/// <para> the next most achieved afterwards.  Will return -1 if there is no data on achievement</para>
		/// <para> percentages (ie, you haven't called RequestGlobalAchievementPercentages and waited on the callback).</para>
		/// </summary>
		public static int GetMostAchievedAchievementInfo(out string name, uint unNameBufLen, out float pflPercent, out bool achieved) {
			InteropHelp.TestIfAvailableClient();
			var name2 = Marshal.AllocHGlobal((int)unNameBufLen);
			var ret = NativeMethods.ISteamUserStats_GetMostAchievedAchievementInfo(name2, unNameBufLen, out pflPercent, out achieved);
			name = ret != -1 ? InteropHelp.PtrToStringUTF8(name2) : null;
			Marshal.FreeHGlobal(name2);
			return ret;
		}

		/// <summary>
		/// <para> Get the info on the next most achieved achievement for the game. Call this after GetMostAchievedAchievementInfo or another</para>
		/// <para> GetNextMostAchievedAchievementInfo call passing the iterator from the previous call. Returns -1 after the last</para>
		/// <para> achievement has been iterated.</para>
		/// </summary>
		public static int GetNextMostAchievedAchievementInfo(int iIteratorPrevious, out string name, uint unNameBufLen, out float pflPercent, out bool achieved) {
			InteropHelp.TestIfAvailableClient();
			var name2 = Marshal.AllocHGlobal((int)unNameBufLen);
			var ret = NativeMethods.ISteamUserStats_GetNextMostAchievedAchievementInfo(iIteratorPrevious, name2, unNameBufLen, out pflPercent, out achieved);
			name = ret != -1 ? InteropHelp.PtrToStringUTF8(name2) : null;
			Marshal.FreeHGlobal(name2);
			return ret;
		}

		/// <summary>
		/// <para> Returns the percentage of users who have achieved the specified achievement.</para>
		/// </summary>
		public static bool GetAchievementAchievedPercent(string name, out float pflPercent) {
			InteropHelp.TestIfAvailableClient();
			using (var name2 = new InteropHelp.UTF8StringHandle(name)) {
				return NativeMethods.ISteamUserStats_GetAchievementAchievedPercent(name2, out pflPercent);
			}
		}

		/// <summary>
		/// <para> Requests global stats data, which is available for stats marked as "aggregated".</para>
		/// <para> This call is asynchronous, with the results returned in GlobalStatsReceived.</para>
		/// <para> nHistoryDays specifies how many days of day-by-day history to retrieve in addition</para>
		/// <para> to the overall totals. The limit is 60.</para>
		/// </summary>
		public static SteamAPICall RequestGlobalStats(int nHistoryDays) {
			InteropHelp.TestIfAvailableClient();
			return (SteamAPICall)NativeMethods.ISteamUserStats_RequestGlobalStats(nHistoryDays);
		}

		/// <summary>
		/// <para> Gets the lifetime totals for an aggregated stat</para>
		/// </summary>
		public static bool GetGlobalStat(string StatName, out long data) {
			InteropHelp.TestIfAvailableClient();
			using (var StatName2 = new InteropHelp.UTF8StringHandle(StatName)) {
				return NativeMethods.ISteamUserStats_GetGlobalStat(StatName2, out data);
			}
		}

		public static bool GetGlobalStat(string StatName, out double data) {
			InteropHelp.TestIfAvailableClient();
			using (var StatName2 = new InteropHelp.UTF8StringHandle(StatName)) {
				return NativeMethods.ISteamUserStats_GetGlobalStat_(StatName2, out data);
			}
		}

		/// <summary>
		/// <para> Gets history for an aggregated stat. data will be filled with daily values, starting with today.</para>
		/// <para> So when called, data[0] will be today, data[1] will be yesterday, and data[2] will be two days ago,</para>
		/// <para> etc. Data is the size in bytes of the pubData buffer. Returns the number of</para>
		/// <para> elements actually set.</para>
		/// </summary>
		public static int GetGlobalStatHistory(string StatName, long[] data, uint Data) {
			InteropHelp.TestIfAvailableClient();
			using (var StatName2 = new InteropHelp.UTF8StringHandle(StatName)) {
				return NativeMethods.ISteamUserStats_GetGlobalStatHistory(StatName2, data, Data);
			}
		}

		public static int GetGlobalStatHistory(string StatName, double[] data, uint Data) {
			InteropHelp.TestIfAvailableClient();
			using (var StatName2 = new InteropHelp.UTF8StringHandle(StatName)) {
				return NativeMethods.ISteamUserStats_GetGlobalStatHistory_(StatName2, data, Data);
			}
		}
#if _PS3
		/// <summary>
		/// <para> Call to kick off installation of the PS3 trophies. This call is asynchronous, and the results will be returned in a PS3TrophiesInstalled</para>
		/// <para> callback.</para>
		/// </summary>
		public static bool InstallPS3Trophies() {
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUserStats_InstallPS3Trophies();
		}

		/// <summary>
		/// <para> Returns the amount of space required at boot to install trophies. This value can be used when comparing the amount of space needed</para>
		/// <para> by the game to the available space value passed to the game at boot. The value is set during InstallPS3Trophies().</para>
		/// </summary>
		public static ulong GetTrophySpaceRequiredBeforeInstall() {
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUserStats_GetTrophySpaceRequiredBeforeInstall();
		}

		/// <summary>
		/// <para> On PS3, user stats &amp; achievement progress through Steam must be stored with the user's saved game data.</para>
		/// <para> At startup, before calling RequestCurrentStats(), you must pass the user's stats data to Steam via this method.</para>
		/// <para> If you do not have any user data, call this function with pvData = NULL and Data = 0</para>
		/// </summary>
		public static bool SetUserStatsData(IntPtr pvData, uint Data) {
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUserStats_SetUserStatsData(pvData, Data);
		}

		/// <summary>
		/// <para> Call to get the user's current stats data. You should retrieve this data after receiving successful UserStatsReceived &amp; UserStatsStored</para>
		/// <para> callbacks, and store the data with the user's save game data. You can call this method with pvData = NULL and Data = 0 to get the required</para>
		/// <para> buffer size.</para>
		/// </summary>
		public static bool GetUserStatsData(IntPtr pvData, uint Data, out uint pcubWritten) {
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUserStats_GetUserStatsData(pvData, Data, out pcubWritten);
		}
#endif
	}
}
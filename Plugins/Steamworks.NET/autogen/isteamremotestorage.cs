// This file is provided under The MIT License as part of Steamworks.NET.
// Copyright (c) 2013-2015 Riley Labrecque
// Please see the included LICENSE.txt for additional information.

// This file is automatically generated.
// Changes to this file will be reverted when you update Steamworks.NET

using System;

namespace Steamworks {
	public static class SteamRemoteStorage {
		/// <summary>
		/// <para> NOTE</para>
		/// <para> Filenames are case-insensitive, and will be converted to lowercase automatically.</para>
		/// <para> So "foo.bar" and "Foo.bar" are the same file, and if you write "Foo.bar" then</para>
		/// <para> iterate the files, the filename returned will be "foo.bar".</para>
		/// <para> file operations</para>
		/// </summary>
		public static bool FileWrite(string File, byte[] pvData, int Data) {
			InteropHelp.TestIfAvailableClient();
			using (var File2 = new InteropHelp.UTF8StringHandle(File)) {
				return NativeMethods.ISteamRemoteStorage_FileWrite(File2, pvData, Data);
			}
		}

		public static int FileRead(string File, byte[] pvData, int DataToRead) {
			InteropHelp.TestIfAvailableClient();
			using (var File2 = new InteropHelp.UTF8StringHandle(File)) {
				return NativeMethods.ISteamRemoteStorage_FileRead(File2, pvData, DataToRead);
			}
		}

		public static SteamAPICall FileWriteAsync(string File, byte[] pvData, uint Data) {
			InteropHelp.TestIfAvailableClient();
			using (var File2 = new InteropHelp.UTF8StringHandle(File)) {
				return (SteamAPICall)NativeMethods.ISteamRemoteStorage_FileWriteAsync(File2, pvData, Data);
			}
		}

		public static SteamAPICall FileReadAsync(string File, uint nOffset, uint ToRead) {
			InteropHelp.TestIfAvailableClient();
			using (var File2 = new InteropHelp.UTF8StringHandle(File)) {
				return (SteamAPICall)NativeMethods.ISteamRemoteStorage_FileReadAsync(File2, nOffset, ToRead);
			}
		}

		public static bool FileReadAsyncComplete(SteamAPICall hReadCall, byte[] pvBuffer, uint ToRead) {
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamRemoteStorage_FileReadAsyncComplete(hReadCall, pvBuffer, ToRead);
		}

		public static bool FileForget(string File) {
			InteropHelp.TestIfAvailableClient();
			using (var File2 = new InteropHelp.UTF8StringHandle(File)) {
				return NativeMethods.ISteamRemoteStorage_FileForget(File2);
			}
		}

		public static bool FileDelete(string File) {
			InteropHelp.TestIfAvailableClient();
			using (var File2 = new InteropHelp.UTF8StringHandle(File)) {
				return NativeMethods.ISteamRemoteStorage_FileDelete(File2);
			}
		}

		public static SteamAPICall FileShare(string File) {
			InteropHelp.TestIfAvailableClient();
			using (var File2 = new InteropHelp.UTF8StringHandle(File)) {
				return (SteamAPICall)NativeMethods.ISteamRemoteStorage_FileShare(File2);
			}
		}

		public static bool SetSyncPlatforms(string File, ERemoteStoragePlatform eRemoteStoragePlatform) {
			InteropHelp.TestIfAvailableClient();
			using (var File2 = new InteropHelp.UTF8StringHandle(File)) {
				return NativeMethods.ISteamRemoteStorage_SetSyncPlatforms(File2, eRemoteStoragePlatform);
			}
		}

		/// <summary>
		/// <para> file operations that cause network IO</para>
		/// </summary>
		public static UGCFileWriteStreamHandle FileWriteStreamOpen(string File) {
			InteropHelp.TestIfAvailableClient();
			using (var File2 = new InteropHelp.UTF8StringHandle(File)) {
				return (UGCFileWriteStreamHandle)NativeMethods.ISteamRemoteStorage_FileWriteStreamOpen(File2);
			}
		}

		public static bool FileWriteStreamWriteChunk(UGCFileWriteStreamHandle writeHandle, byte[] pvData, int Data) {
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamRemoteStorage_FileWriteStreamWriteChunk(writeHandle, pvData, Data);
		}

		public static bool FileWriteStreamClose(UGCFileWriteStreamHandle writeHandle) {
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamRemoteStorage_FileWriteStreamClose(writeHandle);
		}

		public static bool FileWriteStreamCancel(UGCFileWriteStreamHandle writeHandle) {
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamRemoteStorage_FileWriteStreamCancel(writeHandle);
		}

		/// <summary>
		/// <para> file information</para>
		/// </summary>
		public static bool FileExists(string File) {
			InteropHelp.TestIfAvailableClient();
			using (var File2 = new InteropHelp.UTF8StringHandle(File)) {
				return NativeMethods.ISteamRemoteStorage_FileExists(File2);
			}
		}

		public static bool FilePersisted(string File) {
			InteropHelp.TestIfAvailableClient();
			using (var File2 = new InteropHelp.UTF8StringHandle(File)) {
				return NativeMethods.ISteamRemoteStorage_FilePersisted(File2);
			}
		}

		public static int GetFileSize(string File) {
			InteropHelp.TestIfAvailableClient();
			using (var File2 = new InteropHelp.UTF8StringHandle(File)) {
				return NativeMethods.ISteamRemoteStorage_GetFileSize(File2);
			}
		}

		public static long GetFileTimestamp(string File) {
			InteropHelp.TestIfAvailableClient();
			using (var File2 = new InteropHelp.UTF8StringHandle(File)) {
				return NativeMethods.ISteamRemoteStorage_GetFileTimestamp(File2);
			}
		}

		public static ERemoteStoragePlatform GetSyncPlatforms(string File) {
			InteropHelp.TestIfAvailableClient();
			using (var File2 = new InteropHelp.UTF8StringHandle(File)) {
				return NativeMethods.ISteamRemoteStorage_GetSyncPlatforms(File2);
			}
		}

		/// <summary>
		/// <para> iteration</para>
		/// </summary>
		public static int GetFileCount() {
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamRemoteStorage_GetFileCount();
		}

		public static string GetFileNameAndSize(int iFile, out int pnFileSizeInBytes) {
			InteropHelp.TestIfAvailableClient();
			return InteropHelp.PtrToStringUTF8(NativeMethods.ISteamRemoteStorage_GetFileNameAndSize(iFile, out pnFileSizeInBytes));
		}

		/// <summary>
		/// <para> configuration management</para>
		/// </summary>
		public static bool GetQuota(out int pnTotalBytes, out int puAvailableBytes) {
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamRemoteStorage_GetQuota(out pnTotalBytes, out puAvailableBytes);
		}

		public static bool IsCloudEnabledForAccount() {
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamRemoteStorage_IsCloudEnabledForAccount();
		}

		public static bool IsCloudEnabledForApp() {
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamRemoteStorage_IsCloudEnabledForApp();
		}

		public static void SetCloudEnabledForApp(bool bEnabled) {
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamRemoteStorage_SetCloudEnabledForApp(bEnabled);
		}

		/// <summary>
		/// <para> user generated content</para>
		/// <para> Downloads a UGC file.  A priority value of 0 will download the file immediately,</para>
		/// <para> otherwise it will wait to download the file until all downloads with a lower priority</para>
		/// <para> value are completed.  Downloads with equal priority will occur simultaneously.</para>
		/// </summary>
		public static SteamAPICall UGCDownload(UGCHandle hContent, uint unPriority) {
			InteropHelp.TestIfAvailableClient();
			return (SteamAPICall)NativeMethods.ISteamRemoteStorage_UGCDownload(hContent, unPriority);
		}

		/// <summary>
		/// <para> Gets the amount of data downloaded so far for a piece of content. pnBytesExpected can be 0 if function returns false</para>
		/// <para> or if the transfer hasn't started yet, so be careful to check for that before dividing to get a percentage</para>
		/// </summary>
		public static bool GetUGCDownloadProgress(UGCHandle hContent, out int pnBytesDownloaded, out int pnBytesExpected) {
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamRemoteStorage_GetUGCDownloadProgress(hContent, out pnBytesDownloaded, out pnBytesExpected);
		}

		/// <summary>
		/// <para> Gets metadata for a file after it has been downloaded. This is the same metadata given in the RemoteStorageDownloadUGCResult call result</para>
		/// </summary>
		public static bool GetUGCDetails(UGCHandle hContent, out AppId pappId, out string pname, out int pnFileSizeInBytes, out SteamId pSteamIDOwner) {
			InteropHelp.TestIfAvailableClient();
			IntPtr pname2;
			var ret = NativeMethods.ISteamRemoteStorage_GetUGCDetails(hContent, out pappId, out pname2, out pnFileSizeInBytes, out pSteamIDOwner);
			pname = ret ? InteropHelp.PtrToStringUTF8(pname2) : null;
			return ret;
		}

		/// <summary>
		/// <para> After download, gets the content of the file.</para>
		/// <para> Small files can be read all at once by calling this function with an offset of 0 and DataToRead equal to the size of the file.</para>
		/// <para> Larger files can be read in chunks to reduce memory usage (since both sides of the IPC client and the game itself must allocate</para>
		/// <para> enough memory for each chunk).  Once the last byte is read, the file is implicitly closed and further calls to UGCRead will fail</para>
		/// <para> unless UGCDownload is called again.</para>
		/// <para> For especially large files (anything over 100MB) it is a requirement that the file is read in chunks.</para>
		/// </summary>
		public static int UGCRead(UGCHandle hContent, byte[] pvData, int DataToRead, uint cOffset, EugcReadAction eAction) {
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamRemoteStorage_UGCRead(hContent, pvData, DataToRead, cOffset, eAction);
		}

		/// <summary>
		/// <para> Functions to iterate through UGC that has finished downloading but has not yet been read via UGCRead()</para>
		/// </summary>
		public static int GetCachedUGCCount() {
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamRemoteStorage_GetCachedUGCCount();
		}

		public static UGCHandle GetCachedUGCHandle(int iCachedContent) {
			InteropHelp.TestIfAvailableClient();
			return (UGCHandle)NativeMethods.ISteamRemoteStorage_GetCachedUGCHandle(iCachedContent);
		}
#if _PS3 || _SERVER
		/// <summary>
		/// <para> The following functions are only necessary on the Playstation 3. On PC &amp; Mac, the Steam client will handle these operations for you</para>
		/// <para> On Playstation 3, the game controls which files are stored in the cloud, via FilePersist, FileFetch, and FileForget.</para>
		/// <para> Connect to Steam and get a list of files in the Cloud - results in a RemoteStorageAppSyncStatusChect callback</para>
		/// </summary>
		public static void GetFileListFromServer() {
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamRemoteStorage_GetFileListFromServer();
		}

		/// <summary>
		/// <para> Indicate this file should be downloaded in the next sync</para>
		/// </summary>
		public static bool FileFetch(string File) {
			InteropHelp.TestIfAvailableClient();
			using (var File2 = new InteropHelp.UTF8StringHandle(File)) {
				return NativeMethods.ISteamRemoteStorage_FileFetch(File2);
			}
		}

		/// <summary>
		/// <para> Indicate this file should be persisted in the next sync</para>
		/// </summary>
		public static bool FilePersist(string File) {
			InteropHelp.TestIfAvailableClient();
			using (var File2 = new InteropHelp.UTF8StringHandle(File)) {
				return NativeMethods.ISteamRemoteStorage_FilePersist(File2);
			}
		}

		/// <summary>
		/// <para> Pull any requested files down from the Cloud - results in a RemoteStorageAppSyncedClient callback</para>
		/// </summary>
		public static bool SynchronizeToClient() {
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamRemoteStorage_SynchronizeToClient();
		}

		/// <summary>
		/// <para> Upload any requested files to the Cloud - results in a RemoteStorageAppSyncedServer callback</para>
		/// </summary>
		public static bool SynchronizeToServer() {
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamRemoteStorage_SynchronizeToServer();
		}

		/// <summary>
		/// <para> Reset any fetch/persist/etc requests</para>
		/// </summary>
		public static bool ResetFileRequestState() {
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamRemoteStorage_ResetFileRequestState();
		}
#endif
		/// <summary>
		/// <para> publishing UGC</para>
		/// </summary>
		public static SteamAPICall PublishWorkshopFile(string File, string PreviewFile, AppId nConsumerAppId, string Title, string Description, Visibility eVisibility, System.Collections.Generic.IList<string> pTags, WorkshopFileType workshopFileType) {
			InteropHelp.TestIfAvailableClient();
			using (var File2 = new InteropHelp.UTF8StringHandle(File))
			using (var PreviewFile2 = new InteropHelp.UTF8StringHandle(PreviewFile))
			using (var Title2 = new InteropHelp.UTF8StringHandle(Title))
			using (var Description2 = new InteropHelp.UTF8StringHandle(Description)) {
				return (SteamAPICall)NativeMethods.ISteamRemoteStorage_PublishWorkshopFile(File2, PreviewFile2, nConsumerAppId, Title2, Description2, eVisibility, new InteropHelp.SteamParamStringArray(pTags), workshopFileType);
			}
		}

		public static PublishedFileUpdateHandle CreatePublishedFileUpdateRequest(PublishedFileId unPublishedFileId) {
			InteropHelp.TestIfAvailableClient();
			return (PublishedFileUpdateHandle)NativeMethods.ISteamRemoteStorage_CreatePublishedFileUpdateRequest(unPublishedFileId);
		}

		public static bool UpdatePublishedFileFile(PublishedFileUpdateHandle updateHandle, string File) {
			InteropHelp.TestIfAvailableClient();
			using (var File2 = new InteropHelp.UTF8StringHandle(File)) {
				return NativeMethods.ISteamRemoteStorage_UpdatePublishedFileFile(updateHandle, File2);
			}
		}

		public static bool UpdatePublishedFilePreviewFile(PublishedFileUpdateHandle updateHandle, string PreviewFile) {
			InteropHelp.TestIfAvailableClient();
			using (var PreviewFile2 = new InteropHelp.UTF8StringHandle(PreviewFile)) {
				return NativeMethods.ISteamRemoteStorage_UpdatePublishedFilePreviewFile(updateHandle, PreviewFile2);
			}
		}

		public static bool UpdatePublishedFileTitle(PublishedFileUpdateHandle updateHandle, string Title) {
			InteropHelp.TestIfAvailableClient();
			using (var Title2 = new InteropHelp.UTF8StringHandle(Title)) {
				return NativeMethods.ISteamRemoteStorage_UpdatePublishedFileTitle(updateHandle, Title2);
			}
		}

		public static bool UpdatePublishedFileDescription(PublishedFileUpdateHandle updateHandle, string Description) {
			InteropHelp.TestIfAvailableClient();
			using (var Description2 = new InteropHelp.UTF8StringHandle(Description)) {
				return NativeMethods.ISteamRemoteStorage_UpdatePublishedFileDescription(updateHandle, Description2);
			}
		}

		public static bool UpdatePublishedFileVisibility(PublishedFileUpdateHandle updateHandle, Visibility eVisibility) {
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamRemoteStorage_UpdatePublishedFileVisibility(updateHandle, eVisibility);
		}

		public static bool UpdatePublishedFileTags(PublishedFileUpdateHandle updateHandle, System.Collections.Generic.IList<string> pTags) {
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamRemoteStorage_UpdatePublishedFileTags(updateHandle, new InteropHelp.SteamParamStringArray(pTags));
		}

		public static SteamAPICall CommitPublishedFileUpdate(PublishedFileUpdateHandle updateHandle) {
			InteropHelp.TestIfAvailableClient();
			return (SteamAPICall)NativeMethods.ISteamRemoteStorage_CommitPublishedFileUpdate(updateHandle);
		}

		/// <summary>
		/// <para> Gets published file details for the given publishedfileid.  If unMaxSecondsOld is greater than 0,</para>
		/// <para> cached data may be returned, depending on how long ago it was cached.  A value of 0 will force a refresh.</para>
		/// <para> A value of WorkshopForceLoadPublishedFileDetailsFromCache will use cached data if it exists, no matter how old it is.</para>
		/// </summary>
		public static SteamAPICall GetPublishedFileDetails(PublishedFileId unPublishedFileId, uint unMaxSecondsOld) {
			InteropHelp.TestIfAvailableClient();
			return (SteamAPICall)NativeMethods.ISteamRemoteStorage_GetPublishedFileDetails(unPublishedFileId, unMaxSecondsOld);
		}

		public static SteamAPICall DeletePublishedFile(PublishedFileId unPublishedFileId) {
			InteropHelp.TestIfAvailableClient();
			return (SteamAPICall)NativeMethods.ISteamRemoteStorage_DeletePublishedFile(unPublishedFileId);
		}

		/// <summary>
		/// <para> enumerate the files that the current user published with this app</para>
		/// </summary>
		public static SteamAPICall EnumerateUserPublishedFiles(uint unStartIndex) {
			InteropHelp.TestIfAvailableClient();
			return (SteamAPICall)NativeMethods.ISteamRemoteStorage_EnumerateUserPublishedFiles(unStartIndex);
		}

		public static SteamAPICall SubscribePublishedFile(PublishedFileId unPublishedFileId) {
			InteropHelp.TestIfAvailableClient();
			return (SteamAPICall)NativeMethods.ISteamRemoteStorage_SubscribePublishedFile(unPublishedFileId);
		}

		public static SteamAPICall EnumerateUserSubscribedFiles(uint unStartIndex) {
			InteropHelp.TestIfAvailableClient();
			return (SteamAPICall)NativeMethods.ISteamRemoteStorage_EnumerateUserSubscribedFiles(unStartIndex);
		}

		public static SteamAPICall UnsubscribePublishedFile(PublishedFileId unPublishedFileId) {
			InteropHelp.TestIfAvailableClient();
			return (SteamAPICall)NativeMethods.ISteamRemoteStorage_UnsubscribePublishedFile(unPublishedFileId);
		}

		public static bool UpdatePublishedFileSetChangeDescription(PublishedFileUpdateHandle updateHandle, string ChangeDescription) {
			InteropHelp.TestIfAvailableClient();
			using (var ChangeDescription2 = new InteropHelp.UTF8StringHandle(ChangeDescription)) {
				return NativeMethods.ISteamRemoteStorage_UpdatePublishedFileSetChangeDescription(updateHandle, ChangeDescription2);
			}
		}

		public static SteamAPICall GetPublishedItemVoteDetails(PublishedFileId unPublishedFileId) {
			InteropHelp.TestIfAvailableClient();
			return (SteamAPICall)NativeMethods.ISteamRemoteStorage_GetPublishedItemVoteDetails(unPublishedFileId);
		}

		public static SteamAPICall UpdateUserPublishedItemVote(PublishedFileId unPublishedFileId, bool bVoteUp) {
			InteropHelp.TestIfAvailableClient();
			return (SteamAPICall)NativeMethods.ISteamRemoteStorage_UpdateUserPublishedItemVote(unPublishedFileId, bVoteUp);
		}

		public static SteamAPICall GetUserPublishedItemVoteDetails(PublishedFileId unPublishedFileId) {
			InteropHelp.TestIfAvailableClient();
			return (SteamAPICall)NativeMethods.ISteamRemoteStorage_GetUserPublishedItemVoteDetails(unPublishedFileId);
		}

		public static SteamAPICall EnumerateUserSharedWorkshopFiles(SteamId steamId, uint unStartIndex, System.Collections.Generic.IList<string> pRequiredTags, System.Collections.Generic.IList<string> pExcludedTags) {
			InteropHelp.TestIfAvailableClient();
			return (SteamAPICall)NativeMethods.ISteamRemoteStorage_EnumerateUserSharedWorkshopFiles(steamId, unStartIndex, new InteropHelp.SteamParamStringArray(pRequiredTags), new InteropHelp.SteamParamStringArray(pExcludedTags));
		}

		public static SteamAPICall PublishVideo(EWorkshopVideoProvider eVideoProvider, string VideoAccount, string VideoIdentifier, string PreviewFile, AppId nConsumerAppId, string Title, string Description, Visibility eVisibility, System.Collections.Generic.IList<string> pTags) {
			InteropHelp.TestIfAvailableClient();
			using (var VideoAccount2 = new InteropHelp.UTF8StringHandle(VideoAccount))
			using (var VideoIdentifier2 = new InteropHelp.UTF8StringHandle(VideoIdentifier))
			using (var PreviewFile2 = new InteropHelp.UTF8StringHandle(PreviewFile))
			using (var Title2 = new InteropHelp.UTF8StringHandle(Title))
			using (var Description2 = new InteropHelp.UTF8StringHandle(Description)) {
				return (SteamAPICall)NativeMethods.ISteamRemoteStorage_PublishVideo(eVideoProvider, VideoAccount2, VideoIdentifier2, PreviewFile2, nConsumerAppId, Title2, Description2, eVisibility, new InteropHelp.SteamParamStringArray(pTags));
			}
		}

		public static SteamAPICall SetUserPublishedFileAction(PublishedFileId unPublishedFileId, EWorkshopFileAction eAction) {
			InteropHelp.TestIfAvailableClient();
			return (SteamAPICall)NativeMethods.ISteamRemoteStorage_SetUserPublishedFileAction(unPublishedFileId, eAction);
		}

		public static SteamAPICall EnumeratePublishedFilesByUserAction(EWorkshopFileAction eAction, uint unStartIndex) {
			InteropHelp.TestIfAvailableClient();
			return (SteamAPICall)NativeMethods.ISteamRemoteStorage_EnumeratePublishedFilesByUserAction(eAction, unStartIndex);
		}

		/// <summary>
		/// <para> this method enumerates the public view of workshop files</para>
		/// </summary>
		public static SteamAPICall EnumeratePublishedWorkshopFiles(EWorkshopEnumerationType eEnumerationType, uint unStartIndex, uint unCount, uint unDays, System.Collections.Generic.IList<string> pTags, System.Collections.Generic.IList<string> pUserTags) {
			InteropHelp.TestIfAvailableClient();
			return (SteamAPICall)NativeMethods.ISteamRemoteStorage_EnumeratePublishedWorkshopFiles(eEnumerationType, unStartIndex, unCount, unDays, new InteropHelp.SteamParamStringArray(pTags), new InteropHelp.SteamParamStringArray(pUserTags));
		}

		public static SteamAPICall UGCDownloadToLocation(UGCHandle hContent, string Location, uint unPriority) {
			InteropHelp.TestIfAvailableClient();
			using (var Location2 = new InteropHelp.UTF8StringHandle(Location)) {
				return (SteamAPICall)NativeMethods.ISteamRemoteStorage_UGCDownloadToLocation(hContent, Location2, unPriority);
			}
		}
	}
}
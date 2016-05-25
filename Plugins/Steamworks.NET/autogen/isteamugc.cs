// This file is provided under The MIT License as part of Steamworks.NET.
// Copyright (c) 2013-2015 Riley Labrecque
// Please see the included LICENSE.txt for additional information.

// This file is automatically generated.
// Changes to this file will be reverted when you update Steamworks.NET

using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using Steamworks.Steamworks.NET;

namespace Steamworks {
	public static class SteamUGC
    {
        public static Action<ItemInstalled> OnItemInstalled;
        public static Action<DownloadItemResult> OnDownloadCompleted;
        public static Action<RemoteStoragePublishedFileUnsubscribed> OnItemUnsubscribed;
        public static Action<RemoteStoragePublishedFileSubscribed> OnItemSubscribed;

        private static Callback<ItemInstalled> _itemInstalledCallback;
        private static Callback<DownloadItemResult> _DownloadItemComplete;
        private static Callback<RemoteStoragePublishedFileSubscribed> _subscribedCallback;
        private static Callback<RemoteStoragePublishedFileUnsubscribed> _unSubscribedCallback;

        public static void Initialize()
        {
            if (_itemInstalledCallback != null || _DownloadItemComplete != null || _subscribedCallback != null || _unSubscribedCallback != null)
                return;

            _DownloadItemComplete = Callback<DownloadItemResult>.Create(DownloadCompleted);
            _subscribedCallback = Callback<RemoteStoragePublishedFileSubscribed>.Create(SubscribedComplete);
            _unSubscribedCallback = Callback<RemoteStoragePublishedFileUnsubscribed>.Create(UnSubscribedComplete);
            _itemInstalledCallback = Callback<ItemInstalled>.Create(ItemInstalled);
        }

	    private static void UnSubscribedComplete(RemoteStoragePublishedFileUnsubscribed param) => OnItemUnsubscribed?.Invoke(param);

	    private static void SubscribedComplete(RemoteStoragePublishedFileSubscribed param) => OnItemSubscribed?.Invoke(param);

	    private static void DownloadCompleted(DownloadItemResult param) => OnDownloadCompleted?.Invoke(param);

	    private static void ItemInstalled(ItemInstalled param) => OnItemInstalled?.Invoke(param);

	    /// <summary>
		/// <para> Query UGC associated with a user. Creator app id or consumer app id must be valid and be set to the current running app. unPage should start at 1.</para>
		/// </summary>
		public static UGCQueryHandle CreateQueryUserUGCRequest(AccountId accountId, UserUGCList listType, MatchingUGCType matchingUGCType, UGCListSortOrder sortOrder, AppId creatorAppId, AppId consumerAppId, uint unPage) {
			InteropHelp.TestIfAvailableClient();
			return (UGCQueryHandle)NativeMethods.ISteamUGC_CreateQueryUserUGCRequest(accountId, listType, matchingUGCType, sortOrder, creatorAppId, consumerAppId, unPage);
		}

		/// <summary>
		/// <para> Query for all matching UGC. Creator app id or consumer app id must be valid and be set to the current running app. unPage should start at 1.</para>
		/// </summary>
		public static UGCQueryHandle CreateQueryAllUGCRequest(UGCQuery eQueryType, MatchingUGCType eMatchingeMatchingUGCTypeFileType, AppId creatorAppId, AppId consumerAppId, uint unPage) {
			InteropHelp.TestIfAvailableClient();
			return (UGCQueryHandle)NativeMethods.ISteamUGC_CreateQueryAllUGCRequest(eQueryType, eMatchingeMatchingUGCTypeFileType, creatorAppId, consumerAppId, unPage);
		}


        /// <summary>
        /// <para> Query for the details of the given published file ids (the RequestUGCDetails call is deprecated and replaced with this)</para>
        /// </summary>
        public static UGCQueryHandle CreateQueryUGCDetailsRequest(PublishedFileId[] publishedFileId, uint unNumPublishedFileIDs) {
			InteropHelp.TestIfAvailableClient();
			return (UGCQueryHandle)NativeMethods.ISteamUGC_CreateQueryUGCDetailsRequest(publishedFileId, unNumPublishedFileIDs);
		}

		/// <summary>
		/// <para> Send the query to Steam</para>
		/// </summary>
		public static SteamAPICall SendQueryUGCRequest(UGCQueryHandle handle) {
			InteropHelp.TestIfAvailableClient();
			return (SteamAPICall)NativeMethods.ISteamUGC_SendQueryUGCRequest(handle);
		}

		/// <summary>
		/// <para> Retrieve an individual result after receiving the callback for querying UGC</para>
		/// </summary>
		public static bool GetQueryUGCResult(UGCQueryHandle handle, uint index, out SteamUGCDetails pDetails) {
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUGC_GetQueryUGCResult(handle, index, out pDetails);
		}

		public static bool GetQueryUGCPreviewURL(UGCQueryHandle handle, uint index, out string url, uint urlSize) {
			InteropHelp.TestIfAvailableClient();
			var url2 = Marshal.AllocHGlobal((int)urlSize);
			var ret = NativeMethods.ISteamUGC_GetQueryUGCPreviewURL(handle, index, url2, urlSize);
			url = ret ? InteropHelp.PtrToStringUTF8(url2) : null;
			Marshal.FreeHGlobal(url2);
			return ret;
		}

		public static bool GetQueryUGCMetadata(UGCQueryHandle handle, uint index, out string metadata, uint metadatasize) {
			InteropHelp.TestIfAvailableClient();
			var metadata2 = Marshal.AllocHGlobal((int)metadatasize);
			var ret = NativeMethods.ISteamUGC_GetQueryUGCMetadata(handle, index, metadata2, metadatasize);
			metadata = ret ? InteropHelp.PtrToStringUTF8(metadata2) : null;
			Marshal.FreeHGlobal(metadata2);
			return ret;
		}

		public static bool GetQueryUGCChildren(UGCQueryHandle handle, uint index, PublishedFileId[] publishedFileId, uint cMaxEntries) {
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUGC_GetQueryUGCChildren(handle, index, publishedFileId, cMaxEntries);
		}

		public static bool GetQueryUGCStatistic(UGCQueryHandle handle, uint index, EItemStatistic eStatType, out uint pStatValue) {
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUGC_GetQueryUGCStatistic(handle, index, eStatType, out pStatValue);
		}

		public static uint GetQueryUGCNumAdditionalPreviews(UGCQueryHandle handle, uint index) {
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUGC_GetQueryUGCNumAdditionalPreviews(handle, index);
		}

		public static bool GetQueryUGCAdditionalPreview(UGCQueryHandle handle, uint index, uint previewIndex, out string videoIdOrURL, uint urlSize, out bool pbIsImage) {
			InteropHelp.TestIfAvailableClient();
			var urlOrVideoId2 = Marshal.AllocHGlobal((int)urlSize);
			var ret = NativeMethods.ISteamUGC_GetQueryUGCAdditionalPreview(handle, index, previewIndex, urlOrVideoId2, urlSize, out pbIsImage);
			videoIdOrURL = ret ? InteropHelp.PtrToStringUTF8(urlOrVideoId2) : null;
			Marshal.FreeHGlobal(urlOrVideoId2);
			return ret;
		}

		public static uint GetQueryUGCNumKeyValueTags(UGCQueryHandle handle, uint index) {
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUGC_GetQueryUGCNumKeyValueTags(handle, index);
		}

		public static bool GetQueryUGCKeyValueTag(UGCQueryHandle handle, uint index, uint keyValueTagIndex, out string key, uint keySize, out string value, uint valueSize) {
			InteropHelp.TestIfAvailableClient();
			var key2 = Marshal.AllocHGlobal((int)keySize);
			var value2 = Marshal.AllocHGlobal((int)valueSize);
			var ret = NativeMethods.ISteamUGC_GetQueryUGCKeyValueTag(handle, index, keyValueTagIndex, key2, keySize, value2, valueSize);
			key = ret ? InteropHelp.PtrToStringUTF8(key2) : null;
			Marshal.FreeHGlobal(key2);
			value = ret ? InteropHelp.PtrToStringUTF8(value2) : null;
			Marshal.FreeHGlobal(value2);
			return ret;
		}

		/// <summary>
		/// <para> Release the request to free up memory, after retrieving results</para>
		/// </summary>
		public static bool ReleaseQueryUGCRequest(UGCQueryHandle handle) {
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUGC_ReleaseQueryUGCRequest(handle);
		}

		/// <summary>
		/// <para> Options to set for querying UGC</para>
		/// </summary>
		public static bool AddRequiredTag(UGCQueryHandle handle, string pTagName) {
			InteropHelp.TestIfAvailableClient();
			using (var pTagName2 = new InteropHelp.UTF8StringHandle(pTagName)) {
				return NativeMethods.ISteamUGC_AddRequiredTag(handle, pTagName2);
			}
		}

		public static bool AddExcludedTag(UGCQueryHandle handle, string pTagName) {
			InteropHelp.TestIfAvailableClient();
			using (var pTagName2 = new InteropHelp.UTF8StringHandle(pTagName)) {
				return NativeMethods.ISteamUGC_AddExcludedTag(handle, pTagName2);
			}
		}

		public static bool SetReturnKeyValueTags(UGCQueryHandle handle, bool bReturnKeyValueTags) {
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUGC_SetReturnKeyValueTags(handle, bReturnKeyValueTags);
		}

		public static bool SetReturnLongDescription(UGCQueryHandle handle, bool bReturnLongDescription) {
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUGC_SetReturnLongDescription(handle, bReturnLongDescription);
		}

		public static bool SetReturnMetadata(UGCQueryHandle handle, bool bReturnMetadata) {
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUGC_SetReturnMetadata(handle, bReturnMetadata);
		}

		public static bool SetReturnChildren(UGCQueryHandle handle, bool bReturnChildren) {
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUGC_SetReturnChildren(handle, bReturnChildren);
		}

		public static bool SetReturnAdditionalPreviews(UGCQueryHandle handle, bool bReturnAdditionalPreviews) {
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUGC_SetReturnAdditionalPreviews(handle, bReturnAdditionalPreviews);
		}

		public static bool SetReturnTotalOnly(UGCQueryHandle handle, bool bReturnTotalOnly) {
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUGC_SetReturnTotalOnly(handle, bReturnTotalOnly);
		}

		public static bool SetLanguage(UGCQueryHandle handle, string language) {
			InteropHelp.TestIfAvailableClient();
			using (var language2 = new InteropHelp.UTF8StringHandle(language)) {
				return NativeMethods.ISteamUGC_SetLanguage(handle, language2);
			}
		}

		public static bool SetAllowCachedResponse(UGCQueryHandle handle, uint unMaxAgeSeconds) {
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUGC_SetAllowCachedResponse(handle, unMaxAgeSeconds);
		}

		/// <summary>
		/// <para> Options only for querying user UGC</para>
		/// </summary>
		public static bool SetCloudFileNameFilter(UGCQueryHandle handle, string pMatchCloudFileName) {
			InteropHelp.TestIfAvailableClient();
			using (var pMatchCloudFileName2 = new InteropHelp.UTF8StringHandle(pMatchCloudFileName)) {
				return NativeMethods.ISteamUGC_SetCloudFileNameFilter(handle, pMatchCloudFileName2);
			}
		}

		/// <summary>
		/// <para> Options only for querying all UGC</para>
		/// </summary>
		public static bool SetMatchAnyTag(UGCQueryHandle handle, bool bMatchAnyTag) {
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUGC_SetMatchAnyTag(handle, bMatchAnyTag);
		}

		public static bool SetSearchText(UGCQueryHandle handle, string pSearchText) {
			InteropHelp.TestIfAvailableClient();
			using (var pSearchText2 = new InteropHelp.UTF8StringHandle(pSearchText)) {
				return NativeMethods.ISteamUGC_SetSearchText(handle, pSearchText2);
			}
		}

		public static bool SetRankedByTrendDays(UGCQueryHandle handle, uint unDays) {
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUGC_SetRankedByTrendDays(handle, unDays);
		}

		public static bool AddRequiredKeyValueTag(UGCQueryHandle handle, string pKey, string pValue) {
			InteropHelp.TestIfAvailableClient();
			using (var pKey2 = new InteropHelp.UTF8StringHandle(pKey))
			using (var pValue2 = new InteropHelp.UTF8StringHandle(pValue)) {
				return NativeMethods.ISteamUGC_AddRequiredKeyValueTag(handle, pKey2, pValue2);
			}
        }
        /// <summary>
        /// Get's all the available info about the PublishedFieldId and if it exists locally.
        /// </summary>
        /// <param name="item">Item to get details for</param>
        /// <returns>Details</returns>
        public static Task<SteamUGCRequestUGCDetailsResult> GetItemDetailsAsync(PublishedFileId item)
        {
            var tcs = new TaskCompletionSource<SteamUGCRequestUGCDetailsResult>();
            var call = RequestUGCDetails(item, 0);
            var detailRequestResult = new CallResult<SteamUGCRequestUGCDetailsResult>();
            detailRequestResult.Set(call, (a, d) =>
            {
                tcs.SetResult(a);
            });
            return tcs.Task;
        }
        public static Task<SteamUGCDetails[]> QueryAllUGCAsync(UGCQuery eQueryType, MatchingUGCType eMatchingeMatchingUGCTypeFileType, AppId creatorAppId, AppId consumerAppId, uint unPage)
        {
            var tcs = new TaskCompletionSource<SteamUGCDetails[]>();
            var queryHandle = SteamUGC.CreateQueryAllUGCRequest(eQueryType, eMatchingeMatchingUGCTypeFileType, creatorAppId, consumerAppId, unPage);

            var call = SteamUGC.SendQueryUGCRequest(queryHandle);

            var callback = new CallResult<SteamUGCQueryCompleted>();
            callback.Set(call, (a,b)=>
            {
                var results = new SteamUGCDetails[a.ResultsCount];
                for (uint i = 0; i < a.ResultsCount; i++)
                {
                    SteamUGCDetails details;
                    GetQueryUGCResult(queryHandle, i, out details);
                    results[i] = details;
                }
                tcs.SetResult(results);
            });

            return tcs.Task;
        }
        /// <summary>
        /// <para> DEPRECATED - Use CreateQueryUGCDetailsRequest call above instead!</para>
        /// </summary>
        private static SteamAPICall RequestUGCDetails(PublishedFileId fileId, uint unMaxAgeSeconds) {
			InteropHelp.TestIfAvailableClient();
			return (SteamAPICall)NativeMethods.ISteamUGC_RequestUGCDetails(fileId, unMaxAgeSeconds);
		}

		/// <summary>
		/// <para> Steam Workshop Creator API</para>
		/// <para> create new item for this app with no content attached yet</para>
		/// </summary>
		public static SteamAPICall CreateItem(AppId nConsumerAppId, WorkshopFileType fileType) {
			InteropHelp.TestIfAvailableClient();
			return (SteamAPICall)NativeMethods.ISteamUGC_CreateItem(nConsumerAppId, fileType);
		}

		/// <summary>
		/// <para> start an UGC item update. Set changed properties before commiting update with CommitItemUpdate()</para>
		/// </summary>
		public static UGCUpdateHandle StartItemUpdate(AppId nConsumerAppId, PublishedFileId fileId) {
			InteropHelp.TestIfAvailableClient();
			return (UGCUpdateHandle)NativeMethods.ISteamUGC_StartItemUpdate(nConsumerAppId, fileId);
		}

		/// <summary>
		/// <para> change the title of an UGC item</para>
		/// </summary>
		public static bool SetItemTitle(UGCUpdateHandle handle, string title) {
			InteropHelp.TestIfAvailableClient();
			using (var title2 = new InteropHelp.UTF8StringHandle(title)) {
				return NativeMethods.ISteamUGC_SetItemTitle(handle, title2);
			}
		}

		/// <summary>
		/// <para> change the description of an UGC item</para>
		/// </summary>
		public static bool SetItemDescription(UGCUpdateHandle handle, string description) {
			InteropHelp.TestIfAvailableClient();
			using (var description2 = new InteropHelp.UTF8StringHandle(description)) {
				return NativeMethods.ISteamUGC_SetItemDescription(handle, description2);
			}
		}

		/// <summary>
		/// <para> specify the language of the title or description that will be set</para>
		/// </summary>
		public static bool SetItemUpdateLanguage(UGCUpdateHandle handle, string language) {
			InteropHelp.TestIfAvailableClient();
			using (var language2 = new InteropHelp.UTF8StringHandle(language)) {
				return NativeMethods.ISteamUGC_SetItemUpdateLanguage(handle, language2);
			}
		}

		/// <summary>
		/// <para> change the metadata of an UGC item (max = DeveloperMetadataMax)</para>
		/// </summary>
		public static bool SetItemMetadata(UGCUpdateHandle handle, string metaData) {
			InteropHelp.TestIfAvailableClient();
			using (var metaData2 = new InteropHelp.UTF8StringHandle(metaData)) {
				return NativeMethods.ISteamUGC_SetItemMetadata(handle, metaData2);
			}
		}

		/// <summary>
		/// <para> change the visibility of an UGC item</para>
		/// </summary>
		public static bool SetItemVisibility(UGCUpdateHandle handle, Visibility eVisibility) {
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUGC_SetItemVisibility(handle, eVisibility);
		}

		/// <summary>
		/// <para> change the tags of an UGC item</para>
		/// </summary>
		public static bool SetItemTags(UGCUpdateHandle updateHandle, IList<string> pTags) {
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUGC_SetItemTags(updateHandle, new InteropHelp.SteamParamStringArray(pTags));
		}

		/// <summary>
		/// <para> update item content from this local folder</para>
		/// </summary>
		public static bool SetItemContent(UGCUpdateHandle handle, string pszContentFolder) {
			InteropHelp.TestIfAvailableClient();
			using (var pszContentFolder2 = new InteropHelp.UTF8StringHandle(pszContentFolder)) {
				return NativeMethods.ISteamUGC_SetItemContent(handle, pszContentFolder2);
			}
		}

		/// <summary>
		/// <para>  change preview image file for this item. pszPreviewFile points to local image file, which must be under 1MB in size</para>
		/// </summary>
		public static bool SetItemPreview(UGCUpdateHandle handle, string pszPreviewFile) {
			InteropHelp.TestIfAvailableClient();
			using (var pszPreviewFile2 = new InteropHelp.UTF8StringHandle(pszPreviewFile)) {
				return NativeMethods.ISteamUGC_SetItemPreview(handle, pszPreviewFile2);
			}
		}

		/// <summary>
		/// <para> remove any existing key-value tags with the specified key</para>
		/// </summary>
		public static bool RemoveItemKeyValueTags(UGCUpdateHandle handle, string key) {
			InteropHelp.TestIfAvailableClient();
			using (var key2 = new InteropHelp.UTF8StringHandle(key)) {
				return NativeMethods.ISteamUGC_RemoveItemKeyValueTags(handle, key2);
			}
		}

		/// <summary>
		/// <para> add new key-value tags for the item. Note that there can be multiple values for a tag.</para>
		/// </summary>
		public static bool AddItemKeyValueTag(UGCUpdateHandle handle, string key, string value) {
			InteropHelp.TestIfAvailableClient();
			using (var key2 = new InteropHelp.UTF8StringHandle(key))
			using (var value2 = new InteropHelp.UTF8StringHandle(value)) {
				return NativeMethods.ISteamUGC_AddItemKeyValueTag(handle, key2, value2);
			}
		}

		/// <summary>
		/// <para> commit update process started with StartItemUpdate()</para>
		/// </summary>
		public static SteamAPICall SubmitItemUpdate(UGCUpdateHandle handle, string changeNote) {
			InteropHelp.TestIfAvailableClient();
			using (var changeNote2 = new InteropHelp.UTF8StringHandle(changeNote)) {
				return (SteamAPICall)NativeMethods.ISteamUGC_SubmitItemUpdate(handle, changeNote2);
			}
		}

		public static EItemUpdateStatus GetItemUpdateProgress(UGCUpdateHandle handle, out ulong punBytesProcessed, out ulong punBytesTotal) {
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUGC_GetItemUpdateProgress(handle, out punBytesProcessed, out punBytesTotal);
		}

		/// <summary>
		/// <para> Steam Workshop Consumer API</para>
		/// </summary>
		public static SteamAPICall SetUserItemVote(PublishedFileId fileId, bool bVoteUp) {
			InteropHelp.TestIfAvailableClient();
			return (SteamAPICall)NativeMethods.ISteamUGC_SetUserItemVote(fileId, bVoteUp);
		}

		public static SteamAPICall GetUserItemVote(PublishedFileId fileId) {
			InteropHelp.TestIfAvailableClient();
			return (SteamAPICall)NativeMethods.ISteamUGC_GetUserItemVote(fileId);
		}

		public static SteamAPICall AddItemToFavorites(AppId nAppId, PublishedFileId fileId) {
			InteropHelp.TestIfAvailableClient();
			return (SteamAPICall)NativeMethods.ISteamUGC_AddItemToFavorites(nAppId, fileId);
		}

		public static SteamAPICall RemoveItemFromFavorites(AppId nAppId, PublishedFileId fileId) {
			InteropHelp.TestIfAvailableClient();
			return (SteamAPICall)NativeMethods.ISteamUGC_RemoveItemFromFavorites(nAppId, fileId);
		}

		/// <summary>
		/// <para> subscribe to this item, will be installed ASAP</para>
		/// </summary>
		public static SteamAPICall SubscribeItem(PublishedFileId fileId) {
			InteropHelp.TestIfAvailableClient();
			return (SteamAPICall)NativeMethods.ISteamUGC_SubscribeItem(fileId);
		}

		/// <summary>
		/// <para> unsubscribe from this item, will be uninstalled after game quits</para>
		/// </summary>
		private static SteamAPICall UnsubscribeItem(PublishedFileId fileId) {
			InteropHelp.TestIfAvailableClient();
			return (SteamAPICall)NativeMethods.ISteamUGC_UnsubscribeItem(fileId);
		}

        public static Task<RemoteStorageUnsubscribePublishedFileResult> UnsubscribeItemAsync(PublishedFileId item)
        {
            var tcs = new TaskCompletionSource<RemoteStorageUnsubscribePublishedFileResult>();
            var call = UnsubscribeItem(item);

            var result = new CallResult<RemoteStorageUnsubscribePublishedFileResult>((t, failure) =>
            {
                tcs.SetResult(t);
            });
            result.Set(call);

            return tcs.Task;
        }
        public static Task<RemoteStorageSubscribePublishedFileResult> SubscribeItemAsync(PublishedFileId item)
        {
            var tcs = new TaskCompletionSource<RemoteStorageSubscribePublishedFileResult>();
            var call = SubscribeItem(item);

            var result = new CallResult<RemoteStorageSubscribePublishedFileResult>((t, failure) =>
            {
                tcs.SetResult(t);
            });
            result.Set(call);

            return tcs.Task;
        }

	    public static Task DownloadAsync(PublishedFileId downloadItem)
	    {
	        return Task.Run(() =>
	        {
	            if (!DownloadItem(downloadItem, true))
                    return;
                Console.WriteLine("Starting download...");
                ulong lastProgress=0;
                while (true)
	            {
	                ulong downloaded;
	                ulong total;

	                if (!GetItemDownloadInfo(downloadItem, out downloaded, out total))
	                    break;
                    
	                if (lastProgress < downloaded)
	                    Console.WriteLine($"DL: {downloaded/1024}/{total/1024}kb");

                    if (downloaded > 0 && total > 0 && downloaded == total)
                        break;

                    lastProgress = downloaded;
	                Thread.Sleep(10);
                }
                Console.WriteLine("Stopping download...");
            });
	    }

        /// <summary>
        /// <para> number of subscribed items</para>
        /// </summary>
        public static uint GetNumSubscribedItems() {
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUGC_GetNumSubscribedItems();
		}

		/// <summary>
		/// <para> all subscribed item PublishFileIDs</para>
		/// </summary>
		public static uint GetSubscribedItems(PublishedFileId[] publishedFileId, uint cMaxEntries) {
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUGC_GetSubscribedItems(publishedFileId, cMaxEntries);
		}

		/// <summary>
		/// <para> get ItemState flags about item on this client</para>
		/// </summary>
		public static ItemState GetItemState(PublishedFileId fileId) {
			InteropHelp.TestIfAvailableClient();
			return (ItemState)NativeMethods.ISteamUGC_GetItemState(fileId);
		}

		/// <summary>
		/// <para> get info about currently installed content on disc for items that have EItemStateInstalled set</para>
		/// <para> if EItemStateLegacyItem is set, directoryPath contains the path to the legacy file itself (not a folder)</para>
		/// </summary>
		public static bool GetItemInstallInfo(PublishedFileId fileId, out ulong sizeOnDisk, out string directoryPath, uint directorySize, out uint timeStamp) {
			InteropHelp.TestIfAvailableClient();
			var folder2 = Marshal.AllocHGlobal((int)directorySize);
			var ret = NativeMethods.ISteamUGC_GetItemInstallInfo(fileId, out sizeOnDisk, folder2, directorySize, out timeStamp);
			directoryPath = ret ? InteropHelp.PtrToStringUTF8(folder2) : null;
			Marshal.FreeHGlobal(folder2);
			return ret;
		}

		/// <summary>
		/// <para> get info about pending update for items that have EItemStateNeedsUpdate set. totalBytes will be valid after download started once</para>
		/// </summary>
		public static bool GetItemDownloadInfo(PublishedFileId fileId, out ulong downloadedBytes, out ulong totalBytes) {
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUGC_GetItemDownloadInfo(fileId, out downloadedBytes, out totalBytes);
		}

		/// <summary>
		/// <para> download new or update already installed item. If function returns true, wait for DownloadItemResult. If the item is already installed,</para>
		/// <para> then files on disk should not be used until callback received. If item is not subscribed to, it will be cached for some time.</para>
		/// <para> If highPriority is set, any other item download will be suspended and this item downloaded ASAP.</para>
		/// </summary>
		public static bool DownloadItem(PublishedFileId fileId, bool highPriority) {
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUGC_DownloadItem(fileId, highPriority);
		}

		/// <summary>
		/// <para> game servers can set a specific workshop folder before issuing any UGC commands.</para>
		/// <para> This is helpful if you want to support multiple game servers running out of the same install folder</para>
		/// </summary>
		public static bool BInitWorkshopForGameServer(DepotId workshopDepotId, string pszFolder) {
			InteropHelp.TestIfAvailableClient();
			using (var pszFolder2 = new InteropHelp.UTF8StringHandle(pszFolder)) {
				return NativeMethods.ISteamUGC_BInitWorkshopForGameServer(workshopDepotId, pszFolder2);
			}
		}

		/// <summary>
		/// <para> SuspendDownloads( true ) will suspend all workshop downloads until SuspendDownloads( false ) is called or the game ends</para>
		/// </summary>
		public static void SuspendDownloads(bool bSuspend) {
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamUGC_SuspendDownloads(bSuspend);
		}
	}
}
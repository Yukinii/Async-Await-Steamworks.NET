using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Steamworks;

namespace PlayGround
{
    public class SteamManager
    {
        private static SteamManager _Instance;
        public static SteamManager Instance => _Instance ?? new SteamManager();

        private readonly SteamAPIWarningMessageHook_t _SteamApiWarningMessageHook;
        private static void SteamApiDebugTextHook(int nSeverity, System.Text.StringBuilder pchDebugText) => Debug.WriteLine(pchDebugText);
        
        public Callback<DownloadItemResult_t> DownloadRequestResult;
        public Callback<ItemInstalled_t> ItemInstalledCallback;
        public readonly Dictionary<ulong,string> PendingDownloads = new Dictionary<ulong, string>();

        public SteamManager()
        {
            if (_Instance == null)
            {
                _Instance = this;
            }
            Awake();
            if (_SteamApiWarningMessageHook != null)
                return;
            _SteamApiWarningMessageHook = SteamApiDebugTextHook;
            SteamClient.SetWarningMessageHook(_SteamApiWarningMessageHook);

            ItemInstalledCallback = Callback<ItemInstalled_t>.Create(ItemInstalled);
            DownloadRequestResult = Callback<DownloadItemResult_t>.Create(OnDownloadCompleted);

        }

        private void Awake()
        {
            try
            {
                if (SteamAPI.RestartAppIfNecessary((AppId_t)432200))
                    Environment.Exit(0);
                if (!SteamAPI.Init())
                    Environment.Exit(0);
            }
            catch
            {
                Environment.Exit(0);
            }
        }


        public uint CountWorkshopStuff() => SteamUGC.GetNumSubscribedItems();

        public void GetWorkshopStuff()
        {
            var numSubscribedItems = CountWorkshopStuff();
            var items = new PublishedFileId_t[numSubscribedItems];
            var numFound = SteamUGC.GetSubscribedItems(items, numSubscribedItems);
            Array.Resize(ref items, (int)numFound);

            CheckWorkshopStuff(items);
        }

        private void CheckWorkshopStuff(PublishedFileId_t[] items)
        {
            foreach (var item in items)
            {
                var state = (EItemState) SteamUGC.GetItemState(item);
                
                //var call = SteamUGC.UnsubscribeItem(item);

                //var result = new CallResult<RemoteStorageUnsubscribePublishedFileResult_t>((t, failure) =>
                //{
                //    Console.WriteLine("Unsubscribe: " + failure);
                //});
                //result.Set(call);

                

                VerifyStuff(item);

                Console.WriteLine("State: " + state);
            }
        }

        private void VerifyStuff(PublishedFileId_t item)
        {
            uint timeStamp;
            ulong sizeOnDisk;
            string folderPath;
            if (!SteamUGC.GetItemInstallInfo(item, out sizeOnDisk, out folderPath, 1024*1024*16, out timeStamp))
            {
                Console.WriteLine("Steam said its not there.");
                QueueDownload(item);
            }
            else if (!Directory.Exists(folderPath))
            {
                Console.WriteLine("Folder not found");
                QueueDownload(item);
            }
            else if (!Directory.EnumerateFiles(folderPath).Any())
            {
                Console.WriteLine("No files in folder.");
                QueueDownload(item);
            }
            else
            {
                Console.WriteLine($"{item._PublishedFileId} already installed.");
            }
        }

        private void QueueDownload(PublishedFileId_t item)
        {
            var call = SteamUGC.RequestUGCDetails(item, 0);
            var DetailRequestResult = new CallResult<SteamUGCRequestUGCDetailsResult_t>();
            DetailRequestResult.Set(call, (a, d) =>
            {
                Console.WriteLine($"{a._details._rgchDescription} - Is {(a._bCachedData ? "" : "not")} on your hdd!");

                if (!SteamUGC.DownloadItem(item, true))
                    return;

                Console.WriteLine("Download queued");
                PendingDownloads.Add(a._details._nPublishedFileId._PublishedFileId, a._details._rgchTitle);
            });
        }

        private void OnDownloadCompleted(DownloadItemResult_t param)
        {
            string name;
            if (PendingDownloads.TryGetValue(param._nPublishedFileId._PublishedFileId, out name))
                Console.WriteLine($"{name} - download result: {param._eResult}");
        }

        private async void ItemInstalled(ItemInstalled_t param)
        {
            var details = await GetItemDetailsAsync(param._nPublishedFileId);
            Console.WriteLine("Installed: "+details.Key._details._rgchTitle);
        }

        public void Update() => SteamAPI.RunCallbacks();


        /// <summary>
        /// Get's all the available info about the PublishedFieldId and if it exists locally.
        /// </summary>
        /// <param name="item">Item to get details for</param>
        /// <returns>KeyValuePair(Details,Bool (exists locally) )</returns>
        public Task<KeyValuePair<SteamUGCRequestUGCDetailsResult_t, bool>> GetItemDetailsAsync(PublishedFileId_t item)
        {
            var tcs = new TaskCompletionSource<KeyValuePair<SteamUGCRequestUGCDetailsResult_t, bool>>();
            var call = SteamUGC.RequestUGCDetails(item, 0);
            var detailRequestResult = new CallResult<SteamUGCRequestUGCDetailsResult_t>();
            detailRequestResult.Set(call, (a, d) => tcs.SetResult(new KeyValuePair<SteamUGCRequestUGCDetailsResult_t, bool>(a, d)));
            return tcs.Task;
        }
    }
}
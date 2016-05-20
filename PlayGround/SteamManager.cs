using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Steamworks;
using Steamworks.Steamworks.NET;

namespace PlayGround
{
    public class SteamManager
    {
        private static SteamManager _Instance;
        public static SteamManager Instance => _Instance ?? new SteamManager();

        private readonly SteamAPIWarningMessageHoot _SteamApiWarningMessageHook;
        private static void SteamApiDebugTextHook(int severity, System.Text.StringBuilder text) => Debug.WriteLine(text);

        public Callback<DownloadItemResult> DownloadRequestResult;
        public Callback<ItemInstalled> ItemInstalledCallback;
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

            ItemInstalledCallback = Callback<ItemInstalled>.Create(ItemInstalled);
            DownloadRequestResult = Callback<DownloadItemResult>.Create(OnDownloadCompleted);
        }

        private void Awake()
        {
            try
            {
                if (SteamAPI.RestartAppIfNecessary((AppId)432200))
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
            var items = new PublishedFileId[numSubscribedItems];
            var numFound = SteamUGC.GetSubscribedItems(items, numSubscribedItems);
            Array.Resize(ref items, (int)numFound);

            CheckWorkshopStuff(items);
        }

        private void CheckWorkshopStuff(IEnumerable<PublishedFileId> items)
        {
            foreach (var item in items)
            {
                var state = (ItemState) SteamUGC.GetItemState(item);
                
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

        private void VerifyStuff(PublishedFileId item)
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
                Console.WriteLine($"{item.Id} already installed.");
            }
        }

        private async void QueueDownload(PublishedFileId item)
        {
            var kvp = await SteamUGC.GetItemDetailsAsync(item);
            Console.WriteLine($"{kvp.Key.Details.Description} - Is {(kvp.Value ? "" : "not")} on your hdd!");

            if (!SteamUGC.DownloadItem(item, true))
                return;

            Console.WriteLine("Download queued");
            PendingDownloads.Add(kvp.Key.Details.Field.Id, kvp.Key.Details.Title);
        }

        private void OnDownloadCompleted(DownloadItemResult param)
        {
            string name;
            if (PendingDownloads.TryGetValue(param.PublishedField.Id, out name))
                Console.WriteLine($"{name} - download result: {param.ResultType}");
        }

        private async void ItemInstalled(ItemInstalled param)
        {
            var details = await SteamUGC.GetItemDetailsAsync(param.PublishedFileId);
            Console.WriteLine("Installed: "+details.Key.Details.Title);
        }

        public void Update() => SteamAPI.RunCallbacks();
        
    }
}
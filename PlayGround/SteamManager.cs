using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using Steamworks;

namespace PlayGround
{
    public class SteamManager
    {
        private static SteamManager _Instance;
        public static SteamManager Instance => _Instance ?? new SteamManager();

        public readonly Dictionary<ulong,string> PendingDownloads = new Dictionary<ulong, string>();

        public SteamManager()
        {
            if (_Instance == null)
                _Instance = this;

            if (SteamAPI.RestartAppIfNecessary((AppId)432200))
                Environment.Exit(0);
            if (!SteamAPI.Init())
                Environment.Exit(0);
            
            SteamUGC.OnDownloadCompleted += DownloadCompleted;
            SteamUGC.OnItemInstalled += ItemInstalled;
            SteamUGC.OnItemSubscribed += ItemSubscribed;
            SteamUGC.OnItemUnsubscribed += ItemUnsubscribed;
        }

        public async void Download()
        {
            var downloadItem = new PublishedFileId(597864941);
            //await SteamUGC.UnsubscribeItemAsync(downloadItem);
            //await SteamUGC.SubscribeItemAsync(downloadItem);

            await SteamUGC.DownloadAsync(downloadItem);

            //Console.WriteLine("Download queued");
            //SteamUGC.DownloadItem(downloadItem, true);
            //while (true)
            //{
            //    ulong downloaded;
            //    ulong total;
            //    if (SteamUGC.GetItemDownloadInfo(downloadItem, out downloaded, out total))
            //    {
            //        if (downloaded > 0 && total > 0)
            //            Console.WriteLine($"DL: {downloaded/1024}/{total/1024}kb");
            //        if (downloaded > 0 && total > 0 && downloaded == total)
            //            break;
            //    }
            //    Thread.Sleep(10);
            //}
        }

        public async void GetAllContent()
        {
            var contentDetails = await SteamUGC.QueryAllUGCAsync(UGCQuery.RankedByPublicationDate, MatchingUGCType.All, AppId.Invalid, (AppId) 432200, 1);

            foreach (var details in contentDetails)
                Console.WriteLine($"Title: {details.Title} - Type: {details.FileType} - Votes: {details.VotesUp}");
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

        private async void CheckWorkshopStuff(IEnumerable<PublishedFileId> items)
        {
            foreach (var item in items)
            {
                var state = SteamUGC.GetItemState(item);

                //await SteamUGC.UnsubscribeItemAsync(item);

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
            var result = await SteamUGC.GetItemDetailsAsync(item);
            Console.WriteLine($"{result.Details.Description} - Is {(result.CachedData ? "" : "not")} on your hdd!");

            if (!SteamUGC.DownloadItem(item, true))
                return;

            Console.WriteLine("Download queued");
            PendingDownloads.Add(result.Details.Field.Id, result.Details.Title);
        }

        private void DownloadCompleted(DownloadItemResult param)
        {
            string name;
            if (PendingDownloads.TryGetValue(param.PublishedField.Id, out name))
                Console.WriteLine($"{name} - download result: {param.ResultType}");
        }

        private async void ItemInstalled(ItemInstalled item)
        {
            var result = await SteamUGC.GetItemDetailsAsync(item.PublishedFile);
            Console.WriteLine("Installed: "+result.Details.Title);
        }

        private async void ItemUnsubscribed(RemoteStoragePublishedFileUnsubscribed item)
        {
            var result = await SteamUGC.GetItemDetailsAsync(item.PublishedFile);
            Console.WriteLine("Unsubscribed: " + result.Details.Title);
        }

        private async void ItemSubscribed(RemoteStoragePublishedFileSubscribed item)
        {
            var result = await SteamUGC.GetItemDetailsAsync(item.PublishedField);
            Console.WriteLine("Subscribed: " + result.Details.Title);
        }

        public void Update() => SteamAPI.RunCallbacks();
    }
}
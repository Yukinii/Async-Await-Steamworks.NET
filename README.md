#### FOR THE ORIGINAL CODE GO TO [STEAMWORKS.NET](https://github.com/rlabrecque/Steamworks.NET)

#Task Async/Await Steamworks.NET Wrapper


##### Getting Started

```csharp
        private static SteamManager _Instance;
        public static SteamManager Instance => _Instance ?? new SteamManager();
        
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
        }
```
Notice the two events on the bottom? No more CallbackResult mess!

##### The Async/Await Part

```csharp
private async void ItemInstalled(ItemInstalled item)
{
     var result = await SteamUGC.GetItemDetailsAsync(item.PublishedFileId);
     Console.WriteLine("Installed: "+result.Details.Title);
}
```


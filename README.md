### FOR THE ORIGINAL CODE GO TO [STEAMWORKS.NET](https://github.com/rlabrecque/Steamworks.NET)

Task Async/Await Steamworks.NET Wrapper
=======

1. Getting Started

```csharp
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

2. The Async/Await Part

```csharp
private async void ItemInstalled(ItemInstalled param)
{
    var details = await SteamUGC.GetItemDetailsAsync(param.PublishedFileId);
    Console.WriteLine("Installed: "+details.Details.Title);
}
```


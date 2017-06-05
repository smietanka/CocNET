[![Build Status](https://travis-ci.org/smietanka/CocNET.svg?branch=master)](https://travis-ci.org/smietanka/CocNET)
# CocNET
Wrapper to Clash Of Clans API in C# .NET

# How to use:
Downoload this project and build it.
Add to your application reference to CocNET.dll
In your application add: 
```
using CocNET;
using CocNET.Interfaces;
```

# Paste this code:
```
class Program
{
    static void Main(string[] args)
    {
        string token = "your token";
        Container container = CocCore.Instance(token).Container;

        ICocCoreLeagues leaguesCore = container.Resolve<ICocCoreLeagues>();
        var leagues = leaguesCore.GetLeagues("crystal");
        foreach (var eachLeague in leagues)
        {
            Console.WriteLine(eachLeague.Name);
        }
        // Same with:
        // - ICocCoreLocations
        // - ICocCorePlayers
        // - ICocCoreClans
        Console.ReadKey();
    }
}
```

# Clash Of Clans API Forum
Last reply in thread: http://forum.supercell.net/showthread.php/1017616-Clash-of-Clans-developer-website-now-live%21?p=6934363&viewfull=1#post6934363

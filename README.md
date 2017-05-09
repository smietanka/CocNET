![alt text](https://travis-ci.org/smietanka/CocNET.svg?branch=master)
# CocNET
Wrapper to Clash Of Clans API in C# .NET

# How to use:
Downoload this project and build it.
Add to your application reference to CocNET.dll
In your application add: 
```
using CocNET;
```

Paste this code:
```
class Program
{
    static void Main(string[] args)
    {
        string token = "";
        CocCore myCore = new CocCore(token);
        foreach(var eachLeague in myCore.GetLeagues())
        {
            Console.WriteLine(eachLeague.Name);
        }
    }
}
```

# Clash Of Clans API Forum
Last reply in thread: http://forum.supercell.net/showthread.php/1017616-Clash-of-Clans-developer-website-now-live%21?p=6934363&viewfull=1#post6934363

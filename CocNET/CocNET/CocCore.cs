using CocNET.Interfaces;
using CocNET.Methods;
using System;
using Funq;
using CocNET.Services;

namespace CocNET
{
    public class CocCore
    {
        private static object syncRoot = new Object();

        private const string TOKEN = "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzUxMiIsImtpZCI6IjI4YTMxOGY3LTAwMDAtYTFlYi03ZmExLTJjNzQzM2M2Y2NhNSJ9.eyJpc3MiOiJzdXBlcmNlbGwiLCJhdWQiOiJzdXBlcmNlbGw6Z2FtZWFwaSIsImp0aSI6IjU4NWEyYmVjLWZhMTEtNGM3Mi05YmQzLWU3ZWE5OWQ5NTM5YiIsImlhdCI6MTQ5NDM0NDA3NCwic3ViIjoiZGV2ZWxvcGVyLzhmY2VhNGY3LWE4NTctMDkyOS1hYTgyLTVkM2I1YThmOWRlNSIsInNjb3BlcyI6WyJjbGFzaCJdLCJsaW1pdHMiOlt7InRpZXIiOiJkZXZlbG9wZXIvc2lsdmVyIiwidHlwZSI6InRocm90dGxpbmcifSx7ImNpZHJzIjpbIjc4LjkuNzYuMTM3IiwiNTIuNDUuMTg1LjExNyIsIjUyLjU0LjMxLjExIiwiNTQuODcuMTQxLjI0NiIsIjU0Ljg3LjE4NS4zNSJdLCJ0eXBlIjoiY2xpZW50In1dfQ.6_fP6KKlJ-11eR8u47PQ85E0CATi1hMGwGOPUT3D-hL4QfaWkbP5chtVKJFMkSJjZmGA6-dlTPLn01iZGAoBxw"; //Example token

        public Container Container { get; set; }
        private static CocCore instance;
        public static CocCore Instance
        {
            get
            {
                lock(syncRoot)
                {
                    if (instance == null)
                    {
                        instance = new CocCore();
                    }
                }
                return instance;
            }
        }
        /// <summary>
        /// Initialize your core.
        /// </summary>
        private CocCore()
        {
            if (string.IsNullOrEmpty(TOKEN))
            {
                throw new ArgumentException("Token is nullable or empty.");
            }
            Container = new Funq.Container();

            Container.Register<Request>("Request", new Request(TOKEN));

            Container.Register<ICocCoreClans>(new CocCoreClans(Container.ResolveNamed<Request>("Request")));
            Container.Register<ICocCoreLocations>(new CocCoreLocations(Container.ResolveNamed<Request>("Request")));
            Container.Register<ICocCoreLeagues>(new CocCoreLeagues(Container.ResolveNamed<Request>("Request")));
            Container.Register<ICocCorePlayers>(new CocCorePlayers(Container.ResolveNamed<Request>("Request")));
        }
    }
}
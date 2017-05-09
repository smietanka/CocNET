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

        public Container Container { get; set; }
        private static CocCore instance;
        public static CocCore Instance(string token)
        {
            lock (syncRoot)
            {
                if (instance == null)
                {
                    instance = new CocCore(token);
                }
            }
            return instance;
        }
        /// <summary>
        /// Initialize your core.
        /// </summary>
        private CocCore(string token)
        {
            if (string.IsNullOrEmpty(token))
            {
                throw new ArgumentException("Token is nullable or empty.");
            }
            Container = new Funq.Container();

            Container.Register<Request>("Request", new Request(token));

            Container.Register<ICocCoreClans>(new CocCoreClans(Container.ResolveNamed<Request>("Request")));
            Container.Register<ICocCoreLocations>(new CocCoreLocations(Container.ResolveNamed<Request>("Request")));
            Container.Register<ICocCoreLeagues>(new CocCoreLeagues(Container.ResolveNamed<Request>("Request")));
            Container.Register<ICocCorePlayers>(new CocCorePlayers(Container.ResolveNamed<Request>("Request")));
        }
    }
}
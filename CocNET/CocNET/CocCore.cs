using CocNET.Interfaces;
using CocNET.Methods;
using Funq;
using CocNET.Services;

namespace CocNET
{
    public class CocCore
    {
        public Container Container { get; set; }

        public CocCore(string token)
        {
            if (Container == null)
            {
                Container = new Container();
            }
            Container.Register<Request>("Request", new Request(token));
            Container.Register<ICocCoreClans>(new CocCoreClans(Container.ResolveNamed<Request>("Request")));
            //Container.Register<ICocCoreLocations>(new CocCoreLocations(Container.ResolveNamed<Request>("Request")));
            //Container.Register<ICocCoreLeagues>(new CocCoreLeagues(Container.ResolveNamed<Request>("Request")));
            Container.Register<ICocCorePlayers>(new CocCorePlayers(Container.ResolveNamed<Request>("Request")));
        }
    }
}
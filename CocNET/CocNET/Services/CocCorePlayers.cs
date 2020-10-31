using CocNET.Interfaces;
using CocNET.Methods;
using CocNET.Types.Players;
using System;
using System.Web;

namespace CocNET.Services
{
    public class CocCorePlayers : ICocCorePlayers
    {
        private const string API_URL_PLAYERS = "players";
        private Request REQUEST;
        public CocCorePlayers(Request requestClient)
        {
            REQUEST = requestClient ?? throw new ArgumentNullException("RequestClient is null.");
        }

        public Player GetPlayer(string playerTag)
        {
            var call = REQUEST.GetCall(API_URL_PLAYERS, HttpUtility.UrlEncode(playerTag));
            var result = REQUEST.GetResponse<Player>(call);
            return result;
        }
    }
}

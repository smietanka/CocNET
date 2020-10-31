using CocNET.Types.Other;
using Newtonsoft.Json;

namespace CocNET.Types.Clans.LeagueWar
{
    public class LeagueRounds : BadRequest
    {
        [JsonProperty("warTags")]
        public string[] warTags { get; set; }
    }
}

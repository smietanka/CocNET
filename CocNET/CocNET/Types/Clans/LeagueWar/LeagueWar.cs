using CocNET.Types.Other;
using Newtonsoft.Json;

namespace CocNET.Types.Clans.LeagueWar
{
    public class LeagueWar : BadRequest
    {
        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("season")]
        public string Season { get; set; }

        [JsonProperty("clans")]
        public LeagueClan[] Clans { get; set; }

        [JsonProperty("rounds")]
        public LeagueRounds[] Rounds { get; set; }
    }
}

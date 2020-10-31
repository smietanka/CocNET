using CocNET.Types.Clans.CurrentWar;
using Newtonsoft.Json;

namespace CocNET.Types.Clans.LeagueWar
{
    public class LeagueMember
    {
        [JsonProperty("tag")]
        public string Tag { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("townhallLevel")]
        public int TownhallLevel { get; set; }

        [JsonProperty("mapPosition")]
        public int MapPosition { get; set; }

        [JsonProperty("attacks")]
        public WarAttack[] Attacks { get; set; }
    }
}

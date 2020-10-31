using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CocNET.Types.Clans.LeagueWar
{
    public class LeagueClan
    {
        [JsonProperty("tag")]
        public string Tag { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("clanLevel")]
        public int ClanLevel { get; set; }

        [JsonProperty("badgeUrls")]
        public Dictionary<string, string> BadgeUrls { get; set; }

        [JsonProperty("attacks")]
        public int Attacks { get; set; }

        [JsonProperty("stars")]
        public int Stars { get; set; }

        [JsonProperty("members")]
        public LeagueMember[] Members { get; set; }
    }
}

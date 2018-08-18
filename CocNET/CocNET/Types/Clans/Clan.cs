using CocNET.Types.Locations;
using CocNET.Types.Other;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CocNET.Types.Clans
{
    public class Clan : BadRequest
    {
        [JsonProperty("tag")]
        public string Tag { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("description")]
        public string Decsription { get; set; }

        [JsonProperty("location")]
        public Location Location { get; set; }

        [JsonProperty("badgeUrls")]
        public Dictionary<string, string> BadgeUrls { get; set; }

        [JsonProperty("warFrequency")]
        public string WarFrequency { get; set; }

        [JsonProperty("clanLevel")]
        public int ClanLevel { get; set; }

        [JsonProperty("warWins")]
        public int WarWins { get; set; }

        [JsonProperty("warWinStreak")]
        public int WarWinStreak { get; set; }

        [JsonProperty("clanPoints")]
        public int ClanPoints { get; set; }

        [JsonProperty("requiredTrophies")]
        public int RequiredTrophies { get; set; }

        [JsonProperty("members")]
        public int Members { get; set; }

        [JsonProperty("memberList")]
        public List<Member> MemberList { get; set; }

        [JsonProperty("clanVersusPoints")]
        public int ClanVersusPoints { get; set; }
    }
}

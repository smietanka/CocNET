using CocNET.Types.Leagues;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocNET.Types.Other
{
    public class Member
    {
        [JsonProperty("tag")]
        public string Tag { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("role")]
        public string Role { get; set; }
        [JsonProperty("expLevel")]
        public int ExpLevel { get; set; }
        [JsonProperty("league")]
        public League League { get; set; }
        [JsonProperty("trophies")]
        public int Trophies { get; set; }
        [JsonProperty("clanRank")]
        public int ClanRank { get; set; }
        [JsonProperty("previousClanRank")]
        public int PreviousClanRank { get; set; }
        [JsonProperty("donations")]
        public int Donations { get; set; }
        [JsonProperty("donationsReceived")]
        public int DonationsReceived { get; set; }
    }
}

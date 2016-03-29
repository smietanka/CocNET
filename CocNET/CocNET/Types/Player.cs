using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocNET.Types
{
    public class Player : BadRequest
    {
        [JsonProperty("tag")]
        public string Tag { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("expLevel")]
        public int ExpLevel { get; set; }
        [JsonProperty("trophies")]
        public int Trophies { get; set; }
        [JsonProperty("attackWins")]
        public int AttackWins { get; set; }
        [JsonProperty("defenseWins")]
        public int DefenseWins { get; set; }
        [JsonProperty("rank")]
        public int Rank { get; set; }
        [JsonProperty("previousRank")]
        public int PreviousRank { get; set; }
        [JsonProperty("clan")]
        public Clan Clan { get; set; }
        [JsonProperty("league")]
        public League League { get; set; }
    }
}

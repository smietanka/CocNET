using CocNET.Types.Clans;
using CocNET.Types.Leagues;
using CocNET.Types.Other;
using CocNET.Types.Other.Game;
using CocNET.Types.Other.Statistics;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CocNET.Types.Players
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
        [JsonProperty("bestTrophies")]
        public int BestTrophies { get; set; }
        [JsonProperty("donations")]
        public int Donations { get; set; }
        [JsonProperty("donationsReceived")]
        public int DonationsReceived { get; set; }
        [JsonProperty("warStars")]
        public int WarStars { get; set; }
        [JsonProperty("role")]
        public string Role { get; set; }
        [JsonProperty("townHallLevel")]
        public int TownHallLevel { get; set; }
        [JsonProperty("legendStatistics")]
        public LegendStatistics LegendStatistics { get; set; }
        [JsonProperty("achievements")]
        public List<Achievement> Achievements { get; set; }
        [JsonProperty("troops")]
        public List<Troop> Troops { get; set; }
        [JsonProperty("heroes")]
        public List<Hero> Heroes { get; set; }
        [JsonProperty("spells")]
        public List<Spell> Spells { get; set; }
        [JsonProperty("versusTrophies")]
        public int VersusTrophies { get; set; }
        [JsonProperty("bestVersusTrophies")]
        public int BestVersusTrophies { get; set; }
        [JsonProperty("versusBattleWins")]
        public int VersusBattleWins { get; set; }
        [JsonProperty("builderHallLevel")]
        public int BuilderHallLevel { get; set; }
    }
}

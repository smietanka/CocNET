using CocNET.Types.Leagues;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocNET.Types.Clans.CurrentWar
{
    public class WarMember
    {
        [JsonProperty("tag")]
        public string Tag { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("townhallLevel")]
        public int TownhallLevel { get; set; }

        [JsonProperty("mapPosition")]
        public int MapPosition { get; set; }

        [JsonProperty("opponentAttacks")]
        public int OpponentAttacks { get; set; }

        [JsonProperty("attacks")]
        public List<WarAttack> Attacks { get; set; }

        [JsonProperty("bestOpponentAttack")]
        public WarAttack BestOpponentAttack { get; set; }
    }
}

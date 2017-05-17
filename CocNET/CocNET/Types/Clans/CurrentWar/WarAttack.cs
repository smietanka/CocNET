using CocNET.Types.Leagues;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocNET.Types.Clans.CurrentWar
{
    public class WarAttack
    {
        [JsonProperty("attackerTag")]
        public string AttackerTag { get; set; }

        [JsonProperty("defenderTag")]
        public string DefenderTag { get; set; }

        [JsonProperty("stars")]
        public int Stars { get; set; }

        [JsonProperty("destructionPercentage")]
        public decimal DestructionPercentage { get; set; }

        [JsonProperty("order")]
        public int Order { get; set; }

    }
}
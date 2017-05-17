using CocNET.Types.Other;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocNET.Types.Clans.CurrentWar
{
    public class War : BadRequest
    {
        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("teamSize")]
        public int TeamSize { get; set; }

        [JsonProperty("preparationStartTime"), JsonConverter(typeof(CustomDateTimeConverter))]
        public DateTime PreparationStartTime { get; set; }

        [JsonProperty("startTime"), JsonConverter(typeof(CustomDateTimeConverter))]
        public DateTime StartTime { get; set; }

        [JsonProperty("endTime"), JsonConverter(typeof(CustomDateTimeConverter))]
        public DateTime EndTime { get; set; }

        [JsonProperty("clan")]
        public WarClan Clan { get; set; }

        [JsonProperty("opponent")]
        public WarClan Opponent { get; set; }

    }
}

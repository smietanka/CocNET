using CocNET.Types.Other;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocNET.Types.Clans
{
    public class WarLog
    {
        [JsonProperty("result")]
        public string Result { get; set; }

        [JsonProperty("endTime"), JsonConverter(typeof(CustomDateTimeConverter))]
        public DateTime EndTime { get; set; }

        [JsonProperty("teamSize")]
        public int TeamSize { get; set; }

        [JsonProperty("clan")]
        public Clan Clan { get; set; }

        [JsonProperty("opponent")]
        public Opponent Opponent { get; set; }
    }
}

using CocNET.Types.Other;
using Newtonsoft.Json;
using System;

namespace CocNET.Types.Clans.LeagueWar
{
    public class LeagueWarRound:BadRequest
    {
        public string state { get; set; }

        public int teamSize { get; set; }

        [JsonProperty("preparationStartTime"), JsonConverter(typeof(CustomDateTimeConverter))]
        public DateTime preparationStartTime { get; set; }

        [JsonProperty("startTime"), JsonConverter(typeof(CustomDateTimeConverter))]
        public DateTime StartTime { get; set; }

        [JsonProperty("endTime"), JsonConverter(typeof(CustomDateTimeConverter))]
        public DateTime EndTime { get; set; }

        [JsonProperty("clan")]
        public LeagueClan clan { get; set; }

        [JsonProperty("opponent")]
        public LeagueClan opponent { get; set; }
    }
}

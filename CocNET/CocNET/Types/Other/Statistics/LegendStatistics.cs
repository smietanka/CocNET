using CocNET.Types.Other.Game;
using Newtonsoft.Json;

namespace CocNET.Types.Other.Statistics
{
    public class LegendStatistics : BadRequest
    {
        [JsonProperty("legendTrophies")]
        public int LegendTrophies { get; set; }
        [JsonProperty("currentSeason")]
        public Season CurrentSeason { get; set; }
        [JsonProperty("previousSeason")]
        public Season PreviousSeason { get; set; }
        [JsonProperty("bestSeason")]
        public Season BestSeason { get; set; }
    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocNET.Types.Other.Game
{
    public class Achievement : BadRequest
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("stars")]
        public int Stars { get; set; }
        [JsonProperty("value")]
        public int Value { get; set; }
        [JsonProperty("target")]
        public int Target { get; set; }
        [JsonProperty("completionInfo")]
        public string CompletionInfo { get; set; }
        [JsonProperty("village")]
        public string Village { get; set; }
    }
}

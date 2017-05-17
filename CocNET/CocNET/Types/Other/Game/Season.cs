using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocNET.Types.Other.Game
{
    public class Season : BadRequest
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("rank")]
        public int Rank { get; set; }
        [JsonProperty("trophies")]
        public int Trophies { get; set; }
    }
}

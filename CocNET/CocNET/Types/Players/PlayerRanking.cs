using CocNET.Types.Other;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocNET.Types.Players
{
    public class PlayerRanking : BadRequest
    {
        [JsonProperty("items")]
        public List<Player> PlayersRanking { get; set; }
    }
}

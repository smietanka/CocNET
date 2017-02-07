using CocNET.Interfaces;
using CocNET.Types.Other;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocNET.Types.Clans
{
    public class ClanRanking : BadRequest
    {
        [JsonProperty("items")]
        public List<Clan> ClansRanking { get; set; }
    }
}

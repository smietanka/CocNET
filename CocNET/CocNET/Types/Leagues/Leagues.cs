using CocNET.Types.Other;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocNET.Types.Leagues
{
    public class Leagues : BadRequest
    {
        [JsonProperty("items")]
        public List<League> LeaguesList { get; set; }
        [JsonProperty("paging")]
        public Paging Paging { get; set; }
    }
}

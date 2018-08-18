using CocNET.Types.Clans;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CocNET.Types.Other
{
    public class SearchClan : BadRequest
    {
        [JsonProperty("items")]
        public List<Clan> ClanList { get; set; }
        [JsonProperty("paging")]
        public Paging Paging { get; set; }
    }
}

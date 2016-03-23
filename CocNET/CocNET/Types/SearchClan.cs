using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocNET.Types
{
    public class SearchClan : BadRequest
    {
        [JsonProperty("items")]
        public List<Clan> ClanList { get; set; }
        [JsonProperty("paging")]
        public Paging Paging { get; set; }
    }
}

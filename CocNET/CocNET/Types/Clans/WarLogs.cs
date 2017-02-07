using CocNET.Types.Other;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocNET.Types.Clans
{
    public class WarLogs : BadRequest
    {
        [JsonProperty("items")]
        public List<WarLog> WarLogList { get; set; }
        [JsonProperty("paging")]
        public Paging Paging { get; set; }
    }
}

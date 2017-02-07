using CocNET.Types.Other;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocNET.Types.Locations
{
    class Locations : BadRequest
    {
        [JsonProperty("items")]
        public List<Location> LocationList { get; set; }
        [JsonProperty("paging")]
        public Paging Paging { get; set; }
    }
}

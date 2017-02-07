using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocNET.Types.Other
{
    public class Cursors
    {
        [JsonProperty("after")]
        public string After { get; set; }
        [JsonProperty("before")]
        public string Before { get; set; }
    }
}

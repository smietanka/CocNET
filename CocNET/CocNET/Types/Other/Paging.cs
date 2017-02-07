using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocNET.Types.Other
{
    public class Paging
    {
        [JsonProperty("cursors")]
        public Cursors Cursors { get; set; }
    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocNET.Types.Other.Other
{
    public class Members : BadRequest
    {
        [JsonProperty("items")]
        public List<Member> MemberList { get; set; }
        [JsonProperty("paging")]
        public Paging Paging { get; set; }
    }
}

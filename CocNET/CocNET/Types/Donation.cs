using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocNET.Types
{
    public class Donation
    {
        [JsonProperty("donations")]
        public int Donations { get; set; }
        [JsonProperty("donationsReceived")]
        public int DonationsReceived { get; set; }
    }
}

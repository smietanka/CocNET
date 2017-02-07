using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using CocNET.Types.Other;

namespace CocNET.Types.Locations
{
    public class Location : BadRequest
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("isCountry")]
        public bool IsCountry { get; set; }
        [JsonProperty("countryCode")]
        public string CountryCode { get; set; }
    }
}

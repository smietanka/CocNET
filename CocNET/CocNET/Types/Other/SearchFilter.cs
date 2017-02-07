using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocNET.Types.Other
{
    public class SearchFilter
    {
        public string Name { get; set; }
        public WarFrequency WarFrequency { get; set; }
        public int LocationId { get; set; }
        public int MinMembers { get; set; }
        public int MaxMembers { get; set; }
        public int MinClanPoints { get; set; }
        public int MinClanLevel { get; set; }
        public int Limit { get; set; }
        public int After { get; set; }
        public int Before { get; set; }
    }
}


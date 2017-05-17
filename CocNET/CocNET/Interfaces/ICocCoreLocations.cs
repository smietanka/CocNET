using CocNET.Types.Locations;
using CocNET.Types.Other;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocNET.Interfaces
{
    public interface ICocCoreLocations
    {
        List<Location> GetLocations();
        List<Location> GetLocations(bool isCountry);
        Location GetLocations(int id);
        Location GetLocations(string locationName);
        Ranking GetLocationsRanking(int locationId, RankingId rankId);
    }
}

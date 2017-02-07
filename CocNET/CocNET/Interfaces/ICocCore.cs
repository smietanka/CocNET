using CocNET.Types;
using CocNET.Types.Clans;
using CocNET.Types.Leagues;
using CocNET.Types.Locations;
using CocNET.Types.Other;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocNET.Interfaces
{
    public interface ICocCore
    {
        #region LOCATIONS
        List<Location> GetLocations();
        List<Location> GetLocations(bool isCountry);
        Location GetLocations(int id);
        Location GetLocations(string locationName);
        Ranking GetLocationsRanking(int locationId, RankingId rankId);
        #endregion


        List<League> GetLeagues();
        League GetLeagues(int id);
        List<League> GetLeagues(string leagueName);

        #region CLANS
        Clan GetClans(string clanTag);
        List<WarLog> GetClanWarLogs(string clanTag);
        SearchClan GetClans(SearchFilter searchFilter);
        SearchClan GetClans(SearchFilter searchFilter, bool withMember);
        List<Member> GetClansMembers(string clanTag);

        #endregion

    }
}

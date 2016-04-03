using CocNET.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocNET.Interfaces
{
    public interface ICocCore
    {
        List<Location> GetLocations();
        List<Location> GetLocations(bool isCountry);
        Location GetLocations(int id);
        Location GetLocations(string locationName);

        List<League> GetLeagues();
        League GetLeagues(int id);
        List<League> GetLeagues(string leagueName);

        Clan GetClans(string clanTag);
        SearchClan GetClans(SearchFilter searchFilter);
        SearchClan GetClans(SearchFilter searchFilter, bool withMember);
        List<Member> GetClansMembers(string clanTag);
        Ranking GetRanking(int locationId, RankingId rankId);
    }
}

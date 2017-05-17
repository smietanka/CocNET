using CocNET.Types.Clans;
using CocNET.Types.Other;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocNET.Interfaces
{
    public interface ICocCoreClans
    {
        Clan GetClans(string clanTag);
        List<WarLog> GetClanWarLogs(string clanTag);
        SearchClan GetClans(SearchFilter searchFilter);
        SearchClan GetClans(SearchFilter searchFilter, bool withMember);
        List<Member> GetClansMembers(string clanTag);
    }
}

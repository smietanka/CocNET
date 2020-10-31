using CocNET.Interfaces;
using CocNET.Methods;
using CocNET.Types.Clans;
using CocNET.Types.Clans.CurrentWar;
using CocNET.Types.Other;
using CocNET.Types.Clans.LeagueWar;
using CocNET.Types.Other.Other;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Reflection;
using System.Web;

namespace CocNET.Services
{
    public class CocCoreClans : ICocCoreClans
    {
        private const string API_URL_CLANS = "clans";
        private Request Request;

        public CocCoreClans(Request requestClient)
        {
            Request = requestClient ?? throw new ArgumentNullException("RequestClient is null.");
        }
        /// <summary>
        /// Get clan by clan tag.
        /// </summary>
        /// <param name="clanTag">Clan tag.</param>
        /// <returns></returns>
        public Clan GetClans(string clanTag)
        {
            var call = Request.GetCall(API_URL_CLANS, HttpUtility.UrlEncode(clanTag));

            var myClan = Request.GetResponse<Clan>(call);

            return myClan;
        }

        /// <summary>
        /// Get list of clan members
        /// </summary>
        /// <param name="clanTag">Clan tag to get members.</param>
        /// <returns></returns>
        public List<Member> GetClansMembers(string clanTag)
        {
            var call = Request.GetCall(API_URL_CLANS, HttpUtility.UrlEncode(clanTag), "members");

            var members = Request.GetResponse<Members>(call);
            return members.MemberList;
        }

        /// <summary>
        /// Search all clans by criteria.
        /// </summary>
        /// <param name="searchFilter">SearchFilter with your criteria to search clans.</param>
        /// <returns></returns>
        public SearchClan GetClans(SearchFilter searchFilter)
        {
            NameValueCollection myCollection = new NameValueCollection();
            Dictionary<string, string> myDictionary = new Dictionary<string, string>();
            Type myType = searchFilter.GetType();
            IList<PropertyInfo> props = new List<PropertyInfo>(myType.GetProperties());

            foreach (PropertyInfo prop in props)
            {
                object propValue = prop.GetValue(searchFilter, null);
                var value = (propValue == null) || (propValue.Equals(0)) || (propValue.Equals(WarFrequency.undefined)) ? null : propValue.ToString();

                myCollection.Add(prop.Name.ToLower(), value);
            }
            var url = Request.GetCall(Request.Client.BaseUrl.AbsoluteUri, API_URL_CLANS);
            var call = UrlBuilder.BuildUri(url, myCollection);

            var myClans = Request.GetResponse<SearchClan>(API_URL_CLANS, call.Query);

            return myClans;
        }

        /// <summary>
        /// Search all clans by criteria with clan members. This may take a while.
        /// </summary>
        /// <param name="searchFilter">SearchFilter with your criteria to search clans.</param>
        /// <param name="withMember">True if you want search clans with clan members, else false.</param>
        /// <returns></returns>
        public SearchClan GetClans(SearchFilter searchFilter, bool withMember)
        {
            var result = new SearchClan();
            var myClansWithoutMembers = GetClans(searchFilter);

            if (withMember)
            {
                foreach (var eachClan in myClansWithoutMembers.ClanList)
                {
                    var clanMembers = GetClansMembers(eachClan.Tag);
                    eachClan.MemberList = clanMembers;
                }
                result = myClansWithoutMembers;
            }
            else
            {
                result = myClansWithoutMembers;
            }
            return result;
        }

        public List<WarLog> GetClanWarLogs(string clanTag)
        {
            var call = Request.GetCall(API_URL_CLANS, HttpUtility.UrlEncode(clanTag), "warlog");

            var warLogs = Request.GetResponse<WarLogs>(call);

            return warLogs.WarLogList;
        }

        public War GetCurrentWar(string clanTag)
        {
            var call = Request.GetCall(API_URL_CLANS, HttpUtility.UrlEncode(clanTag), "currentwar");
            
            var currentWar = Request.GetResponse<War>(call);

            return currentWar;
        }

        public LeagueWar GetCurrentWarLeague(string clanTag)
        {
            var call = Request.GetCall(API_URL_CLANS, HttpUtility.UrlEncode(clanTag), "currentwar", "leaguegroup");

            var currentWar = Request.GetResponse<LeagueWar>(call);

            return currentWar;
        }
        /// <summary>
        /// Warning! This is war Tag not clan Tag!!
        /// </summary>
        /// <param name="warTag"></param>
        /// <returns></returns>
        public LeagueWarRound GetCurrentWarLeagueRound(string warTag)
        {
            var call = Request.GetCall("clanwarleagues", "wars", HttpUtility.UrlEncode(warTag));

            var currentWar = Request.GetResponse<LeagueWarRound>(call);

            return currentWar;
        }
    }
}
using CocNET.Interfaces;
using CocNET.Methods;
using CocNET.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net;
using System.Web;
using System.Collections.Specialized;
using System.Reflection;
using RestSharp;
using CocNET.Types.Other;
using CocNET.Types.Locations;
using CocNET.Types.Other.Other;
using CocNET.Types.Clans;
using CocNET.Types.Players;
using CocNET.Types.Leagues;

namespace CocNET
{
    public class CocCore : ICocCore
    {
        private const string API_URL_CLANS = "clans";
        private const string API_URL_LEAGUES = "leagues";
        private const string API_URL_LOCATIONS = "locations";

        private string TOKEN;
        private Request REQUEST;

        /// <summary>
        /// Initialize your core.
        /// </summary>
        /// <param name="token">Your Clash Of Clans token.</param>
        public CocCore(string token)
        {
            if (string.IsNullOrEmpty(token))
            {
                throw new WebException("Invalid token.");
            }
            TOKEN = token;
            REQUEST = new Request(token);
        }

        /// <summary>
        /// Get all locations from Clash Of Clans.
        /// </summary>
        /// <returns>List of location.</returns>
        public List<Location> GetLocations()
        {
            string jsonString = REQUEST.GetResponse(API_URL_LOCATIONS);

            var myLocations = JsonConvert.DeserializeObject<Locations>(jsonString);

            return myLocations.LocationList;
        }

        /// <summary>
        /// Get all locations from Clash Of Clans where location is country.
        /// </summary>
        /// <param name="isCountry">True/False</param>
        /// <returns>List of location.</returns>
        public List<Location> GetLocations(bool isCountry)
        {
            List<Location> result = new List<Location>();
            var allLocations = GetLocations();
            if (isCountry)
            {
                result = allLocations.Where(x => x.IsCountry).ToList();
            }
            else
            {
                result = allLocations.Where(x => !x.IsCountry).ToList();
            }
            return result;

        }

        /// <summary>
        /// Get location by location id.
        /// </summary>
        /// <param name="id">Location id. Can get from GetLocations().</param>
        /// <returns>Location.</returns>
        public Location GetLocations(int id)
        {
            string call = REQUEST.GetCall(API_URL_LOCATIONS, id);

            string jsonString = REQUEST.GetResponse(call);
            var myLocation = JsonConvert.DeserializeObject<Location>(jsonString);

            return myLocation;
        }

        /// <summary>
        /// Get location by location name.
        /// </summary>
        /// <param name="locationName">Location name. Can get from GetLocations().</param>
        /// <returns>Location.</returns>
        public Location GetLocations(string locationName)
        {
            var myAllLocations = GetLocations();
            var locationByName = myAllLocations.Where(x => x.Name == locationName).Select(y => y).FirstOrDefault();
            if (locationByName == null)
            {
                locationByName = new Location { Reason = "notFound", Message = "Location not found." };
            }
            return locationByName;
        }

        /// <summary>
        /// Get all leagues from Clash Of Clans.
        /// </summary>
        /// <returns></returns>
        public List<League> GetLeagues()
        {
            string jsonString = REQUEST.GetResponse(API_URL_LEAGUES);

            var myLeagues = JsonConvert.DeserializeObject<Leagues>(jsonString);

            return myLeagues.LeaguesList;
        }

        /// <summary>
        /// Get league by league id.
        /// </summary>
        /// <param name="id">League id. Can get from GetLeagues().</param>
        /// <returns></returns>
        public League GetLeagues(int id)
        {
            League result = new League();
            var allLeagues = GetLeagues();
            var myLeague = allLeagues.Where(x => x.Id == id).FirstOrDefault();
            if (myLeague != null)
            {
                result = myLeague;
            }
            else
            {
                result.Error = "true";
                result.Reason = "Not found results.";
                result.Message = "There is no league with this id number.";
            }
            return result;
        }

        /// <summary>
        /// Get list of league by league name.
        /// </summary>
        /// <param name="leagueName">League name what you search.</param>
        /// <returns></returns>
        public List<League> GetLeagues(string leagueName)
        {
            List<League> result = new List<League>();
            var myAllLeagues = GetLeagues();

            //It's primitive searching...
            result = myAllLeagues.Where(x => x.Name.ToLower().Contains(leagueName.ToLower())).ToList();

            return result;
        }

        /// <summary>
        /// Get clan by clan tag.
        /// </summary>
        /// <param name="clanTag">Clan tag.</param>
        /// <returns></returns>
        public Clan GetClans(string clanTag)
        {
            var call = REQUEST.GetCall(API_URL_CLANS, HttpUtility.UrlEncode(clanTag));

            string jsonString = REQUEST.GetResponse(call);

            var myClan = JsonConvert.DeserializeObject<Clan>(jsonString);

            return myClan;
        }

        /// <summary>
        /// Get list of clan members
        /// </summary>
        /// <param name="clanTag">Clan tag to get members.</param>
        /// <returns></returns>
        public List<Member> GetClansMembers(string clanTag)
        {
            var call = REQUEST.GetCall(API_URL_CLANS, HttpUtility.UrlEncode(clanTag), "members");

            string jsonString = REQUEST.GetResponse(call);

            var members = JsonConvert.DeserializeObject<Members>(jsonString);
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
            var url = REQUEST.GetCall(REQUEST.GetClient().BaseUrl.AbsoluteUri, API_URL_CLANS);
            var call = UrlBuilder.BuildUri(url, myCollection);
            string jsonString = REQUEST.GetResponse(API_URL_CLANS, call.Query);

            SearchClan myClans = JsonConvert.DeserializeObject<SearchClan>(jsonString);

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

        public Ranking GetLocationsRanking(int locationId, RankingId rankId)
        {
            Ranking result = new Ranking();
            var myCall = REQUEST.GetCall(API_URL_LOCATIONS, locationId, "rankings", rankId);
            var jsonString = REQUEST.GetResponse(myCall);
            if (rankId == 0)
            {
                result.ClanRanking = JsonConvert.DeserializeObject<ClanRanking>(jsonString).ClansRanking;
            }
            else
            {
                result.PlayerRanking = JsonConvert.DeserializeObject<PlayerRanking>(jsonString).PlayersRanking;
            }
            return result;
        }

        public List<WarLog> GetClanWarLogs(string clanTag)
        {
            var call = REQUEST.GetCall(API_URL_CLANS, HttpUtility.UrlEncode(clanTag), "warlog");

            string jsonString = REQUEST.GetResponse(call);

            var members = JsonConvert.DeserializeObject<WarLogs>(jsonString);
            return members.WarLogList;
        }
    }
}
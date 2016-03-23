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
            if(string.IsNullOrEmpty(token))
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

            var myLocations = JsonConvert.DeserializeObject<Dictionary<string, List<Location>>>(jsonString);

            var result = myLocations.Where(x => x.Key == "items").Select(y => y.Value).FirstOrDefault();

            if (result == null)
            {
                throw new Exception("There is no key like 'items'");
            }

            return result;
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
            if(isCountry)
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

        public List<League> GetLeagues()
        {
            string jsonString = REQUEST.GetResponse(API_URL_LEAGUES);

            var myLeagues = JsonConvert.DeserializeObject<Dictionary<string, List<League>>>(jsonString);

            var result = myLeagues.Where(x => x.Key == "items").Select(y => y.Value).FirstOrDefault();

            if (result == null)
            {
                throw new Exception("There is no key like 'items'");
            }

            return result;
        }
        public League GetLeagues(int id)
        {
            League result = new League();
            var allLeagues = GetLeagues();
            var myLeague = allLeagues.Where(x => x.Id == id).FirstOrDefault();
            if(myLeague != null)
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

        public League GetLeagues(string leagueName)
        {
            throw new NotImplementedException();
        }

        public Clan GetClans(string clanTag)
        {
            var call = REQUEST.GetCall(API_URL_CLANS, HttpUtility.UrlEncode(clanTag));

            string jsonString = REQUEST.GetResponse(call);

            var myClan = JsonConvert.DeserializeObject<Clan>(jsonString);

            return myClan;
        }

        public List<Member> GetClans(string clanTag, bool members)
        {
            Clan myClan = new Clan();
            if(members)
            {
                var call = REQUEST.GetCall(API_URL_CLANS, HttpUtility.UrlEncode(clanTag), "members");

                string jsonString = REQUEST.GetResponse(call);

                var myClans = JsonConvert.DeserializeObject<Dictionary<string, List<Member>>>(jsonString);
                List<Member> myMemberList;
                myClans.TryGetValue("items", out myMemberList);
                if(myMemberList != null)
                {
                    myClan.MemberList = myMemberList;
                }
            }
            else
            {
                myClan = GetClans(clanTag);
            }
            return myClan.MemberList;
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
                    var clanMembers = GetClans(eachClan.Tag, true);
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
    }
}

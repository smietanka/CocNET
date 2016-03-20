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

namespace CocNET
{
    public class CocCore : ICocCore
    {
        private const string API_URL = "https://api.clashofclans.com/v1/";
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
            string jsonString = REQUEST.GetJsonString("https://api.clashofclans.com/v1/locations");

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
            throw new NotImplementedException();
        }
        /// <summary>
        /// Get location by location id.
        /// </summary>
        /// <param name="id">Location id. Can get from GetLocations().</param>
        /// <returns>Location.</returns>
        public Location GetLocations(int id)
        {
            string url = string.Format("https://api.clashofclans.com/v1/locations/{0}", id);
            string jsonString = REQUEST.GetJsonString(url);
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
            string jsonString = REQUEST.GetJsonString("https://api.clashofclans.com/v1/leagues");

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
            throw new NotImplementedException();
        }

        public League GetLeagues(string leagueName)
        {
            throw new NotImplementedException();
        }

        public Clan GetClans(string clanTag)
        {

            string sUrl = string.Format("https://api.clashofclans.com/v1/clans/{0}", HttpUtility.UrlEncode(clanTag));
           
            string jsonString = REQUEST.GetJsonString(sUrl);
            Clan myClan = JsonConvert.DeserializeObject<Clan>(jsonString);

            return myClan;


        }
    }
}

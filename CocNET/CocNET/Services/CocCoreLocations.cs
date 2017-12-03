using CocNET.Interfaces;
using CocNET.Methods;
using CocNET.Types.Clans;
using CocNET.Types.Locations;
using CocNET.Types.Other;
using CocNET.Types.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocNET.Services
{
    public class CocCoreLocations : ICocCoreLocations
    {
        private const string API_URL_LOCATIONS = "locations";
        private Request REQUEST;

        public CocCoreLocations(Request requestClient)
        {
            REQUEST = requestClient ?? throw new ArgumentNullException("RequestClient is null.");
        }
        /// <summary>
        /// Get all locations from Clash Of Clans.
        /// </summary>
        /// <returns>List of location.</returns>
        public List<Location> GetLocations()
        {
            var myLocations = REQUEST.GetResponse<Locations>(API_URL_LOCATIONS);

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

            var myLocation = REQUEST.GetResponse<Location>(call);

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

        public Ranking GetLocationsRanking(int locationId, RankingId rankId)
        {
            Ranking result = new Ranking();
            var myCall = REQUEST.GetCall(API_URL_LOCATIONS, locationId, "rankings", rankId);
            if(rankId.Equals(RankingId.clans))
            {
                result.ClanRanking = REQUEST.GetResponse<ClanRanking>(myCall).ClansRanking;
            }
            else
            {
                result.PlayerRanking = REQUEST.GetResponse<PlayerRanking>(myCall).PlayersRanking;
            }
            return result;
        }
    }
}
using CocNET.Interfaces;
using CocNET.Methods;
using CocNET.Types.Leagues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocNET.Services
{
    public class CocCoreLeagues : ICocCoreLeagues
    {
        private const string API_URL_LEAGUES = "leagues";
        private Request Request;

        public CocCoreLeagues(Request requestClient)
        {
            Request = requestClient ?? throw new ArgumentNullException("RequestClient is null.");
        }

        /// <summary>
        /// Get all leagues from Clash Of Clans.
        /// </summary>
        /// <returns></returns>
        public List<League> GetLeagues(int limit = 0, int after = 0, int before = 0)
        {
            var myLeagues = Request.GetResponse<Leagues>(API_URL_LEAGUES);

            if (myLeagues.LeaguesList == null || !myLeagues.LeaguesList.Any())
            {
                throw new ArgumentNullException(string.Format("{0}. {1}", myLeagues.Message, myLeagues.Reason));
            }
            return myLeagues.LeaguesList;
        }

        /// <summary>
        /// Get league by league id.
        /// </summary>
        /// <param name="id">League id. Can get from GetLeagues().</param>
        /// <returns></returns>
        public League GetLeague(int id)
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
    }
}

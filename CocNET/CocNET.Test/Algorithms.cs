using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoreLinq;
using System.Linq;
using CocNET.Types;
using CocNET.Methods;
using RestSharp;
using System.Diagnostics;
using CocNET.Includes;

namespace CocNET.Test
{
    [TestClass]
    public class Algorithms
    {
        public const string TOKEN = "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzUxMiIsImtpZCI6IjI4YTMxOGY3LTAwMDAtYTFlYi03ZmExLTJjNzQzM2M2Y2NhNSJ9.eyJpc3MiOiJzdXBlcmNlbGwiLCJhdWQiOiJzdXBlcmNlbGw6Z2FtZWFwaSIsImp0aSI6ImYxZTJmODE3LTJkNTktNGJmNS05NGQ3LTA1YjZkY2E2NDg4ZiIsImlhdCI6MTQ1ODE2MDI2Niwic3ViIjoiZGV2ZWxvcGVyLzhmY2VhNGY3LWE4NTctMDkyOS1hYTgyLTVkM2I1YThmOWRlNSIsInNjb3BlcyI6WyJjbGFzaCJdLCJsaW1pdHMiOlt7InRpZXIiOiJkZXZlbG9wZXIvc2lsdmVyIiwidHlwZSI6InRocm90dGxpbmcifSx7ImNpZHJzIjpbIjE3OC4zNy4xNzAuMjExIl0sInR5cGUiOiJjbGllbnQifV19.iZFcf2Tmrzdegx8-QaXr2-ajWcskzW3kN9Qe-SlcVDIxACIYi9hAZTuwM5vtQJCf3ehXpTGyTd9_XxsBBZLmXw"; //Example token
        public const string CLAN_TAG = "#9UVJGPV0"; // Example clan Tag -
        public CocCore MY_CORE;

        [TestInitialize]
        public void InitializeCore()
        {
            MY_CORE = new CocCore(TOKEN);
        }

        #region LOCATIONS
        [TestMethod, TestCategory("Algorithms")]
        public void Get_All_Locations()
        {
            var allLocations = MY_CORE.GetLocations();
            Assert.IsTrue(allLocations.Any());
        }

        [TestMethod, TestCategory("Algorithms")]
        public void Get_Location_By_Id()
        {
            int id = 32000000;
            var myLocation = MY_CORE.GetLocations(id);
            Assert.IsTrue(myLocation.Name == "Europe");

            int badId = 5464;
            var myBadLocation = MY_CORE.GetLocations(badId);
            Assert.IsTrue(myBadLocation.Reason == "badRequest");

        }

        [TestMethod, TestCategory("Algorithms")]
        public void Get_Location_By_Name()
        {
            string locationName = "Europe";
            var myLocation = MY_CORE.GetLocations(locationName);
            Assert.IsTrue(myLocation.Name == "Europe");
            Assert.IsTrue(myLocation.Id == 32000000);

            string badLocationName = "Europee";
            var myBadLocation = MY_CORE.GetLocations(badLocationName);
            Assert.IsTrue(myBadLocation.Reason == "notFound");

        }

        [TestMethod, TestCategory("Algorithms")]
        public void Get_All_Locations_Is_Country()
        {
            var myLocation = MY_CORE.GetLocations(true);
            Assert.IsTrue(myLocation.Any(x => x.IsCountry));

            var myFalseLocation = MY_CORE.GetLocations(false);

            Assert.IsTrue(myFalseLocation.Any(x => !x.IsCountry));
        }

        [TestMethod, TestCategory("Algorithms")]
        public void Get_Clan_Ranking()
        {
            int locationId = 32000187;
            var myRanking = MY_CORE.GetRanking(locationId, RankingId.clans);
            Assert.IsTrue(myRanking.ClanRanking.Any());

        }

        [TestMethod, TestCategory("Algorithms")]
        public void Get_Player_Ranking()
        {
            int locationId = Locations.GetLocationId(Locations.AllLocations.Poland);

            var myRankings = MY_CORE.GetRanking(locationId, RankingId.players);
            Assert.IsTrue(myRankings.PlayerRanking.Any());

        }
        #endregion

        #region LEAGUES
        [TestMethod, TestCategory("Algorithms")]
        public void Get_All_Leagues()
        {
            var allLeagues = MY_CORE.GetLeagues();
            Assert.IsTrue(allLeagues.Any());
        }

        [TestMethod, TestCategory("Algorithms")]
        public void Get_League_By_Id()
        {
            var league = MY_CORE.GetLeagues(29000005);
            Assert.IsTrue(league.Id == 29000005);


        }

        [TestMethod, TestCategory("Algorithms")]
        public void Get_All_Leagues_By_Name()
        {
            var allLeagues = MY_CORE.GetLeagues("bronze");
            Assert.IsTrue(allLeagues.Any());
            Assert.IsTrue(allLeagues.Any(x => x.Name.ToLower().Contains("bronze")));
        }
        #endregion

        #region CLANS
        [TestMethod, TestCategory("Algorithms")]
        public void Get_Clan()
        {
            var myClan = MY_CORE.GetClans(CLAN_TAG);
            Assert.IsTrue(myClan.Name == "Pandemia");
        }

        [TestMethod, TestCategory("Algorithms")]
        public void Search_Clan()
        {
            SearchFilter myFilter = new SearchFilter
            {
                Name = "aaa"
            };

            var myClan = MY_CORE.GetClans(myFilter);

            Assert.IsTrue(myClan.ClanList.Any());
        }

        [TestMethod, TestCategory("Algorithms")]
        public void Search_Clan_With_Members()
        {
            SearchFilter myFilter = new SearchFilter
            {
                Name = "Pandemia"
            };

            var myClan = MY_CORE.GetClans(myFilter, true);

            Assert.IsTrue(myClan.ClanList.Any());
        }

        [TestMethod, TestCategory("Algorithms")]
        public void Get_Clan_Members()
        {
            var myClan = MY_CORE.GetClansMembers(CLAN_TAG);
            Assert.IsTrue(myClan.Any());
        }
        #endregion
    }
}

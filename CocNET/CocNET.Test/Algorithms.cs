using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoreLinq;
using System.Linq;

namespace CocNET.Test
{
    [TestClass]
    public class Algorithms
    {
        public const string TOKEN = "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzUxMiIsImtpZCI6IjI4YTMxOGY3LTAwMDAtYTFlYi03ZmExLTJjNzQzM2M2Y2NhNSJ9.eyJpc3MiOiJzdXBlcmNlbGwiLCJhdWQiOiJzdXBlcmNlbGw6Z2FtZWFwaSIsImp0aSI6ImYxZTJmODE3LTJkNTktNGJmNS05NGQ3LTA1YjZkY2E2NDg4ZiIsImlhdCI6MTQ1ODE2MDI2Niwic3ViIjoiZGV2ZWxvcGVyLzhmY2VhNGY3LWE4NTctMDkyOS1hYTgyLTVkM2I1YThmOWRlNSIsInNjb3BlcyI6WyJjbGFzaCJdLCJsaW1pdHMiOlt7InRpZXIiOiJkZXZlbG9wZXIvc2lsdmVyIiwidHlwZSI6InRocm90dGxpbmcifSx7ImNpZHJzIjpbIjE3OC4zNy4xNzAuMjExIl0sInR5cGUiOiJjbGllbnQifV19.iZFcf2Tmrzdegx8-QaXr2-ajWcskzW3kN9Qe-SlcVDIxACIYi9hAZTuwM5vtQJCf3ehXpTGyTd9_XxsBBZLmXw"; //Example token
        public const string CLAN_TAG = "#9UVJGPV0"; // Example clan Tag
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
        public void Get_All_Locations_By_Id()
        {
            int id = 32000000;
            var myLocation = MY_CORE.GetLocations(id);
            Assert.IsTrue(myLocation.Name == "Europe");

            int badId = 5464;
            var myBadLocation = MY_CORE.GetLocations(badId);
            Assert.IsTrue(myBadLocation.Reason == "badRequest");

        }

        [TestMethod, TestCategory("Algorithms")]
        public void Get_All_Locations_By_Name()
        {
            string locationName = "Europe";
            var myLocation = MY_CORE.GetLocations(locationName);
            Assert.IsTrue(myLocation.Name == "Europe");
            Assert.IsTrue(myLocation.Id == 32000000);

            string badLocationName = "Europee";
            var myBadLocation = MY_CORE.GetLocations(badLocationName);
            Assert.IsTrue(myBadLocation.Reason == "notFound");

        }
        #endregion

        #region LEAGUES
        [TestMethod, TestCategory("Algorithms")]
        public void Get_All_Leagues()
        {
            var allLeagues = MY_CORE.GetLeagues();
            Assert.IsTrue(allLeagues.Any());
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
        public void Get_Clan_Members()
        {
            var myClan = MY_CORE.GetClans(CLAN_TAG, true);
            Assert.IsTrue(myClan.Any());

            var myClanSecond = MY_CORE.GetClans(CLAN_TAG, false);
            Assert.IsTrue(myClanSecond.Any());
        }
        #endregion

    }
}

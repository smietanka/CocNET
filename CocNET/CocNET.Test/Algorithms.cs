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
        #region LOCATIONS
        [TestMethod, TestCategory("Algorithms")]
        public void Get_All_Locations()
        {
            CocCore myCore = new CocCore(TOKEN);

            var allLocations = myCore.GetLocations();
            Assert.IsTrue(allLocations.Any());
        }

        [TestMethod, TestCategory("Algorithms")]
        public void Get_All_Locations_By_Id()
        {
            //Test
            CocCore myCore = new CocCore(TOKEN);

            int id = 32000000;
            var myLocation = myCore.GetLocations(id);
            Assert.IsTrue(myLocation.Name == "Europe");

            int badId = 5464;
            var myBadLocation = myCore.GetLocations(badId);
            Assert.IsTrue(myBadLocation.Reason == "badRequest");

        }

        [TestMethod, TestCategory("Algorithms")]
        public void Get_All_Locations_By_Name()
        {
            CocCore myCore = new CocCore(TOKEN);

            string locationName = "Europe";
            var myLocation = myCore.GetLocations(locationName);
            Assert.IsTrue(myLocation.Name == "Europe");
            Assert.IsTrue(myLocation.Id == 32000000);

            string badLocationName = "Europee";
            var myBadLocation = myCore.GetLocations(badLocationName);
            Assert.IsTrue(myBadLocation.Reason == "notFound");

        }
        #endregion

        #region LEAGUES
        [TestMethod, TestCategory("Algorithms")]
        public void Get_All_Leagues()
        {
            CocCore myCore = new CocCore(TOKEN);

            var allLeagues = myCore.GetLeagues();
            Assert.IsTrue(allLeagues.Any());
        }
        #endregion

        #region CLANS
        #endregion

    }
}

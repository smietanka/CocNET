using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoreLinq;
using System.Linq;

namespace CocNET.Test
{
    [TestClass]
    public class Algorithms
    {
        public const string TOKEN = ""; //Example token
        public const string CLAN_TAG = ""; // Example clan Tag
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
        #endregion

    }
}

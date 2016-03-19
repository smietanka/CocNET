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

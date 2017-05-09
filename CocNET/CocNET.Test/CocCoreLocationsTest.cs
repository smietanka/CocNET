using System;
using NUnit.Framework;
using CocNET.Interfaces;
using CocNET.Types.Other;
using MoreLinq;
using System.Linq;
using CocNET.Includes;

namespace CocNET.Test
{
    [TestFixture]
    public class CocCoreLocationsTest
    {
        private ICocCoreLocations LocationsCore;

        [OneTimeSetUp]
        public void InitializeCore()
        {
            LocationsCore = CocCore.Instance.Container.Resolve<ICocCoreLocations>();
        }

        [Test, Category("LocationsTest")]
        public void Get_All_Locations()
        {
            var allLocations = LocationsCore.GetLocations();
            Assert.IsTrue(allLocations.Any());
        }

        [Test, Category("LocationsTest")]
        public void Get_Location_By_Id()
        {
            int id = 32000000;
            var myLocation = LocationsCore.GetLocations(id);
            Assert.IsTrue(myLocation.Name == "Europe");

            int badId = 5464;
            var myBadLocation = LocationsCore.GetLocations(badId);
            Assert.IsTrue(myBadLocation.Reason == "badRequest");

        }

        [Test, Category("LocationsTest")]
        public void Get_Location_By_Name()
        {
            string locationName = "Europe";
            var myLocation = LocationsCore.GetLocations(locationName);
            Assert.IsTrue(myLocation.Name == "Europe");
            Assert.IsTrue(myLocation.Id == 32000000);

            string badLocationName = "Europee";
            var myBadLocation = LocationsCore.GetLocations(badLocationName);
            Assert.IsTrue(myBadLocation.Reason == "notFound");

        }

        [Test, Category("LocationsTest")]
        public void Get_All_Locations_Is_Country()
        {
            var myLocation = LocationsCore.GetLocations(true);
            Assert.IsTrue(myLocation.Any(x => x.IsCountry));

            var myFalseLocation = LocationsCore.GetLocations(false);

            Assert.IsTrue(myFalseLocation.Any(x => !x.IsCountry));
        }

        [Test, Category("LocationsTest")]
        public void Get_Clan_Ranking()
        {
            int locationId = 32000187;
            var myRanking = LocationsCore.GetLocationsRanking(locationId, RankingId.clans);
            Assert.IsTrue(myRanking.ClanRanking.Any());
        }


        [Test, Category("LocationsTest")]
        public void Get_Player_Ranking()
        {
            int locationId = Locations.GetLocationId(Locations.AllLocations.Poland);

            var myRankings = LocationsCore.GetLocationsRanking(locationId, RankingId.players);
            Assert.IsTrue(myRankings.PlayerRanking.Any());

        }
    }
}

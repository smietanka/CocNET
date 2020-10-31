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
        private const string TOKEN = "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzUxMiIsImtpZCI6IjI4YTMxOGY3LTAwMDAtYTFlYi03ZmExLTJjNzQzM2M2Y2NhNSJ9.eyJpc3MiOiJzdXBlcmNlbGwiLCJhdWQiOiJzdXBlcmNlbGw6Z2FtZWFwaSIsImp0aSI6IjU4NWEyYmVjLWZhMTEtNGM3Mi05YmQzLWU3ZWE5OWQ5NTM5YiIsImlhdCI6MTQ5NDM0NDA3NCwic3ViIjoiZGV2ZWxvcGVyLzhmY2VhNGY3LWE4NTctMDkyOS1hYTgyLTVkM2I1YThmOWRlNSIsInNjb3BlcyI6WyJjbGFzaCJdLCJsaW1pdHMiOlt7InRpZXIiOiJkZXZlbG9wZXIvc2lsdmVyIiwidHlwZSI6InRocm90dGxpbmcifSx7ImNpZHJzIjpbIjc4LjkuNzYuMTM3IiwiNTIuNDUuMTg1LjExNyIsIjUyLjU0LjMxLjExIiwiNTQuODcuMTQxLjI0NiIsIjU0Ljg3LjE4NS4zNSJdLCJ0eXBlIjoiY2xpZW50In1dfQ.6_fP6KKlJ-11eR8u47PQ85E0CATi1hMGwGOPUT3D-hL4QfaWkbP5chtVKJFMkSJjZmGA6-dlTPLn01iZGAoBxw"; //Example token

        private ICocCoreLocations LocationsCore;

        [OneTimeSetUp]
        public void InitializeCore()
        {
            LocationsCore = new CocCore(TOKEN).Container.Resolve<ICocCoreLocations>();
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

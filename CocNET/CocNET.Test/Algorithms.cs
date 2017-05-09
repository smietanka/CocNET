using MoreLinq;
using System.Linq;
using CocNET.Types;
using CocNET.Methods;
using RestSharp;
using System.Diagnostics;
using CocNET.Includes;
using System.Xml;
using CocNET.Types.Other;
using CocNET.Interfaces;
using NUnit.Framework;

namespace CocNET.Test
{
    [TestFixture]
    public class Algorithms
    {
        public const string TOKEN = "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzUxMiIsImtpZCI6IjI4YTMxOGY3LTAwMDAtYTFlYi03ZmExLTJjNzQzM2M2Y2NhNSJ9.eyJpc3MiOiJzdXBlcmNlbGwiLCJhdWQiOiJzdXBlcmNlbGw6Z2FtZWFwaSIsImp0aSI6IjU4NWEyYmVjLWZhMTEtNGM3Mi05YmQzLWU3ZWE5OWQ5NTM5YiIsImlhdCI6MTQ5NDM0NDA3NCwic3ViIjoiZGV2ZWxvcGVyLzhmY2VhNGY3LWE4NTctMDkyOS1hYTgyLTVkM2I1YThmOWRlNSIsInNjb3BlcyI6WyJjbGFzaCJdLCJsaW1pdHMiOlt7InRpZXIiOiJkZXZlbG9wZXIvc2lsdmVyIiwidHlwZSI6InRocm90dGxpbmcifSx7ImNpZHJzIjpbIjc4LjkuNzYuMTM3IiwiNTIuNDUuMTg1LjExNyIsIjUyLjU0LjMxLjExIiwiNTQuODcuMTQxLjI0NiIsIjU0Ljg3LjE4NS4zNSJdLCJ0eXBlIjoiY2xpZW50In1dfQ.6_fP6KKlJ-11eR8u47PQ85E0CATi1hMGwGOPUT3D-hL4QfaWkbP5chtVKJFMkSJjZmGA6-dlTPLn01iZGAoBxw"; //Example token
        public const string CLAN_TAG = "#9UVJGPV0"; // Example clan Tag -
        public ICocCore MY_CORE;

        [OneTimeSetUp]
        public void InitializeCore()
        {
            MY_CORE = new CocCore(TOKEN);
        }

        #region LOCATIONS
        [Test, Category("Algorithms")]
        public void Get_All_Locations()
        {
            var allLocations = MY_CORE.GetLocations();
            Assert.IsTrue(allLocations.Any());
        }

        [Test, Category("Algorithms")]
        public void Get_Location_By_Id()
        {
            int id = 32000000;
            var myLocation = MY_CORE.GetLocations(id);
            Assert.IsTrue(myLocation.Name == "Europe");

            int badId = 5464;
            var myBadLocation = MY_CORE.GetLocations(badId);
            Assert.IsTrue(myBadLocation.Reason == "badRequest");

        }

        [Test, Category("Algorithms")]
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

        [Test, Category("Algorithms")]
        public void Get_All_Locations_Is_Country()
        {
            var myLocation = MY_CORE.GetLocations(true);
            Assert.IsTrue(myLocation.Any(x => x.IsCountry));

            var myFalseLocation = MY_CORE.GetLocations(false);

            Assert.IsTrue(myFalseLocation.Any(x => !x.IsCountry));
        }

        [Test, Category("Algorithms")]
        public void Get_Clan_Ranking()
        {
            int locationId = 32000187;
            var myRanking = MY_CORE.GetLocationsRanking(locationId, RankingId.clans);
            Assert.IsTrue(myRanking.ClanRanking.Any());
        }

        [Test, Category("Algorithms")]
        public void Get_Clan_WarLogs()
        {
            var warlogs = MY_CORE.GetClanWarLogs(CLAN_TAG);
            Assert.IsTrue(warlogs.Any());
        }

        [Test, Category("Algorithms")]
        public void Get_Player_Ranking()
        {
            int locationId = Locations.GetLocationId(Locations.AllLocations.Poland);

            var myRankings = MY_CORE.GetLocationsRanking(locationId, RankingId.players);
            Assert.IsTrue(myRankings.PlayerRanking.Any());

        }
        #endregion

        #region LEAGUES
        [Test, Category("Algorithms")]
        public void Get_All_Leagues()
        {
            var allLeagues = MY_CORE.GetLeagues();
            Assert.IsTrue(allLeagues.Any());
        }

        [Test, Category("Algorithms")]
        public void Get_League_By_Id()
        {
            var league = MY_CORE.GetLeagues(29000005);
            Assert.IsTrue(league.Id == 29000005);


        }

        [Test, Category("Algorithms")]
        public void Get_All_Leagues_By_Name()
        {
            var allLeagues = MY_CORE.GetLeagues("bronze");
            Assert.IsTrue(allLeagues.Any());
            Assert.IsTrue(allLeagues.Any(x => x.Name.ToLower().Contains("bronze")));
        }
        #endregion

        #region CLANS
        [Test, Category("Algorithms")]
        public void Get_Clan()
        {
            var myClan = MY_CORE.GetClans(CLAN_TAG);
            Assert.IsTrue(myClan.Name == "Pandemia");
        }

        [Test, Category("Algorithms")]
        public void Search_Clan()
        {
            SearchFilter myFilter = new SearchFilter
            {
                Name = "aaa"
            };

            var myClan = MY_CORE.GetClans(myFilter);

            Assert.IsTrue(myClan.ClanList.Any());
        }

        [Test, Category("Algorithms")]
        public void Search_Clan_With_Members()
        {
            SearchFilter myFilter = new SearchFilter
            {
                Name = "Pandemia"
            };

            var myClan = MY_CORE.GetClans(myFilter, true);

            Assert.IsTrue(myClan.ClanList.Any());
        }

        [Test, Category("Algorithms")]
        public void Get_Clan_Members()
        {
            var myClan = MY_CORE.GetClansMembers(CLAN_TAG);
            Assert.IsTrue(myClan.Any());
        }
        #endregion
    }
}

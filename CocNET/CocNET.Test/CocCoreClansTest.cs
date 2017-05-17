using System;
using NUnit.Framework;
using CocNET.Interfaces;
using CocNET.Types.Other;
using MoreLinq;
using System.Linq;

namespace CocNET.Test
{
    [TestFixture]
    public class CocCoreClansTest
    {
        public const string CLAN_TAG = "#9UVJGPV0"; // Example clan Tag
        private const string TOKEN = "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzUxMiIsImtpZCI6IjI4YTMxOGY3LTAwMDAtYTFlYi03ZmExLTJjNzQzM2M2Y2NhNSJ9.eyJpc3MiOiJzdXBlcmNlbGwiLCJhdWQiOiJzdXBlcmNlbGw6Z2FtZWFwaSIsImp0aSI6IjU4NWEyYmVjLWZhMTEtNGM3Mi05YmQzLWU3ZWE5OWQ5NTM5YiIsImlhdCI6MTQ5NDM0NDA3NCwic3ViIjoiZGV2ZWxvcGVyLzhmY2VhNGY3LWE4NTctMDkyOS1hYTgyLTVkM2I1YThmOWRlNSIsInNjb3BlcyI6WyJjbGFzaCJdLCJsaW1pdHMiOlt7InRpZXIiOiJkZXZlbG9wZXIvc2lsdmVyIiwidHlwZSI6InRocm90dGxpbmcifSx7ImNpZHJzIjpbIjc4LjkuNzYuMTM3IiwiNTIuNDUuMTg1LjExNyIsIjUyLjU0LjMxLjExIiwiNTQuODcuMTQxLjI0NiIsIjU0Ljg3LjE4NS4zNSJdLCJ0eXBlIjoiY2xpZW50In1dfQ.6_fP6KKlJ-11eR8u47PQ85E0CATi1hMGwGOPUT3D-hL4QfaWkbP5chtVKJFMkSJjZmGA6-dlTPLn01iZGAoBxw"; //Example token

        private ICocCoreClans ClansCore;

        [OneTimeSetUp]
        public void InitializeCore()
        {
            ClansCore = CocCore.Instance(TOKEN).Container.Resolve<ICocCoreClans>();
        }

        [Test, Category("ClansTest")]
        public void Get_Clan()
        {
            var myClan = ClansCore.GetClans(CLAN_TAG);
            Assert.IsTrue(myClan.Name == "Pandemia");
        }

        [Test, Category("ClansTest")]
        public void Search_Clan()
        {
            SearchFilter myFilter = new SearchFilter
            {
                Name = "aaa"
            };

            var myClan = ClansCore.GetClans(myFilter);

            Assert.IsTrue(myClan.ClanList.Any());
        }

        [Test, Category("ClansTest")]
        public void Search_Clan_With_Members()
        {
            SearchFilter myFilter = new SearchFilter
            {
                Name = "Pandemia"
            };

            var myClan = ClansCore.GetClans(myFilter, true);

            Assert.IsTrue(myClan.ClanList.Any());
        }

        [Test, Category("ClansTest")]
        public void Get_Clan_Members()
        {
            var myClan = ClansCore.GetClansMembers(CLAN_TAG);
            Assert.IsTrue(myClan.Any());
        }
        [Test, Category("ClansTest")]
        public void Get_Clan_WarLogs()
        {
            var warlogs = ClansCore.GetClanWarLogs(CLAN_TAG);
            Assert.IsTrue(warlogs.Any());
        }
        [Test, Category("ClansTest")]
        public void Get_Clan_CurrentWar()
        {
            var currentWar = ClansCore.GetCurrentWar(CLAN_TAG);
            Assert.IsNotNull(currentWar);
        }
    }
}

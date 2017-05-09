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
        public const string CLAN_TAG = "#9UVJGPV0"; // Example clan Tag -
        private ICocCoreClans ClansCore;

        [OneTimeSetUp]
        public void InitializeCore()
        {
            ClansCore = CocCore.Instance.Container.Resolve<ICocCoreClans>();
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
    }
}

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
    public class CocCoreLeaguesTest
    {
        private ICocCoreLeagues LeaguesCore;

        [OneTimeSetUp]
        public void InitializeCore()
        {
            LeaguesCore = CocCore.Instance.Container.Resolve<ICocCoreLeagues>();
        }

        [Test, Category("LeaguesTest")]
        public void Get_All_Leagues()
        {
            var allLeagues = LeaguesCore.GetLeagues();
            Assert.IsTrue(allLeagues.Any());
        }

        [Test, Category("LeaguesTest")]
        public void Get_League_By_Id()
        {
            var league = LeaguesCore.GetLeagues(29000005);
            Assert.IsTrue(league.Id == 29000005);
        }

        [Test, Category("LeaguesTest")]
        public void Get_All_Leagues_By_Name()
        {
            var allLeagues = LeaguesCore.GetLeagues("bronze");
            Assert.IsTrue(allLeagues.Any());
            Assert.IsTrue(allLeagues.Any(x => x.Name.ToLower().Contains("bronze")));
        }
    }
}

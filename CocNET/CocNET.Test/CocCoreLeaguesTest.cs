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
        private const string TOKEN = "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzUxMiIsImtpZCI6IjI4YTMxOGY3LTAwMDAtYTFlYi03ZmExLTJjNzQzM2M2Y2NhNSJ9.eyJpc3MiOiJzdXBlcmNlbGwiLCJhdWQiOiJzdXBlcmNlbGw6Z2FtZWFwaSIsImp0aSI6IjU4NWEyYmVjLWZhMTEtNGM3Mi05YmQzLWU3ZWE5OWQ5NTM5YiIsImlhdCI6MTQ5NDM0NDA3NCwic3ViIjoiZGV2ZWxvcGVyLzhmY2VhNGY3LWE4NTctMDkyOS1hYTgyLTVkM2I1YThmOWRlNSIsInNjb3BlcyI6WyJjbGFzaCJdLCJsaW1pdHMiOlt7InRpZXIiOiJkZXZlbG9wZXIvc2lsdmVyIiwidHlwZSI6InRocm90dGxpbmcifSx7ImNpZHJzIjpbIjc4LjkuNzYuMTM3IiwiNTIuNDUuMTg1LjExNyIsIjUyLjU0LjMxLjExIiwiNTQuODcuMTQxLjI0NiIsIjU0Ljg3LjE4NS4zNSJdLCJ0eXBlIjoiY2xpZW50In1dfQ.6_fP6KKlJ-11eR8u47PQ85E0CATi1hMGwGOPUT3D-hL4QfaWkbP5chtVKJFMkSJjZmGA6-dlTPLn01iZGAoBxw"; //Example token

        private ICocCoreLeagues LeaguesCore;

        [OneTimeSetUp]
        public void InitializeCore()
        {
            LeaguesCore = CocCore.Instance(TOKEN).Container.Resolve<ICocCoreLeagues>();
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

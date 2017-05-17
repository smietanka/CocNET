using CocNET.Types.Leagues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocNET.Interfaces
{
    public interface ICocCoreLeagues
    {
        List<League> GetLeagues(int limit = 0, int after = 0, int before = 0);
        League GetLeague(int id);
        List<League> GetLeagues(string leagueName);


    }
}

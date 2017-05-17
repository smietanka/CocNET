using CocNET.Types.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocNET.Interfaces
{
    public interface ICocCorePlayers
    {
        Player GetPlayer(string playerTag);
    }
}

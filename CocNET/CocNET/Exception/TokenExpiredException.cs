using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocNET
{
    public class TokenExpiredException:Exception
    {
        public TokenExpiredException() : base()
        {

        }
        public TokenExpiredException(string message):base(message)
        {

        }
    }
}

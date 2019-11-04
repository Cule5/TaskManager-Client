using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager_Client.Utils
{
    public static class TokenWraper
    {
        public static string Token { get; set; }
        public static long Expires { get; set; }
    }
}

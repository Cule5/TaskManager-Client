using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager_Client.Helpers
{
    public static class RequestHelper
    {
        public static HttpClient Client { get; private set; }

        public static void Configure()
        {
            Client=new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:51524");
        }
    }
}

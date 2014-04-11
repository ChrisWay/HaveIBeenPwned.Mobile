using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace HaveIBeenPwned.Mobile.Core.Services
{
    public static class HttpClientFactory
    {
        static HttpClientFactory()
        {
            Get = () => new HttpClient();
        }

        public static Func<HttpClient> Get { get; set; }
    }
}

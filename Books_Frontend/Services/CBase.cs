using Books_Frontend.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Books_Frontend.Services
{
    public class CBase : IBase
    {
        public HttpClient Initial()
        {
            HttpClient client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:44340/books")
            };
            return client;
        }

    }
}

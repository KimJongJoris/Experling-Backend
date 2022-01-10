using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Experling_API;

namespace Integration_Tests
{
    public class Base
    {
        protected readonly HttpClient TestClient;

        protected Base()
        {
            var Factory = new TestWebAppFactory<Startup>();
            TestClient = Factory.CreateClient();
            TestClient.BaseAddress = new Uri("http://localhost:44327/api/");
        }

    }
}

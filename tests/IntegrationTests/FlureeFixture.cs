using Xunit;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc.Testing;

namespace IntegrationTests
{
    public class FlureeFixture : IClassFixture<WebApplicationFactory<Api.Startup>>
    {
        public string ApiBaseUrl { get; set; } = Config.BASE_URL;
        public HttpClient _flureeClient;

        public FlureeFixture()
        {
            _flureeClient = new HttpClient();
        }
        public void Test1()
        {

        }
    }
}
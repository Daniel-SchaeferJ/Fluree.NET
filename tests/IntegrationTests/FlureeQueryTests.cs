using Flurl.Http;
using Flurl.Http.Configuration;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace IntegrationTests
{
    [Trait("Category", "Query")]
    public class FlureeQueryTests
    {
        private readonly IFlurlClient _flurlClient;
        private readonly IConfiguration _configuration;
        public FlureeQueryTests(IFlurlClientFactory factory, IConfiguration configuration)
        {
            _flurlClient = factory.Get("http://localhost:8090");
            _configuration = configuration;
        }

        [Fact]
        public async Task CanQueryData()
        {
            //Arrange
            var yeet = _configuration["fluree"];
            //Act
            var result = await _flurlClient.Request("/fdb/reporting/yearly/query").PostJsonAsync(new JsonSqlQuery
            {
                SqlSelect = new List<string>()
                        {
                            "*"
                        },
                SqlFrom = "TopSellingProduct"
            }).ReceiveJsonList();

           
            //Assert
            Assert.NotEmpty(result);
        }

        private class JsonSqlQuery
        {
            [JsonProperty("select")]
            public List<string>? SqlSelect { get; set; }
            [JsonProperty("from")]
            public string? SqlFrom { get; set; }
            
            //[JsonProperty("where")]
            //public string? SqlWhere { get; set; }

        }
    }
}

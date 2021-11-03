using Flurl.Http;
using Flurl.Http.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace IntegrationTests
{
    [Trait("Category", "Query")]
    public class FlureeQueryTests
    {
        private readonly IFlurlClient _flurlClient;
        public FlureeQueryTests(IFlurlClientFactory factory)
        {
            _flurlClient = factory.Get("http://localhost:8090");
        }

        [Fact]
        public async Task CanQueryData()
        {
            //Arrange

            //Act
            var result = await _flurlClient.Request("/fdb/reporting/yearly/query").PostJsonAsync(new JsonSqlQuery
            {
                SqlSelect = new List<string>()
                        {
                            "*"
                        },
                SqlFrom = "TopSellingProduct"
            });

            //await result.GetJsonAsync();
            //Assert
            Assert.Equal(HttpStatusCode.OK, result.ResponseMessage.StatusCode);
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

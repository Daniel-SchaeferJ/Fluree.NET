using FlureeDotnetLibrary.FlureeQuery;
using FlureeDotnetLibrary.FlureeQuery.Model;
using Flurl.Http;
using Flurl.Http.Configuration;
using Microsoft.Extensions.Configuration;
using Moq;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace IntegrationTests
{
    [Trait("Category", "Query")]
    public class FlureeQueryTests
    {
        private readonly IExecuteFlureeQuery _executeFlureeQuery;
        public FlureeQueryTests(IConfiguration configuration, IExecuteFlureeQuery executeFlureeQuery)
        {
            _executeFlureeQuery = executeFlureeQuery;
        }

        [Fact]
        public async Task CanQueryData()
        {
            //Arrange

            //Act
            var result = await _executeFlureeQuery.ExectureSingleFlureeQuery<dynamic>(new QueryBuilder
            {
                SqlSelect = new List<string>()
                        {
                            "*"
                        },
                SqlFrom = "TopSellingProduct"
            }
            ,"reporting", "yearly"); 



            //Assert
            Assert.NotEmpty(result);
        }

        private class JsonSqlQuery
        {
            [JsonProperty("select")]
            public List<string>? SqlSelect { get; set; }
            [JsonProperty("from")]
            public string? SqlFrom { get; set; }
            
            [JsonProperty("where")]
            public string? SqlWhere { get; set; }

        }
    }
}

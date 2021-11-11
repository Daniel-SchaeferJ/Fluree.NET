using FlureeDotnetLibrary.FlureeQuery;
using FlureeDotnetLibrary.FlureeQuery.Model;
using Flurl.Http.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace IntegrationTests
{
    [Trait("Category", "Query")]
    public class FlureeQueryTests
    {
        private readonly IFlureeQueryService _flureeQueryService;
        public FlureeQueryTests()
        {
            _flureeQueryService = new FlureeQueryService(
                new PerBaseUrlFlurlClientFactory(),
                "http://localhost:8090");
        }

        [Fact]
        public async Task CanQueryData()
        {
            //Arrange
            var query = new FlureeQueryBuilder
            {
                SqlSelect = new List<string>()
                        {
                            "*"
                        },
                SqlFrom = "TopSellingProduct"
            };
            //Act
            var result = await _flureeQueryService.ExecuteSingleQuery("test", "ledger1", query);

            //Assert
            Assert.True(result is not null); 
        }
    }
}

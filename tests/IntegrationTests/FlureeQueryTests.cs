using FlureeDotnetLibrary.FlureeQuery;
using FlureeDotnetLibrary.FlureeQuery.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace IntegrationTests
{
    [Trait("Category", "Query")]
    public class FlureeQueryTests
    {
        private readonly IExecuteFlureeQuery _executeFlureeQuery;
        public FlureeQueryTests(IExecuteFlureeQuery executeFlureeQuery)
        {
            _executeFlureeQuery = executeFlureeQuery;
        }

        [Fact]
        public async Task CanQueryData()
        {
            //Arrange
            var query = new ExtendedQuery
            {
                SqlSelect = new List<string>()
                        {
                            "*"
                        },
                SqlFrom = "TopSellingProduct"
            };
            //Act
            var result = await _executeFlureeQuery.ExectureSingleFlureeQuery("test", "ledger1", query);

            //Assert
            Assert.True(result is not null); 
        }

        private class ExtendedQuery : QueryBuilder
        {

        }
    }
}

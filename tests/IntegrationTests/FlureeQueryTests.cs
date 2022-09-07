﻿using FlureeDotnetLibrary.FlureeQuery;
using FlureeDotnetLibrary.FlureeQuery.Model;
using Flurl.Http.Configuration;
using Newtonsoft.Json;
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
                SqlFrom = "collection1"
            };
            //Act
            var result = await _flureeQueryService.ExecuteSingleQuery<QueryObjectResponse>("test", "ledger1", query);

            //Assert
            Assert.True(result.Count >= 10000);

        }
        private class QueryObjectResponse
        {
            [JsonProperty("collection1/quantity")]
            public int quantity { get; set; }
        }
    }


}

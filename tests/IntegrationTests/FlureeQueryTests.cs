using System.Collections.Generic;
using System.Threading.Tasks;
using FlureeDotnetLibrary.FlureeQuery;
using FlureeDotnetLibrary.FlureeQuery.Model;
using Flurl.Http.Configuration;
using Newtonsoft.Json;
using Xunit;

namespace IntegrationTests;

[Trait("Category", "Query")]
[Collection("MyCollection")]
public class FlureeQueryTests
{
    private readonly IFlureeQueryService _flureeQueryService = new FlureeQueryService(
        new PerBaseUrlFlurlClientFactory(),
        "http://localhost:8090");

    [Fact]
    public async Task CanQueryData()
    {
        //Arrange
        var query = new FlureeQueryBuilder
        {
            SqlSelect = new List<string>
            {
                "*"
            },
            SqlFrom = "collection1"
        };
        //Act
        var result = await _flureeQueryService.ExecuteSingleQuery<QueryObject>("test", "ledger1", query);

        //Assert
        Assert.True(result is not null);
    }

    [Fact]
    public async Task CanQueryBlocks()
    {
        //Arrange

        //Act
        var result = await _flureeQueryService.QueryBlocks("test", "ledger1", new QueryBlockRequest
        {
            BlockNumberToQuery = 1
        });

        //Assert
        Assert.True(result is not null);
    }

    private class QueryObject
    {
        [JsonProperty("collection1/quantity")] private int quantity { get; set; }
    }
}
using System.Collections.Generic;
using System.Threading.Tasks;
using FlureeDotnetLibrary.FlureeCommand;
using FlureeDotnetLibrary.FlureeCommand.Model;
using Flurl.Http.Configuration;
using Newtonsoft.Json;
using Xunit;

namespace IntegrationTests;

/// <summary>
///     Transactions to NOT require a key to sign with, or we use the default fluree key
/// </summary>
[Trait("Category", "Transact")]
[Collection("MyCollection")]
public class FlureeTransactionTests
{
    private readonly IFlureeCommandService _flureeCommandService = new FlureeCommandService(
        new PerBaseUrlFlurlClientFactory(),
        "http://localhost:8090");

    [Fact]
    public async Task CanCreateLedgerCollection()
    {
        //Arrange

        //Act
        var result = await _flureeCommandService.CreateCollection("test", "ledger1", "collection2",
            "A test collection to add to FLuree");

        //Assert
        Assert.True(result is not null);
    }

    [Fact]
    public async Task CanTryCreateLedgerCollection()
    {
        //Arrange

        //Act
        var result = await _flureeCommandService.TryCreateCollection("test", "ledger1", "collection3",
            "A test collection to add to FLuree");

        //Assert
        Assert.True(result);
    }

    [Fact]
    public async Task CanCreateCollectionPredicate()
    {
        //Arrange

        //Act
        var result = await _flureeCommandService.CreatePredicate("test", "ledger1", "collection2", "quantity",
            "A test predicate to add to Fluree", "int");

        //Assert
        Assert.True(result is not null);
    }

    [Fact]
    public async Task CanTryCreateCollectionPredicate()
    {
        //Arrange

        //Act
        var result = await _flureeCommandService.TryCreatePredicate("test", "ledger1", "collection3", "quantity",
            "A test predicate to add to Fluree", "int");

        //Assert
        Assert.True(result);
    }

    [Fact]
    public async Task CanAddSampleData()
    {
        //Arrange
        var transactionCommandList = new List<FlureeTransactionDataParentBody>
        {
            new AddTransactionData
            {
                ParentId = "collection1",
                Quantity = 15
            },
            new AddTransactionData
            {
                ParentId = "collection1",
                Quantity = 15
            }
        };

        //Act
        var result = await _flureeCommandService.Insert("test", "ledger1", transactionCommandList);

        //Assert
        Assert.True(result is not null);
    }

    public class AddTransactionData : FlureeTransactionDataParentBody
    {
        [JsonProperty("quantity")] public int? Quantity { get; set; }
    }
}
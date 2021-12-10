using FlureeDotnetLibrary.FlureeCommand;
using FlureeDotnetLibrary.FlureeCommand.Model;
using Flurl.Http;
using Flurl.Http.Configuration;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Xunit;
using static FlureeDotnetLibrary.FlureeCommand.Model.FlureeCommandModel;

namespace IntegrationTests
{
    /// <summary>
    /// Transactions to NOT require a key to sign with, or we use the default fluree key
    /// </summary>
    [Trait("Category", "Transact")]
    public class FlureeTransactionTests
    {
        private readonly IFlureeCommandService _flureeCommandService;
        public FlureeTransactionTests()
        {
            _flureeCommandService = new FlureeCommandService(
                new PerBaseUrlFlurlClientFactory(),
                "http://localhost:8090");
        }

        [Fact]
        public async Task CanCreateLedgerCollection()
        {
            //Arrange

            //Act
            var result = await _flureeCommandService.CreateCollection("test", "ledger1", "collection1", "A test collection to add to FLuree");

            //Assert
            Assert.True(result is not null);
        }
        [Fact]
        public async Task CanTryCreateLedgerCollection()
        {
            //Arrange

            //Act
            var resultTrue = await _flureeCommandService.TryCreateCollection("test", "ledger1", "collection1", "A test collection to add to FLuree");
            var resultFalse = await _flureeCommandService.TryCreateCollection("test", "ledger1", "collection1", "A test collection to add to FLuree");

            //Assert
            Assert.True(resultTrue is true);
            Assert.True(resultFalse is false);
        }
        [Fact]
        public async Task CanCreateCollectionPredicate()
        {
            //Arrange

            //Act
            var result = await _flureeCommandService.CreatePredicate("test", "ledger1", "collection1", "quantity", "A test predicate to add to Fluree", "int");

            //Assert
            Assert.True(result is not null);
        }

        [Fact]
        public async Task CanTryCreateCollectionPredicate()
        {
            //Arrange

            //Act
            var resultTrue = await _flureeCommandService.TryCreatePredicate("test", "ledger1", "collection1", "quantity", "A test predicate to add to Fluree", "int");
            var resultFalse = await _flureeCommandService.TryCreatePredicate("test", "ledger1", "collection1", "quantity", "A test predicate to add to Fluree", "int");

            //Assert
            Assert.True(resultTrue is true);
            Assert.True(resultFalse is false);
        }

        [Fact]
        public async Task CanAddSampleData()
        {
            //Arrange
            var transactionCommandList = new List<FlureeTransactionDataParentBody>();

            for(int i = 0; i < 10000; i++)
            {
                transactionCommandList.Add(new AddTransactionData
                {
                    ParentId = "collection1",
                    Quantity = i,
                });
            }
            
            //Act
            var result = await _flureeCommandService.Insert("test", "ledger1", transactionCommandList); 

            //Assert
            Assert.True(result is not null);
        }
        public  class AddTransactionData : FlureeTransactionDataParentBody
        {
            [JsonProperty("quantity")]
            public int? Quantity { get; set; }
        }
    }
}

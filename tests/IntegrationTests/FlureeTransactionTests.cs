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
        private readonly IFlurlClient _flurlClient;
        private readonly IFlureeCommandService _flureeCommandService;
        public FlureeTransactionTests(IFlurlClientFactory factory, IConfiguration configuration, IFlureeCommandService flureeCommandService)
        {
            _flurlClient = factory.Get(configuration["fluree"]);
            _flureeCommandService = flureeCommandService;
        }

        [Fact]
        public async Task CanCreateLedgerCollection()
        {
            //Arrange

            //Act
            var result = await _flureeCommandService.CreateFlureeCollectionCommand("reporting", "yeetly", "collection1", "A test collection to add to FLuree");

            //Assert
            Assert.True(result is not null);
        }
        [Fact]
        public async Task CanCreateCollectionPredicate()
        {
            //Arrange

            //Act
            var result = await _flureeCommandService.CreateFlureePredicateCommand("reporting", "yeetly", "collection1", "predicate1", "A test collection to add to FLuree", "string");

            //Assert
            Assert.True(result is not null);
        }

        [Fact]
        public async Task CanAddSampleData()
        {
            //Arrange
            var transactionCommandList = new List<FlureeTransactionDataParentBody>()
            {
                new AddTransactionData
                {
                    CollectionId = "TopSellingProduct",
                    Quantity = 15,
                    Sku = "The second F13 Product!"
                },
                new AddTransactionData
                {
                    CollectionId = "TopSellingProduct",
                    Quantity = 15,
                    Sku = "The second F13 Product!"
                }
            };
            
            //Act
            var result = await _flureeCommandService.InsertDataIntoFluree("reporting", "yearly", transactionCommandList); 

            //Assert
            Assert.True(result is not null);
        }
        public  class AddTransactionData : FlureeTransactionDataParentBody
        {
            [JsonProperty("quantity")]
            public int? Quantity { get; set; }
            [JsonProperty("sku")]
            public string? Sku { get; set; }
        }
    }
}

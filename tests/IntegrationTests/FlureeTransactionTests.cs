using Flurl.Http;
using Flurl.Http.Configuration;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace IntegrationTests
{
    /// <summary>
    /// Transactions to NOT require a key to sign with, or we use the default fluree key
    /// </summary>
    [Trait("Category", "Transact")]
    public class FlureeTransactionTests
    {
        private readonly IFlurlClient _flurlClient;
        public FlureeTransactionTests(IFlurlClientFactory factory, IConfiguration configuration)
        {
            _flurlClient = factory.Get(configuration["fluree"]);
        }

        [Fact]
        public async Task CanCreateLedgerCollection()
        {
            //Arrange

            //Act
            var result = await _flurlClient.Request("/fdb/reporting/yearly/transact").PostJsonAsync(new List<AddCollectionJsonBody>()
            {
                new AddCollectionJsonBody
                {
                    CollectionName = "topsellingproduct",
                    CollectionDescription = "The top selling products over the last year",
                    CollectionVersion = "1"
                }

            });


            //Assert
            Assert.Equal(HttpStatusCode.OK, result.ResponseMessage.StatusCode);
        }
        [Fact]
        public async Task CanCreateCollectionPredicate()
        {
            //Arrange

            //Act
            var result = await _flurlClient.Request("/fdb/reporting/yearly/transact").PostJsonAsync(new List<AddPredicateBody>()
            {
                new AddPredicateBody
                {
                    PredicateName = "TopSellingProduct/quantity",
                    PredicateDescription = "Product sku for F13 Works",
                    ValueType = "int"
                }

            });


            //Assert
            Assert.Equal(HttpStatusCode.OK, result.ResponseMessage.StatusCode);
        }

        [Fact]
        public async Task CanAddSampleData()
        {
            //Arrange

            //Act
            var result = await _flurlClient.Request("/fdb/reporting/yearly/transact").PostJsonAsync(new List<AddTransactionData>()
            {
                new AddTransactionData
                {
                    CollectionId = "TopSellingProduct",
                    Quantity = 5,
                    Sku = "The first F13 Product!"

                },
                new AddTransactionData
                {
                    CollectionId = "TopSellingProduct",
                    Quantity = 15,
                    Sku = "The second F13 Product!"

                }

            });


            //Assert
            Assert.Equal(HttpStatusCode.OK, result.ResponseMessage.StatusCode);
        }
        private class AddCollectionJsonBody
        {
            [JsonProperty("_id")]
            public string? AddCollectionId { get; } = "_collection";
            [JsonProperty("name")]
            public string? CollectionName { get; set; }
            [JsonProperty("doc")]
            public string? CollectionDescription { get; set; }
            [JsonProperty("version")]
            public string? CollectionVersion { get; set; }
        }

        private class AddPredicateBody
        {
            [JsonProperty("_id")]
            public string? AddPredicateId { get; } = "_predicate";
            [JsonProperty("name")]
            public string? PredicateName { get; set; }
            [JsonProperty("doc")]
            public string? PredicateDescription { get; set; }
            [JsonProperty("type")]
            public string? ValueType { get; set; }
        }

        private class AddTransactionData
        {
            [JsonProperty("_id")]
            public string? CollectionId { get; set; }
            [JsonProperty("quantity")]
            public int? Quantity { get; set; }
            [JsonProperty("sku")]
            public string? Sku { get; set; }

        }
    }
}

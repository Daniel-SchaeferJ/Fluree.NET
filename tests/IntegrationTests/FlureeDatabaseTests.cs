﻿using Flurl.Http;
using Flurl.Http.Configuration;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace IntegrationTests
{
    [Trait("Category", "Database")]
    public class FlureeDatabaseTests
    {
        private readonly IFlurlClient _flurlClient;
        public FlureeDatabaseTests(IFlurlClientFactory factory, IConfiguration configuration)
        {
            _flurlClient = factory.Get(configuration["fluree"]);
        }

        [Fact]
        public async Task GetAllDataBasesFromFlureeTest()
        {
            //Arrange

            //Act
            var result = await _flurlClient.Request("/dbs").GetAsync();

            //Assert
            Assert.Equal(HttpStatusCode.OK, result.ResponseMessage.StatusCode);
        }


        [Fact]
        public async Task CanCreateANewDatabase()
        {
            //Arrange

            //Act
            var result = await _flurlClient.Request("/fdb/new-db").PostJsonAsync(new FlureeDatabaseJsonObjectBody
            {
                Database = "reporting/yearly"
            });

            //Assert
            Assert.Equal(HttpStatusCode.OK, result.ResponseMessage.StatusCode);
        }

        [Fact]
        public async Task CanDeleteADatabase()
        {
            //Arrange
            await _flurlClient.WithHeaders(new FlureeDatabaseJsonObjectHeader { }).Request("/dbs").PostAsync();

            //Act
            var result = await _flurlClient.Request("/fdb/delete-db").PostJsonAsync(new FlureeDatabaseJsonObjectBody
            {
                ServerName = "GHI"
            });

            //Assert
            Assert.Equal(HttpStatusCode.OK, result.ResponseMessage.StatusCode);
        }

        private class FlureeDatabaseJsonObjectBody
        {
            [JsonProperty("db/id")]
            public string Database { get; set; }
            [JsonProperty("server")]
            public string ServerName { get; set; }
        }

        private class FlureeDatabaseJsonObjectHeader
        {

        }
    }
}
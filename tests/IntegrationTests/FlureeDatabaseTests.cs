using FlureeDotnetLibrary.FlureeDatabase;
using Flurl.Http;
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
        private readonly IFlureeDatabaseService _flureeDatabaseService;
        public FlureeDatabaseTests(IFlureeDatabaseService flureeDatabaseService)
        {
            _flureeDatabaseService = flureeDatabaseService;
        }


        [Fact]
        public async Task GetAllDataBasesFromFlureeTest()
        {
            //Arrange

            //Act
            var result = await _flureeDatabaseService.GetAllLedgers();

            //Assert
            Assert.True(result is not null);
        }


        [Fact]
        public async Task CanCreateANewDatabase()
        {
            //Arrange

            //Act
            var result = await _flureeDatabaseService.CreateANewLedgerDatabase("reporting", "yeetly4");

            //Assert
            Assert.True(result is not null);
        }

        [Fact]
        public async Task CanDeleteADatabase()
        {
            //Arrange

            //Act
            var result = await _flureeDatabaseService.DeleteLedgerDatabase("reporting", "yeetly3");

            //Assert
            Assert.True(result is not null);
        }

    }
}
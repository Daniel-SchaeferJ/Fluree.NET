using FlureeDotnetLibrary.FlureeDatabase;
using Flurl.Http.Configuration;
using System.Threading.Tasks;
using Xunit;

namespace IntegrationTests
{
    [Trait("Category", "Database")]
    public class FlureeDatabaseTests
    {
        private readonly IFlureeDatabaseService _flureeDatabaseService;
        public FlureeDatabaseTests()
        {
            _flureeDatabaseService = new FlureeDatabaseService(
                new PerBaseUrlFlurlClientFactory(),
                "http://localhost:8090");
        }


        [Fact]
        public async Task GetAllDataBasesFromFlureeTest()
        {
            //Arrange

            //Act
            var result = await _flureeDatabaseService.GetAll();

            //Assert
            Assert.True(result is not null);
        }


        [Fact]
        public async Task CanCreateANewDatabase()
        {
            //Arrange

            //Act
            var result = await _flureeDatabaseService.Create("test", "ledger1");

            //Assert
            Assert.True(result is not null);
        }

        [Fact]
        public async Task CanTryCreateANewDatabase()
        {
            //Arrange

            //Act
            var resultTrue = await _flureeDatabaseService.TryCreate("test", "ledger1");
            var resultFalse = await _flureeDatabaseService.TryCreate("test", "ledger1");


            //Assert
            Assert.True(resultTrue is true);
            Assert.True(resultFalse is false);
        }

        [Fact]
        public async Task CanDeleteADatabase()
        {
            //Arrange

            //Act
            var result = await _flureeDatabaseService.Delete("test", "ledger1");

            //Assert
            Assert.True(result is not null);
        }

    }
}
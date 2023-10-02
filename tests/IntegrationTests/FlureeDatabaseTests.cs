using FlureeDotnetLibrary.FlureeDatabase;
using Flurl.Http.Configuration;
using System.Threading.Tasks;
using Xunit;

namespace IntegrationTests
{
    [Trait("Category", "Database")]
    
    [Collection("MyCollection")]
    public class FlureeDatabaseTests
    {
        private readonly IFlureeLedgerService _flureeLedgerService = new FlureeLedgerService(
            new PerBaseUrlFlurlClientFactory(),
            "http://localhost:8090");


        [Fact]
        public async Task GetAllDataBasesFromFlureeTest()
        {
            //Arrange

            //Act
            var result = await _flureeLedgerService.GetAll();

            //Assert
            Assert.True(result is not null);
        }


        [Fact]
        public async Task CanCreateANewDatabase()
        {
            //Arrange

            //Act
            var result = await _flureeLedgerService.Create("test1", "ledger2");

            //Assert
            Assert.True(result is not null);
        }

        [Fact]
        public async Task CanTryCreateANewDatabase()
        {
            //Arrange

            //Act
            var result = await _flureeLedgerService.TryCreate("test2", "ledger3");

            //Assert
            Assert.True(result);
        }

        [Fact]
        public async Task CanDeleteADatabase()
        {
            //Arrange
            await _flureeLedgerService.TryCreate("dbtodelete", "dbtodelete1");
            //Act
            var result = await _flureeLedgerService.Delete("dbtodelete", "dbtodelete1");
            
            //Assert.True(result is not null);
        }

    }
}
using Flurl.Http.Configuration;
using System.Threading.Tasks;
using FlureeDotnetLibrary.FlureeLedger;
using Xunit;

namespace IntegrationTests
{
    [Trait("Category", "Ledger")]

    [Collection("MyCollection")]
    public class FlureeLedgerTests
    {
        private readonly IFlureeLedgerService _flureeLedgerService = new FlureeLedgerService(
            new PerBaseUrlFlurlClientFactory(),
            "http://localhost:8090");


        [Fact]
        public async Task GetAllLedgerFromFlureeTest()
        {
            //Arrange

            //Act
            var result = await _flureeLedgerService.GetAll();

            //Assert
            Assert.True(result is not null);
        }


        [Fact]
        public async Task CanCreateANewLedger()
        {
            //Arrange

            //Act
            var result = await _flureeLedgerService.Create("test1", "ledger2");

            //Assert
            Assert.True(result is not null);
        }

        [Fact]
        public async Task CanTryCreateANewLedger()
        {
            //Arrange

            //Act
            var result = await _flureeLedgerService.TryCreate("test2", "ledger3");

            //Assert
            Assert.True(result);
        }

        [Fact]
        public async Task CanDeleteALedger()
        {
            //Arrange
            await _flureeLedgerService.TryCreate("dbtodelete", "dbtodelete1");
            //Act
            var result = await _flureeLedgerService.Delete("dbtodelete", "dbtodelete1");

            Assert.True(result is not null);
        }

        [Fact]
        public async Task CanGetLedgerStatistics()
        {
            //Arrange

            //Act
            var result = await _flureeLedgerService.LedgerStats("test", "ledger1");

            Assert.True(result is not null);
        }

    }
}
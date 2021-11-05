using FlureeDotnetLibrary.FlureeDatabase;
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
            var result = await _flureeDatabaseService.CreateANewLedgerDatabase("test", "ledger1");

            //Assert
            Assert.True(result is not null);
        }

        [Fact]
        public async Task CanDeleteADatabase()
        {
            //Arrange

            //Act
            var result = await _flureeDatabaseService.DeleteLedgerDatabase("test", "ledger1");

            //Assert
            Assert.True(result is not null);
        }

    }
}
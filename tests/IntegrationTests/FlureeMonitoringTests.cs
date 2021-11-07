using FlureeDotnetLibrary.FlureeMonitoring;
using System.Threading.Tasks;
using Xunit;

namespace IntegrationTests
{
    [Trait("Category", "Monitoring")]
    public class FlureeMonitoringTests
    {
        private readonly IFlureeMonitoringService _flureeMonitoringService;
        public FlureeMonitoringTests(IFlureeMonitoringService flureeMonitoringService)
        {
            _flureeMonitoringService = flureeMonitoringService;
        }

        [Fact]
        public async Task CanQueryNetworkState()
        {
            //Arrange

            //Act
            var result = await _flureeMonitoringService.GetFlureeNetworkStatus(); 

            //Assert
            Assert.True(result is not null);
        }

        [Fact]
        public async Task CanSeeServerIsDeployed()
        {
            //Arrange

            //Act
            var result = await _flureeMonitoringService.GetServerHasDeployedToNetwork();

            //Assert
            Assert.True(result is not null);
        }

        [Fact]
        public async Task CanGetLedgerStatistics()
        {
            //Arrange

            //Act
            var result = await _flureeMonitoringService.GetLedgerInformation("test", "ledger1"); 

            //Assert
            Assert.True(result is not null);
        }

    }
}

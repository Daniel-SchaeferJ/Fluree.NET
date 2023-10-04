using FlureeDotnetLibrary.FlureeMonitoring;
using Flurl.Http.Configuration;
using System.Threading.Tasks;
using Xunit;

namespace IntegrationTests
{
    [Trait("Category", "Monitoring")]
    [Collection("MyCollection")]
    public class FlureeMonitoringTests
    {
        private readonly IFlureeMonitoringService _flureeMonitoringService = new FlureeMonitoringService(
            new PerBaseUrlFlurlClientFactory(),
            "http://localhost:8090");

        [Fact]
        public async Task CanQueryNetworkState()
        {
            //Arrange

            //Act
            var result = await _flureeMonitoringService.GetNetworkStatus();

            //Assert
            Assert.True(result is not null);
        }

        [Fact]
        public async Task CanSeeServerIsDeployed()
        {
            //Arrange

            //Act
            var result = await _flureeMonitoringService.HasServerDeployedToNetwork();

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

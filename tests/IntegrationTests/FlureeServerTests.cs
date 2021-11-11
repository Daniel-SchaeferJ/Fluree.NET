using Flurl.Http;
using System.Threading.Tasks;
using Xunit;
using System.Net;
using System.Net.Http;
using FlureeDotnetLibrary.FlureeServer;
using Flurl.Http.Configuration;

namespace IntegrationTests
{
    [Trait("Category", "Server")]
    public class FlureeServerTests
    {

        private readonly IFlureeServerService _flureeServerService;
        public FlureeServerTests()
        {
            _flureeServerService = new FlureeServerService(
                new PerBaseUrlFlurlClientFactory(),
                "http://localhost:8090");
        }


        [Fact]
        public async Task CanCreateAFlureeServer()
        {
            //Arrange

            //Act
            var result = await _flureeServerService.Create("test");

            //Assert
            Assert.True(result is not null); 
        }

        [Fact]
        public async Task CanDeleteAServer()
        {
            //Arrange

            //Act
            var result = await _flureeServerService.Delete("test");

            //Assert
            Assert.True(result is not null);
        }

    }
}

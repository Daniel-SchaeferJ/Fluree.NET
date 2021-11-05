using Flurl.Http;
using System.Threading.Tasks;
using Xunit;
using System.Net;
using System.Net.Http;
using FlureeDotnetLibrary.FlureeServer;

namespace IntegrationTests
{
    [Trait("Category", "Server")]
    public class FlureeServerTests
    {

        private readonly IFlureeServerService _flureeServerService;
        public FlureeServerTests(IFlureeServerService flureeServerService)
        {
            _flureeServerService = flureeServerService;
        }


        [Fact]
        public async Task CanCreateAFlureeServer()
        {
            //Arrange

            //Act
            var result = await _flureeServerService.CreateFlureeServer("test");

            //Assert
            Assert.True(result is not null); 
        }

        [Fact]
        public async Task CanDeleteAServer()
        {
            //Arrange

            //Act
            var result = await _flureeServerService.DeleteFlureeServer("test");

            //Assert
            Assert.True(result is not null);
        }

    }
}

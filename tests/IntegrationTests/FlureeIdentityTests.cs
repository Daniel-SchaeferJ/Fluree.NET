using FlureeDotnetLibrary.FlureeIdentity;
using Flurl.Http;
using Flurl.Http.Configuration;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Xunit;

namespace IntegrationTests
{
    [Trait("Category","Authentication")]
    public class FlureeIdentityTests
    {
        private readonly IFlureeIdentityService _flureeIdentityService;

        public FlureeIdentityTests()
        {
            _flureeIdentityService = new FlureeIdentityService(
                new PerBaseUrlFlurlClientFactory(),
                "http://localhost:8090");
        }

        [Fact]
        public async Task GenerateNewKeysTest()
        {
            //Arrange

            //Act
            var result = await _flureeIdentityService.GenerateNewKeys();

            //Assert
            Assert.NotNull(result.AccountId);

        }
    }

}
using Flurl.Http;
using Flurl.Http.Configuration;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Xunit;

namespace IntegrationTests
{
    [Trait("Category","Authentication")]
    public class FlureeAuthenticationTests
    {
        private readonly IFlurlClient _flurlClient;

        public FlureeAuthenticationTests(IFlurlClientFactory factory, IConfiguration configuration)
        {
            _flurlClient = factory.Get(configuration["fluree"]);
        }

        [Fact]
        public async Task GenerateNewKeysTest()
        {
            //Arrange

            //Act
            var result = await _flurlClient.Request("/fdb/new-keys").PostAsync().ReceiveJson<AutneticationData>();

            //Assert
            Assert.NotNull(result.AccountId);

        }

        private class AutneticationData
        {
            [JsonProperty("account-id")]
            public string? AccountId { get; set; }
            [JsonProperty("private")]
            public string? PrivateKey { get; set; }
            [JsonProperty("public")]
            public string? PublicKey { get; set; }
        }
    }

}
using Flurl.Http;
using Flurl.Http.Configuration;
using Newtonsoft.Json;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace IntegrationTests
{
    [Trait("Category","Authentication")]
    public class FlureeAuthenticationTests
    {
        private readonly IFlurlClient _flurlClient;
        public FlureeAuthenticationTests(IFlurlClientFactory factory)
        {
            _flurlClient = factory.Get("http://localhost:8090");
        }

        [Fact]
        public async Task GenerateNewKeysTest()
        {
            //Arrange

            //Act
            var result = await _flurlClient.Request("/fdb/new-keys").PostAsync();

            var keys = await result.GetJsonAsync<AutneticationData>(); 

            //Assert
            Assert.Equal(HttpStatusCode.OK, result.ResponseMessage.StatusCode);
            Assert.NotNull(keys);

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
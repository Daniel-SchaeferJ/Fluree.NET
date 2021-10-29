using Flurl.Http;
using Flurl.Http.Configuration;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace IntegrationTests
{
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

            //Assert
            Assert.Equal(HttpStatusCode.OK, result.ResponseMessage.StatusCode);

        }
    }
}
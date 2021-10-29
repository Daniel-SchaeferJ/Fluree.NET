using Flurl.Http;
using Flurl.Http.Configuration;
using System.Threading.Tasks;
using Xunit;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;

namespace IntegrationTests
{
    public class FlureeDbCommunicationTests
    {
        private readonly IFlurlClient _flurlClient;
        public FlureeDbCommunicationTests(IFlurlClientFactory factory)
        {
            _flurlClient = factory.Get("fluree");
        }



        [Fact]
        public async Task SeeFlureeState()
        {
            //Arrange

            //Act
            var result = await _flurlClient.Request("/fdb/nw-state").PostAsync();

            //Assert
            Assert.Equal(HttpStatusCode.OK, result.ResponseMessage.StatusCode);
        }

        [Fact]
        public async Task CanCreateAServer()
        {
            //Arrange

            //Act
            var result = await _flurlClient.Request("/fdb/add-server").PostJsonAsync(new BodyData
            {
                ServerName = "GHI"
            });

            //Assert
            Assert.Equal(HttpStatusCode.OK, result.ResponseMessage.StatusCode);
        }

        [Fact]
        public async Task CanDeleteAServer()
        {
            //Arrange

            //Act
            var result = await _flurlClient.Request("/fdb/remove-server").PostJsonAsync(new BodyData
            {
                ServerName = "GHI"
            });

            //Assert
            Assert.Equal(HttpStatusCode.OK, result.ResponseMessage.StatusCode);
        }


        private class BodyData
        {
            [JsonProperty("db/id")]
            public string? Database { get; set; }
            [JsonProperty("server")]
            public string? ServerName { get; set; }
        }

        private class HeaderData
        {

        }
    }


}

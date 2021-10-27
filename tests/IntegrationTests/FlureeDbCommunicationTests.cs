using Flurl.Http;
using Flurl.Http.Configuration;
using System.Threading.Tasks;
using Xunit;
using System.Net;
using System.Net.Http;

namespace IntegrationTests
{
    public class FlureeDbCommunicationTests
    {
        private readonly IFlurlClient _flurlClient;
        public FlureeDbCommunicationTests(IFlurlClientFactory factory)
        {
            _flurlClient = factory.Get("http://localhost:8090/");
        }

        [Fact]
        public async Task GetAllDataBasesFromFlureeTest()
        {
            //Arrange

            //Act
            var result = await _flurlClient.Request("/dbs").GetAsync();

            //Assert
            Assert.Equal(HttpStatusCode.OK, result.ResponseMessage.StatusCode);
        }

        [Fact]
        public async Task CanCreateANewDatabase()
        {
            //Arrange

            //Act
            var result = await _flurlClient.Request("/fdb/new-db").PostJsonAsync( new TestData
            {
               db = "test",
               id = "one"
            });

            //Assert
            Assert.Equal(HttpStatusCode.OK, result.ResponseMessage.StatusCode);
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
            var result = await _flurlClient.Request("/fdb/add-server").PostAsync();

            //Assert
            Assert.Equal(HttpStatusCode.OK, result.ResponseMessage.StatusCode);
        }

        private class TestData
        {
            public string db { get; set; }
            public string id { get; set; }
        }
    }


}

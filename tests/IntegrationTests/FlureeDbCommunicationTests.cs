using Flurl.Http;
using Flurl.Http.Configuration;
using Flurl; 
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using System.Net;

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

        //[Fact]
        //public async Task CreateNewFlureeDatabase()
        //{
        //    //Arrange
        //    var flureeRequest = _flureeClient.CreateClient("fluree");

        //    //Act
        //    var result = await flureeRequest.GetAsync("/dbs");

        //    //Assert
        //    Assert.Equal("OK", result.ReasonPhrase);
        //}
    }
}

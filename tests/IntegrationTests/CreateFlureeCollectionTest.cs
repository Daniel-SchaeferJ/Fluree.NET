using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace IntegrationTests
{
    public class CreateFlureeCollectionTest
    {
        private readonly IHttpClientFactory _flureeClient;
        public CreateFlureeCollectionTest(IHttpClientFactory factory)
        {
            _flureeClient = factory; 
        }

        [Fact]
        public async Task CreateFlureeCollection()
        {
            //Arrange
            var flureeRequest = _flureeClient.CreateClient("fluree"); 

            //Act
            var result = await flureeRequest.GetAsync("/dbs");

            //Assert
            Assert.Equal("OK", result.ReasonPhrase);
        }
    }
}

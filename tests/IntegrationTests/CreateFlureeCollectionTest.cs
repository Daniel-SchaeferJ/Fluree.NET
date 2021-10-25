using System.Net.Http;
using System.Threading.Tasks;
using Xunit

namespace IntegrationTests
{
    public class CreateFlureeCollectionTest : FlureeFixture
    {
        public CreateFlureeCollectionTest(IHttpClientFactory fixture) : base(fixture) { }

        [Fact]
        public async Task CreateFlureeCollection()
        {
            //Assemble 

            //Act
            var result = await _client.PostAsync("/dbs", null); 

            //Assert
        }
    }
}

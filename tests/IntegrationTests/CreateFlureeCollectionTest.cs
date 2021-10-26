using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace IntegrationTests
{
    public class CreateFlureeCollectionTest
    {
        private readonly HttpClient _clientFactory;
        public CreateFlureeCollectionTest(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory.CreateClient("fluree"); 
        }


    }
}

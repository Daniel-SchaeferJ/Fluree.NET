using Flurl.Http;
using Flurl.Http.Configuration;
using Microsoft.Extensions.Configuration;

namespace FlureeDotnetLibrary
{
    public abstract class BaseService
    {
        protected readonly IFlurlClient _flurlClient;
        public BaseService(IFlurlClientFactory factory, IConfiguration config)
        {
            _flurlClient = factory.Get(config["Fluree:Url"]);
        }

        public BaseService(IFlurlClientFactory factory, string baseUrl)
        {
            _flurlClient = factory.Get(baseUrl);
        }
    }
}

using Flurl.Http;
using Flurl.Http.Configuration;
using Microsoft.Extensions.Configuration;

namespace FlureeDotnetLibrary;

public abstract class BaseService
{
    protected readonly IFlurlClient FlurlClient;

    protected BaseService(IFlurlClientFactory factory, IConfiguration config)
    {
        FlurlClient = factory.Get(config["Fluree:Url"]);
    }

    protected BaseService(IFlurlClientFactory factory, string baseUrl)
    {
        FlurlClient = factory.Get(baseUrl);
    }
}
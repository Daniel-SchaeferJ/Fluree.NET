using Flurl.Http.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IntegrationTests
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddSingleton<IFlurlClientFactory, PerBaseUrlFlurlClientFactory>();
        }
    }
}

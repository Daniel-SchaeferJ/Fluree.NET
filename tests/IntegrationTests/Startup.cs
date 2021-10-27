using Flurl.Http.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.DependencyInjection;

namespace IntegrationTests
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddHttpClient("fluree", c =>
            {
                c.BaseAddress = new Uri("http://localhost:8090/");
            });

            services.AddSingleton<IFlurlClientFactory, PerBaseUrlFlurlClientFactory>();
        }
    }
}

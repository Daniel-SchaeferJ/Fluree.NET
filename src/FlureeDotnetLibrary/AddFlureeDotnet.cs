using Flurl.Http.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace FlureeDotnetLibrary
{
    public static  class AddFlureeDotnet
    {
        public static IServiceCollection AddFlureeDotnetService(this IServiceCollection services)
        {
            services.AddHttpClient("fluree", c =>
            {
                c.BaseAddress = new Uri("http://localhost:8090/");
            });

            services.AddSingleton<IFlurlClientFactory, PerBaseUrlFlurlClientFactory>();

            return services; 
        }
    }
}

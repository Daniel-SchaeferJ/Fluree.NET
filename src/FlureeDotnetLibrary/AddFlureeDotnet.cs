using FlureeDotnetLibrary.FlureeCommand;
using FlureeDotnetLibrary.FlureeDatabase;
using FlureeDotnetLibrary.FlureeMonitoring;
using FlureeDotnetLibrary.FlureeQuery;
using Flurl.Http.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace FlureeDotnetLibrary
{
    public static  class AddFlureeDotnet
    {
        public static void AddFlureeDotnetService(this IServiceCollection services)
        {
            services.AddSingleton<IFlurlClientFactory, PerBaseUrlFlurlClientFactory>();
            services.AddTransient<IFlureeQueryService, FlureeQueryService>();
            services.AddTransient<IFlureeDatabaseService, FlureeDatabaseService>();
            services.AddTransient<IFlureeCommandService, FlureeCommandService>();
            services.AddTransient<IFlureeMonitoringService, FlureeMonitoringService>(); 
        }
    }
}

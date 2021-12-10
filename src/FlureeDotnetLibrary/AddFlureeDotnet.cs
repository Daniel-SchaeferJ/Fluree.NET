using FlureeDotnetLibrary.FlureeCommand;
using FlureeDotnetLibrary.FlureeDatabase;
using FlureeDotnetLibrary.FlureeMonitoring;
using FlureeDotnetLibrary.FlureeQuery;
using FlureeDotnetLibrary.FlureeServer;
using Flurl.Http.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FlureeDotnetLibrary
{
    public static class AddFlureeDotnet
    {
        public static void AddFlureeDotnetService(this IServiceCollection services)
        {
            services.AddSingleton<IFlurlClientFactory, PerBaseUrlFlurlClientFactory>();
            services.AddTransient<IFlureeQueryService, FlureeQueryService>();
            services.AddTransient<IFlureeDatabaseService, FlureeDatabaseService>();
            services.AddTransient<IFlureeServerService, FlureeServerService>();
            services.AddTransient<IFlureeCommandService, FlureeCommandService>();
            services.AddTransient<IFlureeMonitoringService, FlureeMonitoringService>();
        }
    }
}

using FlureeDotnetLibrary.FlureeCommand;
using FlureeDotnetLibrary.FlureeDatabase;
using FlureeDotnetLibrary.FlureeMonitoring;
using FlureeDotnetLibrary.FlureeQuery;
using FlureeDotnetLibrary.FlureeServer;
using Flurl.Http.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace FlureeDotnetLibrary
{
    public static  class AddFlureeDotnet
    {
        public static void AddFlureeDotnetService(this IServiceCollection services)
        {
            IConfiguration configuration = new ConfigurationBuilder()
              .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
              .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", optional: true, reloadOnChange: true)
              .Build();
            services.AddSingleton(configuration);
            services.AddSingleton<IFlurlClientFactory, PerBaseUrlFlurlClientFactory>();
            services.AddTransient<IExecuteFlureeQuery, FLureeQueryService>();
            services.AddTransient<IFlureeDatabaseService, FlureeDatabaseService>();
            services.AddTransient<IFlureeServerService, FlureeServerService>();
            services.AddTransient<IFlureeCommandService, FlureeCommandService>();
            services.AddTransient<IFlureeMonitoringService, FlureeMonitoringService>(); 
        }
    }
}

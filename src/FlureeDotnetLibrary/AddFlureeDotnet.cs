using FlureeDotnetLibrary.FlureeCommand;
using FlureeDotnetLibrary.FlureeLedger;
using FlureeDotnetLibrary.FlureeMonitoring;
using FlureeDotnetLibrary.FlureeQuery;
using Flurl.Http.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FlureeDotnetLibrary;

public static class AddFlureeDotnet
{
    public static void AddFlureeDotnetService(this IServiceCollection services)
    {
        services.AddSingleton<IFlurlClientFactory, PerBaseUrlFlurlClientFactory>();
        services.AddTransient<IFlureeQueryService, FlureeQueryService>();
        services.AddTransient<IFlureeLedgerService, FlureeLedgerService>();
        services.AddTransient<IFlureeCommandService, FlureeCommandService>();
        services.AddTransient<IFlureeMonitoringService, FlureeMonitoringService>();
    }
}
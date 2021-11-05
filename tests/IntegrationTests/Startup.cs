﻿using FlureeDotnetLibrary.FlureeDatabase;
using FlureeDotnetLibrary.FlureeQuery;
using Flurl.Http.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace IntegrationTests
{
    public class Startup
    {
       

        public void ConfigureServices(IServiceCollection services)
        {
            IConfiguration configuration = new ConfigurationBuilder()
              .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
              .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", optional: true, reloadOnChange: true)
              .Build();
            services.AddSingleton(configuration);
            services.AddSingleton<IFlurlClientFactory, PerBaseUrlFlurlClientFactory>();
            services.AddTransient<IExecuteFlureeQuery, FLureeQuery>();
            services.AddTransient<IFlureeDatabaseService, FlureeDatabaseService>(); 
        }
    }
}

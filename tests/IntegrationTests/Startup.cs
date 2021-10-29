﻿using Flurl.Http.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

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

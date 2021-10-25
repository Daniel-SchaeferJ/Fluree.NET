using Xunit;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace IntegrationTests
{
    public class FlureeFixture : IClassFixture<WebApplicationFactory<IHttpClientFactory>>
    {
        protected readonly HttpClient _client;
        private readonly IConfiguration _configuration;
        private readonly IServiceCollection _services;

        public FlureeFixture(IHttpClientFactory fixture)
        {
;            _client = fixture.CreateClient();
            _configuration = Configuration();
            _services = AddServices(); 
        }

        public static IConfiguration Configuration()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.test.json")
                .Build();
            return config;
        }

        public static IServiceCollection AddServices()
        {
            var services = new ServiceCollection();

            services.AddHttpClient("fluree", c =>
            {
                c.BaseAddress = new Uri("http://localhost:8090/");
            });

            return services;
        }
    }
}
using System.Net.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using Xunit;
using System.Threading.Tasks;

namespace IntegrationTests
{
    public class FlureeFixture
    {
        //private readonly IConfiguration _configuration;
        private readonly IServiceCollection _services;
        private readonly HttpClient _httpClient;

        public FlureeFixture()
        {
            //_configuration = Configuration();
            _services = AddServices();
            _httpClient = new HttpClient();
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
            services.AddScoped<HttpClient>();

            services.AddHttpClient("fluree", c =>
            {
                c.BaseAddress = new Uri("http://localhost:8090/");
            });

            return services;
        }

        [Fact]
        public async Task CreateFlureeCollection()
        {
            //Arrange
            Uri yeet = new Uri("http://localhost:8090/dbs");


            //Act
            var result = await _httpClient.GetAsync(yeet);

            Console.WriteLine(result.Content);

            //Assert
            Assert.Equal("OK", result.ReasonPhrase);
            _httpClient.Dispose(); 
        }
    }
}
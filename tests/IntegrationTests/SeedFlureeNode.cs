using System.Threading.Tasks;
using FlureeDotnetLibrary.FlureeDatabase;
using Flurl.Http.Configuration;

namespace IntegrationTests;

public static class SeedFlureeNode
{
    public static async Task SeedFluree()
    {
        IFlureeDatabaseService flureeDatabaseService = new FlureeDatabaseService(
            new PerBaseUrlFlurlClientFactory(),
            "http://localhost:8090");

        await flureeDatabaseService.Create("test", "ledger1");
    }
}
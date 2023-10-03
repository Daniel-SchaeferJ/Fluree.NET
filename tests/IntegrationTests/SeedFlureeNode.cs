using System;
using System.Threading.Tasks;
using FlureeDotnetLibrary.FlureeCommand;
using FlureeDotnetLibrary.FlureeDatabase;
using Flurl.Http.Configuration;

namespace IntegrationTests;

public static class SeedFlureeNode
{
    public static async Task SeedFluree()
    {
        IFlureeLedgerService flureeLedgerService = new FlureeLedgerService(
            new PerBaseUrlFlurlClientFactory(),
            "http://localhost:8090");
        
        IFlureeCommandService _flureeCommandService = new FlureeCommandService(
        new PerBaseUrlFlurlClientFactory(),
        "http://localhost:8090");
        try
        {
            await flureeLedgerService.Create("test", "ledger1");
            await _flureeCommandService.CreateCollection("test", "ledger1", "collection1", "A test collection to add to FLuree");
            await _flureeCommandService.TryCreatePredicate("test", "ledger1", "collection1", "quantity", "A test predicate to add to Fluree", "int");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

    }
}
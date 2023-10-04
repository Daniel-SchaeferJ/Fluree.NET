using System.Threading.Tasks;
using DotNet.Testcontainers.Builders;
using DotNet.Testcontainers.Containers;
using Xunit;

namespace IntegrationTests;

public class TestContainerFixture : IAsyncLifetime
{
    private readonly IContainer _container = new ContainerBuilder()
        .WithHostname("localhost")
        .WithImage("fluree/ledger:latest")
        .WithPortBinding(8090, 8090)
        .WithWaitStrategy(Wait.ForUnixContainer().UntilPortIsAvailable(8090)).Build();


    public async Task InitializeAsync()
    {
        await _container.StartAsync();
        await Task.Delay(3000);
        await SeedFlureeNode.SeedFluree();
    }

    public async Task DisposeAsync()
    {
        await _container.DisposeAsync();
    }
}

[CollectionDefinition("MyCollection")]
public class TestCointainerCollection : ICollectionFixture<TestContainerFixture>
{
    // This class has no code, and is never created. Its purpose is simply
    // to be the place to apply [CollectionDefinition] and all the
    // ICollectionFixture<> interfaces.
}
﻿using System.Threading.Tasks;
using FlureeDotnetLibrary.FlureeIdentity;
using Flurl.Http.Configuration;
using Xunit;

namespace IntegrationTests;

[Trait("Category", "Authentication")]
[Collection("MyCollection")]
public class FlureeIdentityTests
{
    private readonly IFlureeIdentityService _flureeIdentityService = new FlureeIdentityService(
        new PerBaseUrlFlurlClientFactory(),
        "http://localhost:8090");

    [Fact]
    public async Task GenerateNewKeysTest()
    {
        //Arrange

        //Act
        var result = await _flureeIdentityService.GenerateNewKeys();

        //Assert
        Assert.NotNull(result.AccountId);
    }
}
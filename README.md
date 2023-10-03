---

# Fluree.NET

Fluree.NET is a .NET client library for interacting with [FlureeDB](https://www.flur.ee/), a blockchain-based graph database. This library simplifies the process of integrating FlureeDB into your .NET applications.

## Installation

To install Fluree.NET, you can use the NuGet package manager:

```bash
dotnet add package Fluree.NET
```
After that go to your project and we need to add 2 things
```csharp
using FlureeDotnetLibrary;

builder.Services.AddFlureeDotnetService();
```
And in app settings add this line 
```json
{
  "fluree": "Your Fluree URL here"
}
```

Or you can new up clients manually 
```charp
        private readonly IFlureeIdentityService _flureeIdentityService = new FlureeIdentityService(
            new PerBaseUrlFlurlClientFactory(),
            "http://localhost:8090");
```
## Usage

Here's a basic example of how to use Fluree.NET to interact with FlureeDB:

```csharp
using Fluree;

class Program
{
        private readonly IFlureeIdentityService _flureeIdentityService = new FlureeIdentityService(
            new PerBaseUrlFlurlClientFactory(),
            "http://localhost:8090");
    static async Task Main(string[] args)
    {
      var result = await _flureeIdentityService.GenerateNewKeys();
    }
}
```

For more detailed usage instructions and examples, please refer to the tests.

## Features

- Create and execute queries against FlureeDB.
- Authentication support for secure access.
- Simplified integration of FlureeDB into .NET applications.

## Contributing

Contributions to Fluree.NET are welcome! If you find any issues or have ideas for improvements, please open an issue or submit a pull request. Be sure to follow the [code of conduct](CODE_OF_CONDUCT.md).

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE.md) file for details.

using Flurl.Http;
using Flurl.Http.Configuration;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace IntegrationTests
{
    /// <summary>
    /// Commands require key signing
    /// </summary>
    [Trait("Category", "Commands")]
    public class FlureeCommandTests
    {
        private readonly IFlurlClient _flurlClient;
        public FlureeCommandTests(IFlurlClientFactory factory, IConfiguration configuration)
        {
            _flurlClient = factory.Get(configuration["fluree"]);
        }

        private class CommandData
        {
            // tx, new-db, or default-key
            [JsonProperty("type")]
            public string? Type { get; set; }
            
            [JsonProperty("db")]
            //network/dbid
            public string? Database { get; set; }
            
            [JsonProperty("tx")]
            public string? Tx { get; set; } //The body of the transaction

            [JsonProperty("auth")]
            public string? AuthId { get; set; } //_auth/id of the auth

            [JsonProperty("fuel")]
            public string? Fuel { get; set; } //Max integer for the amount of fuel to use for this transaction

            [JsonProperty("nonce")]
            public string? Nonce { get; set; } //Integer nonce, to ensure that the command map is unique.

            [JsonProperty("expire")]
            public string? EpochExpiration { get; set; } //Epoch milliseconds after which point this transaction can no longer be submitted.

            [JsonProperty("deps")]
            public string? deps { get; set; } // 	(optional, if no deps, simply exclude the key). An array of the _tx/ids of any transactions this tx depends on. If any of the
                                              // 	_tx/ids either do not exist in the ledger or resulted in failed transactions, then the command will not succeed.
        }

    }
}

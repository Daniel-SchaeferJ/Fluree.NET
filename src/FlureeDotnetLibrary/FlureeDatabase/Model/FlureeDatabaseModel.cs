using Newtonsoft.Json;

namespace FlureeDotnetLibrary.FlureeDatabase.Model
{
    public class FlureeDatabaseModel
    {
        /// <summary>
        /// Network and ledger identification property.
        /// Should be formatted as {networkId/ledgerId}
        /// </summary>
            [JsonProperty("db/id")]
            public string? NetworkAndDatabase { get; set; }
    }
}

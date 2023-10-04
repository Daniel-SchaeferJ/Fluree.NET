using Newtonsoft.Json;

namespace FlureeDotnetLibrary.FlureeLedger.Model;

public class FlureeLedgerModel
{
    /// <summary>
    ///     Network and ledger identification property.
    ///     Should be formatted as {networkId/ledgerId}
    /// </summary>
    [JsonProperty("ledger/id")]
    public string? NetworkAndLedger { get; set; }
}
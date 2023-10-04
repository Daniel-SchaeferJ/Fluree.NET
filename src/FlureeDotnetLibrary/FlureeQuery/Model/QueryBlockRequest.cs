using Newtonsoft.Json;

namespace FlureeDotnetLibrary.FlureeQuery.Model;

public class QueryBlockRequest
{
    [JsonProperty("block")] public int BlockNumberToQuery { get; set; }
}
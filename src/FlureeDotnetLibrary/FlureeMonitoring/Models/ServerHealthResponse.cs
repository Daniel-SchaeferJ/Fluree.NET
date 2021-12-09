using Newtonsoft.Json;

public class ServerHealthResponse
{
    [JsonProperty("ready")]
    public bool Ready { get; set; }

    [JsonProperty("status")]
    public string? Status { get; set; }

    [JsonProperty("utilization")]
    public double Utilization { get; set; }
}


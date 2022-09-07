using Newtonsoft.Json;

namespace FlureeDotnetLibrary.FlureeServer.Model
{
    public class FlureeServerModel
    {
        [JsonProperty("server")]
        public string? ServerName { get; set; }

    }
}

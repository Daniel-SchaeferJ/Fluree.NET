using Newtonsoft.Json;

namespace FlureeDotnetLibrary.FlureeIdentity.Models
{
    public class AuthenticationModel
    {
        [JsonProperty("account-id")]
        public string? AccountId { get; set; }
        [JsonProperty("private")]
        public string? PrivateKey { get; set; }
        [JsonProperty("public")]
        public string? PublicKey { get; set; }
    }
}

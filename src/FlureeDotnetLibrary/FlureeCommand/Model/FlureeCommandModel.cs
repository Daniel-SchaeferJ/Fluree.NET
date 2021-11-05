using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlureeDotnetLibrary.FlureeCommand.Model
{
    public static class FlureeCommandModel
    {
        public class FlureeCollectionBody
        {
            [JsonProperty("_id")]
            public string? AddCollectionId { get; } = "_collection";
            [JsonProperty("name")]
            public string? CollectionName { get; set; }
            [JsonProperty("doc")]
            public string? CollectionDescription { get; set; }
            [JsonProperty("version")]
            public string? CollectionVersion { get; set; }
        }

        public class FlureePredicateBody
        {
            [JsonProperty("_id")]
            public string? AddPredicateId { get; } = "_predicate";
            [JsonProperty("name")]
            public string? PredicateName { get; set; }
            [JsonProperty("doc")]
            public string? PredicateDescription { get; set; }
            [JsonProperty("type")]
            public string? ValueType { get; set; }
        }

        public class FlureeTransactionBody
        {
            [JsonProperty("_id")]
            public string? CollectionId { get; set; }
            [JsonProperty("quantity")]
            public int? Quantity { get; set; }
            [JsonProperty("sku")]
            public string? Sku { get; set; }

        }
    }
}

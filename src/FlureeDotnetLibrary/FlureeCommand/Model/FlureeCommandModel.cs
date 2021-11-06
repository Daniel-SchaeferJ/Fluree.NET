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
            public string? CollectionId = "_collection";
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
            public string? PredicateId = "_predicate";
            [JsonProperty("name")]
            public string? PredicateName { get; set; }
            [JsonProperty("doc")]
            public string? PredicateDescription { get; set; }
            [JsonProperty("type")]
            public string? DataType { get; set; }
        }
    }
    /// <summary>
    /// The interface for which to add data. The parent body adds the collection
    /// id you wish to add to, and outside of that just add the predicates from your collection!
    /// </summary>
    public interface IFlureeTransactionDataParentBody
    {
        [JsonProperty("_id")]
        public string? CollectionId { get; set; }

    }
}

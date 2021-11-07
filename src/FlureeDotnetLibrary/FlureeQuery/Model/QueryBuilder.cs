using Newtonsoft.Json;
using System.Collections.Generic;

namespace FlureeDotnetLibrary.FlureeQuery.Model
{
    public abstract class QueryBuilder
    {
        /// <summary>
        /// Can either be a *, or a group of collections you wish to choose from
        /// Only set the select property you wish to use
        /// </summary>
        [JsonProperty("select", NullValueHandling = NullValueHandling.Ignore)]
        public List<string>? SqlSelect { get; set; }
        [JsonProperty("selectOne", NullValueHandling = NullValueHandling.Ignore)]
        public List<string>? SqlSelectOne { get; set; }
        [JsonProperty("selectDistinct", NullValueHandling = NullValueHandling.Ignore)]
        public List<string>? SqlSelectDistinct { get; set; }

        [JsonProperty("from", NullValueHandling = NullValueHandling.Ignore)]
        public string? SqlFrom { get; set; }

        [JsonProperty("where", NullValueHandling = NullValueHandling.Ignore)]
        public string? SqlWhere { get; set; }
    }

}

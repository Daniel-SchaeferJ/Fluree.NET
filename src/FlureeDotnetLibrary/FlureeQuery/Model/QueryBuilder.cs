using Newtonsoft.Json;
using System.Collections.Generic;

namespace FlureeDotnetLibrary.FlureeQuery.Model
{
    public class QueryBuilder
    {
        /// <summary>
        /// Can either be a *, or a group of collections you wish to choose from
        /// </summary>
        [JsonProperty("select")]
        public List<string>? SqlSelect { get; set; }
        [JsonProperty("from")]
        public string? SqlFrom { get; set; }

        [JsonProperty("where")]
        public string? SqlWhere { get; set; }
    }
}

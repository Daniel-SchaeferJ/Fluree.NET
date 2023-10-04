using System.Collections.Generic;
using Newtonsoft.Json;

namespace FlureeDotnetLibrary.FlureeQuery.Model;

public class FlureeQueryBuilder
{
    /// <summary>
    ///     A collection, predicate name, subject id, unique two-tuple, or array of subject ids and two-tuples.
    /// </summary>
    [JsonProperty("from", NullValueHandling = NullValueHandling.Ignore)]
    public string? SqlFrom { get; set; }

    /// <summary>
    ///     A series of where expressions connected by AND or OR
    ///     If you use where, From or where are required
    /// </summary>
    [JsonProperty("where", NullValueHandling = NullValueHandling.Ignore)]
    public string? SqlWhere { get; set; }

    /// <summary>
    ///     Optional time-travel query specified by block number, duration, or wall-clock time as an ISO-8601 formatted string.
    /// </summary>
    [JsonProperty("block", NullValueHandling = NullValueHandling.Ignore)]
    public string? BlockQuery { get; set; }

    /// <summary>
    ///     Optional map of options.
    /// </summary>
    [JsonProperty("opts", NullValueHandling = NullValueHandling.Ignore)]
    public List<string>? OptionsMap { get; set; }

    /// <summary>
    ///     selectOne is the same as select,
    ///     except it just returns a single value. select results are distinct by default,
    ///     so select and selectDistinct are equivalent. See select key.
    /// </summary>

    #region SelectTypes

    [JsonProperty("select", NullValueHandling = NullValueHandling.Ignore)]
    public List<string>? SqlSelect { get; set; }

    [JsonProperty("selectOne", NullValueHandling = NullValueHandling.Ignore)]
    public List<string>? SqlSelectOne { get; set; }

    [JsonProperty("selectDistinct", NullValueHandling = NullValueHandling.Ignore)]
    public List<string>? SqlSelectDistinct { get; set; }

    #endregion

    //TODO Add opts key type https://docs.flur.ee/docs/1.0.0/query/overview#opts-key
}
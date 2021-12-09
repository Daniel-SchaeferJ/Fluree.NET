using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Globalization;


namespace FlureeDotnetLibrary.FlureeMonitoring.Models
{
    public partial class FlureeNetworkResponse
    {
        [JsonProperty("snapshot-term")]
        public long SnapshotTerm { get; set; }

        [JsonProperty("latest-index")]
        public long LatestIndex { get; set; }

        [JsonProperty("snapshot-index")]
        public long SnapshotIndex { get; set; }

        [JsonProperty("other-servers")]
        public object[]? OtherServers { get; set; }

        [JsonProperty("index")]
        public long Index { get; set; }

        [JsonProperty("snapshot-pending")]
        public object? SnapshotPending { get; set; }

        [JsonProperty("term")]
        public long Term { get; set; }

        [JsonProperty("leader")]
        public string? Leader { get; set; }

        [JsonProperty("timeout-at")]
        public long TimeoutAt { get; set; }

        [JsonProperty("this-server")]
        public string? ThisServer { get; set; }

        [JsonProperty("status")]
        public string? Status { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("svr-state")]
        public SvrState[]? SvrState { get; set; }

        [JsonProperty("commit")]
        public long Commit { get; set; }

        [JsonProperty("servers")]
        public FlureeNetworkResponseServers? Servers { get; set; }

        [JsonProperty("raft")]
        public Raft? Raft { get; set; }

        [JsonProperty("oldest-pending-txn-instant")]
        public object? OldestPendingTxnInstant { get; set; }

        [JsonProperty("voted-for")]
        public string? VotedFor { get; set; }

        [JsonProperty("open-api")]
        public bool OpenApi { get; set; }

        [JsonProperty("timeout-ms")]
        public long TimeoutMs { get; set; }
    }

    public partial class Raft
    {
        [JsonProperty("version")]
        public long Version { get; set; }

        [JsonProperty("leases")]
        public Leases? Leases { get; set; }

        [JsonProperty("networks")]
        public Network[]? Networks { get; set; }

        [JsonProperty("new-db-queue")]
        public NewDbQueue[]? NewDbQueue { get; set; }

        [JsonProperty("_work")]
        public Work? Work { get; set; }

        [JsonProperty("_worker")]
        public Worker? Worker { get; set; }

        [JsonProperty("cmd-queue")]
        public CmdQueue[]? CmdQueue { get; set; }
    }

    public partial class CmdQueue
    {
        [JsonProperty("reporting")]
        public long Reporting { get; set; }

        [JsonProperty("txn-count")]
        public long TxnCount { get; set; }

        [JsonProperty("txn-oldest-instant")]
        public object? TxnOldestInstant { get; set; }
    }

    public partial class Leases
    {
        [JsonProperty("servers")]
        public LeasesServers? Servers { get; set; }
    }

    public partial class LeasesServers
    {
        [JsonProperty("myserver")]
        public PurpleMyserver? Myserver { get; set; }
    }

    public partial class PurpleMyserver
    {
        [JsonProperty("id")]
        public string? Id { get; set; }

        [JsonProperty("expire")]
        public long Expire { get; set; }
    }

    public partial class Network
    {
        [JsonProperty("reporting")]
        public Reporting? Reporting { get; set; }
    }

    public partial class Reporting
    {
        [JsonProperty("dbs")]
        public Dbs? Dbs { get; set; }
    }

    public partial class Dbs
    {
        [JsonProperty("yearly")]
        public Yearly? Yearly { get; set; }
    }

    public partial class Yearly
    {
        [JsonProperty("status")]
        public string? Status { get; set; }

        [JsonProperty("block")]
        public long Block { get; set; }

        [JsonProperty("index")]
        public long Index { get; set; }

        [JsonProperty("indexes")]
        public Indexes? Indexes { get; set; }
    }

    public partial class Indexes
    {
        [JsonProperty("1")]
        public long The1 { get; set; }
    }

    public partial class NewDbQueue
    {
        [JsonProperty("reporting")]
        public long Reporting { get; set; }
    }

    public partial class Work
    {
        [JsonProperty("networks")]
        public Networks? Networks { get; set; }
    }

    public partial class Networks
    {
        [JsonProperty("reporting")]
        public string? Reporting { get; set; }
    }

    public partial class Worker
    {
        [JsonProperty("myserver")]
        public WorkerMyserver? Myserver { get; set; }
    }

    public partial class WorkerMyserver
    {
        [JsonProperty("networks")]
        public NewDbQueue? Networks { get; set; }
    }

    public partial class FlureeNetworkResponseServers
    {
        [JsonProperty("myserver")]
        public FluffyMyserver? Myserver { get; set; }
    }

    public partial class FluffyMyserver
    {
        [JsonProperty("vote")]
        public Vote[]? Vote { get; set; }

        [JsonProperty("next-index")]
        public long NextIndex { get; set; }

        [JsonProperty("match-index")]
        public long MatchIndex { get; set; }

        [JsonProperty("snapshot-index")]
        public object? SnapshotIndex { get; set; }

        [JsonProperty("stats")]
        public Stats? Stats { get; set; }
    }

    public partial class Stats
    {
        [JsonProperty("sent")]
        public long Sent { get; set; }

        [JsonProperty("received")]
        public long Received { get; set; }

        [JsonProperty("avg-response")]
        public long AvgResponse { get; set; }
    }

    public partial class SvrState
    {
        [JsonProperty("id")]
        public string? Id { get; set; }

        [JsonProperty("active?")]
        public bool Active { get; set; }
    }

    public partial struct Vote
    {
        public bool? Bool;
        public long? Integer;

        public static implicit operator Vote(bool Bool) => new Vote { Bool = Bool };
        public static implicit operator Vote(long Integer) => new Vote { Integer = Integer };
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                VoteConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class VoteConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Vote) || t == typeof(Vote?);

        public override object ReadJson(JsonReader reader, Type t, object? existingValue, JsonSerializer serializer)
        {
            switch (reader.TokenType)
            {
                case JsonToken.Integer:
                    var integerValue = serializer.Deserialize<long>(reader);
                    return new Vote { Integer = integerValue };
                case JsonToken.Boolean:
                    var boolValue = serializer.Deserialize<bool>(reader);
                    return new Vote { Bool = boolValue };
            }
            throw new Exception("Cannot unmarshal type Vote");
        }

        public override void WriteJson(JsonWriter writer, object? untypedValue, JsonSerializer serializer)
        {
            if(untypedValue is null)
            {
                throw new Exception("Cannot marshal type Vote");
            }
            var value = (Vote)untypedValue;
            if (value.Integer != null)
            {
                serializer.Serialize(writer, value.Integer.Value);
                return;
            }
            if (value.Bool != null)
            {
                serializer.Serialize(writer, value.Bool.Value);
                return;
            }
        }

        public static readonly VoteConverter Singleton = new VoteConverter();
    }
}

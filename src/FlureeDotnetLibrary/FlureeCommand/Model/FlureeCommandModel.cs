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
           
            /// <summary>
            ///  	(optional) Optional docstring describing this collection.
            /// </summary>
            [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
            public string? CollectionName { get; set; }
            
            [JsonProperty("doc", NullValueHandling = NullValueHandling.Ignore)]
            public string? CollectionDescription { get; set; }
            
            /// <summary>
            ///  	(optional) A multi-cardinality list of reference to the _fn collection. 
            ///  	These specs restricts what is allowed in this collection. To see how to write a function, see the function section.
            /// </summary>  
            [JsonProperty("spec", NullValueHandling = NullValueHandling.Ignore)]
            public IList<string>? CollectionSpec { get; set; }

            /// <summary>
            ///  	(optional) Optional docstring to describe the specs. Is thrown when any spec fails.
            /// </summary>
            [JsonProperty("specDoc", NullValueHandling = NullValueHandling.Ignore)]
            public string? LongDescription { get; set; }

            /// <summary>
            ///  	(optional) For your optional use, if a collection's spec or 
            ///  	intended predicates change over time this version number can be used to determine which schema version a particular application may be using.
            /// </summary>
            [JsonProperty("version", NullValueHandling = NullValueHandling.Ignore)]
            public string? CollectionVersion { get; set; }
        }

        // TODO add all types from here https://docs.flur.ee/docs/1.0.0/schema/predicates
        public class FlureePredicateBody
        {
            [JsonProperty("_id")]
            public string? PredicateId = "_predicate";

            /// <summary>
            ///  	(required) Actual predicate name. Must be namespaced, and convention is to namespace it using the collection name you intend it to be used within. 
            ///  	Technically any predicate can be placed on any subject, but using a spec can restrict this behavior. Note that if you intend to use GraphQL tools, 
            ///  	predicate names must conform to /[_A-Za-z][_0-9A-Za-z]*/. 
            ///  	If you do not conform to this standard, queries issued to the /graphql endpoint will still work, but many GraphQL tools will not.
            /// </summary>
            [JsonProperty("name")]
            public string? PredicateName { get; set; }

            /// <summary>
            ///  	(optional) Doc string for this predicate describing its intention. This description is also used for GraphQL automated schema generation.
            /// </summary>
            [JsonProperty("doc", NullValueHandling = NullValueHandling.Ignore)]
            public string? PredicateDescription { get; set; }

            /// <summary>
            /// (required) Data type of this predicate such as string, integer, or a reference (join) to another subject.
            ///  string Unicode string (_type/string)
            /// ref Reference(join) to another collection(_type/ref)
            /// tag A special tag predicate.Tags are auto-generated, and create auto-resolving referred entities.Ideal for use as enum values. Also they allow you to find all entities that use a specific tag. (_type/tag)
            /// int 	32 bit signed integer(_type/int)
            /// long 	64 bit signed integer(_type/long)
            /// bigint Arbitrary sized integer(more than 64 bits) (_type/bigint)
            /// float 	32 bit IEEE double precision floating point(_type/float)
            /// double 	64 bit IEEE double precision floating point(_type/double)
            /// bigdec IEEE double precision floating point of arbitrary size(more than 64 bits) (_type/bigdec)
            /// instant Millisecond precision timestamp from unix epoch.Uses 64 bits. (_type/instant)
            /// boolean 	true/false (_type/boolean)
            /// uri URI formatted string (_type/uri)
            /// uuid A UUID value. (_type/uuid)
            ///bytes Must input bytes as a lowercase, hex-encoded string (_type/bytes)
            /// json Arbitrary JSON data.The JSON is automatically encoded/decoded (UTF-8) with queries and transactions, and JSON structure can be validated with a spec. (_type/json)
            /// </summary>
            [JsonProperty("type")]
            public string? DataType { get; set; }
        }
    }
    /// <summary>
    /// The interface for which to add data. The parent body adds the collection
    /// id you wish to add to, and outside of that just add the predicates from your collection!
    /// </summary>
    public abstract class FlureeTransactionDataParentBody
    {
        /// <summary>
        ///  	Any subject id value which can include the numeric assigned permanent _id for an subject, any predicate marked as unique as a two-tuple,
        ///  	i.e. ["_user/username", "jdoe"], or a temporary id (for new entities). See the Temporary Ids section in the below Transactions section to learn more.
        /// </summary>
        [JsonProperty("_id")]
        public string? CollectionId { get; set; }
        
        /// <summary>
        ///  	Optional (if it can be inferred). One of: add, update, upsert or delete. When using a temporary id, 
        ///  	add is always inferred. When using an existing subject id, update is always inferred. 
        ///  	upsert is inferred for new entities with a tempid if they include an predicate that was marked as upsert.
        /// </summary>
        [JsonProperty("_action", NullValueHandling = NullValueHandling.Ignore)]
        public string? DesiredAction { get; set; } 

    }
}

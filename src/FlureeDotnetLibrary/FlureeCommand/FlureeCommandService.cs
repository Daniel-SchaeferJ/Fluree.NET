using FlureeDotnetLibrary.FlureeCommand.Model;
using Flurl.Http;
using Flurl.Http.Configuration;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlureeDotnetLibrary.FlureeCommand
{
    public interface IFlureeCommandService
    {
        public Task<bool> TryCreateCollection(string networkId, string ledgerName, string collectionName, string collectionDescription, string verion = "1");
        public Task<string> CreateCollection(string networkId, string ledgerName, string collectionName, string collectionDescription, string verion = "1");
        public Task<bool> TryCreatePredicate(string networkId, string ledgerName, string collectionName, string predicateName, string predicateDescription, string datatype = "string");
        public Task<string> CreatePredicate(string networkId, string ledgerName, string collectionName, string predicateName, string predicateDescription, string datatype = "string");
        public Task<dynamic> Insert(string networkId, string ledgerName, List<FlureeTransactionDataParentBody> transactionCommands);
    }
    public class FlureeCommandService : BaseService, IFlureeCommandService
    {
        public FlureeCommandService(IFlurlClientFactory factory, IConfiguration config)
            : base(factory, config) { }

        public FlureeCommandService(IFlurlClientFactory factory, string baseUrl)
            : base(factory, baseUrl) { }

        /// <summary>
        /// Tries to adds a collection(in relational database terms a table) to a given ledger
        /// If collection already exists, nothing will happen.
        /// </summary>
        /// <param name="networkName">The network that contains the ledger you want to add to</param>
        /// <param name="ledgerName">The ledger you want to add the collection to</param>
        /// <param name="collectionName">The name of the collection to add</param>
        /// <param name="collectionDescription">Description of the collection you are adding</param>
        /// <param name="verion">Version is like migration in Ids. If this is the first time creating the collection, version is 1</param>
        public async Task<bool> TryCreateCollection(string networkName, string ledgerName, string collectionName, string collectionDescription, string verion = "1")
        {
            try
            {
                await CreateCollection(networkName, ledgerName, collectionName, collectionDescription, verion);
                return true;
            }
            catch (FlurlHttpException ex)
            {
                if (ex.StatusCode is 400)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

        }
        /// <summary>
        /// Adds a collection(in relational database terms a table) to a given ledger
        /// </summary>
        /// <param name="networkName">The network that contains the ledger you want to add to</param>
        /// <param name="ledgerName">The ledger you want to add the collection to</param>
        /// <param name="collectionName">The name of the collection to add</param>
        /// <param name="collectionDescription">Description of the collection you are adding</param>
        /// <param name="verion">Version is like migration in Ids. If this is the first time creating the collection, version is 1</param>
        #region ExampleReturnOutput
        /// <returns>Returns a string of the command that haapened. Example output. 
        /// {"tempids":{"_collection":[17592186044440,17592186044440]},"block":6,"hash":"44e65ef5406a99281aa45b0bfb8908484d56e8d612332f0342d282666c156db9",
        /// "instant":1636128750651,"type":"tx","duration":"7ms","fuel":830,"auth":"TfCSi5KvDYKRdkR9RgSsUhgKBZCM9N85iri","status":200,
        /// "id":"7c4bdd1b7bdad246ac7275ea83565ba072536f022102f782e3ea52987bab6ba8","bytes":820,"t":-11,"flakes":[[17592186044440,40,
        /// "collection5",-11,true,null],[17592186044440,41,"A test collection to add to FLuree",-11,true,null],[17592186044440,42,"1",-11,true,null],
        /// [-11,99,"19bda1dcdd77d871534f49076ef3b3c77f478dd7c5b3558f9391259d97258c52",-11,true,null],[-11,100,"7c4bdd1b7bdad246ac7275ea83565ba072536f022102f782e3ea52987bab6ba8",-11,true,null],[-11,101,105553116266496,-11,true,null],
        /// [-11,103,1636128750637,-11,true,null],[-11,106,"{\"type\":\"tx\",\"db\":\"reporting/yeetly\",\"tx\":[{\"_id\":\"_collection\",\"name\":\"collection5\",\"doc\":\"A test collection to add to FLuree\",\"version\":\"1\"}],\"nonce\":1636128750637,
        /// \"auth\":\"TfCSi5KvDYKRdkR9RgSsUhgKBZCM9N85iri\",\"expire\":1636129050639}",-11,true,null],[-11,107,"1c30440220061713d8dd35e24533603fd561783f63037e3161d1186601ea5754f7e5f6fe8c022056736e5b5c97581d62119332045ed3fa3669bc168a892317a52348faa2421ead",
        /// -11,true,null],[-11,108,"{\"_collection\":[17592186044440,17592186044440]}",-11,true,null]]}
        /// </returns> 
        #endregion
        public async Task<string> CreateCollection(string networkName, string ledgerName, string collectionName, string collectionDescription, string verion = "1")
        {
            return await _flurlClient.Request($"/fdb/{networkName}/{ledgerName}/transact").PostJsonAsync(new List<FlureeCommandModel.FlureeCollectionBody>()
            {
                new FlureeCommandModel.FlureeCollectionBody
                {
                    CollectionName = $"{collectionName}",
                    CollectionDescription = $"{collectionDescription}",
                    CollectionVersion = $"{verion}"
                }

            }).ReceiveString();
        }
        /// <summary>
        /// Adds a predicate(in relational database terms a column) to a given predicate
        /// If predicate already exists, nothing will happen.
        /// </summary>
        /// <param name="networkName">The network that contains the ledger you want to add to</param>
        /// <param name="ledgerName">The ledger you want to add the predicate to</param>
        /// <param name="collectionName">The collection name you want to add the predicate to</param>
        /// <param name="predicateName">The name of the predicate you are adding</param>
        /// <param name="predicateDescription">Description of the predicate you are adding</param>
        /// <param name="datatype">The type you want the predicate to be like integer, string etc . Allowed 
        /// types are here https://docs.flur.ee/docs/schema/predicates</param>
        public async Task<bool> TryCreatePredicate(string networkName, string ledgerName, string collectionName, string predicateName, string predicateDescription, string datatype = "string")
        {
            try
            {
                await CreatePredicate(networkName, ledgerName, collectionName, predicateName, predicateDescription, datatype);
                return true;
            }
            catch (FlurlHttpException ex)
            {
                if (ex.StatusCode is 400)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        /// <summary>
        /// Adds a predicate(in relational database terms a column) to a given collection
        /// </summary>
        /// <param name="networkName">The network that contains the ledger you want to add to</param>
        /// <param name="ledgerName">The ledger you want to add the predicate to</param>
        /// <param name="collectionName">The collection name you want to add the predicate to</param>
        /// <param name="predicateName">The name of the predicate you are adding</param>
        /// <param name="predicateDescription">Description of the predicate you are adding</param>
        /// <param name="datatype">The type you want the predicate to be like integer, string etc . Allowed 
        /// types are here https://docs.flur.ee/docs/schema/predicates</param>
        #region ExampleReturnOutput
        /// <returns>Example data string returned 
        /// {"tempids":{"_predicate":[1001,1001]},"block":7,"hash":"b52e102d30cbf8e9d18219400503ff3ec4589b0ae0e00b4cb6db67c366974491","instant":1636130382842,
        /// "type":"tx","duration":"271ms","fuel":820,"auth":"TfCSi5KvDYKRdkR9RgSsUhgKBZCM9N85iri","status":200,"id":"ccd318d5fcfbba3eba19d4c2c1d34f6a462e8bad5e3730622eb5db17c6e5b916","bytes":810,"t":-13,"flakes":[[1001,10,
        /// "collection1/predicate1",-13,true,null],[1001,11,"A test collection to add to FLuree",-13,true,null],[1001,12,52776558133249,-13,true,null],
        /// [-13,99,"e3efdd9d3a92d03f8c2a0797bf252987aab093dec8d2774112d0d01f24af82ac",-13,true,null],[-13,100,"ccd318d5fcfbba3eba19d4c2c1d34f6a462e8bad5e3730622eb5db17c6e5b916",-13,true,null],
        /// [-13,101,105553116266496,-13,true,null],[-13,103,1636130382543,-13,true,null],[-13,106,"{\"type\":\"tx\",\"db\":\"reporting/yeetly\",\"tx\":[{\"_id\":\"_predicate\",\"name\":\"collection1/predicate1\",
        /// \"doc\":\"A test collection to add to FLuree\",\"type\":\"string\"}],\"nonce\":1636130382543,\"auth\":\"TfCSi5KvDYKRdkR9RgSsUhgKBZCM9N85iri\",\"expire\":1636130682563}",-13,true,null],
        /// [-13,107,"1b3045022100ce95aa54f9063383474ba925cb176ab43f993d56892198d6cf6de56511aa3a3c0220662af85ed8ba91ed5682a71fb6994704c679bf4b7d43f8de097b10caffde2957",-13,true,null],[-13,108,
        /// "{\"_predicate\":[1001,1001]}",-13,true,null]]}
        /// </returns> 
        #endregion
        public async Task<string> CreatePredicate(string networkName, string ledgerName, string collectionName, string predicateName, string predicateDescription, string datatype = "string")
        {
            return await _flurlClient.Request($"/fdb/{networkName}/{ledgerName}/transact").PostJsonAsync(new List<FlureeCommandModel.FlureePredicateBody>()
            {
                new FlureeCommandModel.FlureePredicateBody
                {
                    PredicateName = $"{collectionName}/{predicateName}",
                    PredicateDescription = $"{predicateDescription}",
                    DataType = $"{datatype}"
                }

            }).ReceiveString();
        }
        /// <summary>
        /// INsert formatted data into you fluree node based of the collection and predicates you made
        /// </summary>
        /// <typeparam name="T">The object in which the collection/predicate is based off of</typeparam>
        /// <param name="networkName">The network that contains the ledger you want to add to</param>
        /// <param name="ledgerName">The ledger you want to add the collection to</param>
        /// <param name="transactionCommands">A list of all data that you wish to put into your data node</param>
        /// <returns>Returns a json object that shows how long the operation took, what block it was in, and other informational data</returns>
        public async Task<dynamic> Insert(string networkName, string ledgerName, List<FlureeTransactionDataParentBody> transactionCommands)
        {
            return await _flurlClient.Request($"/fdb/{networkName}/{ledgerName}/transact").PostJsonAsync(transactionCommands).ReceiveJson();
        }
    }

}

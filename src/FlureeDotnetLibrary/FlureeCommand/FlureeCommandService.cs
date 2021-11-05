using Flurl.Http;
using Flurl.Http.Configuration;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;
using FlureeDotnetLibrary.FlureeCommand.Model; 

namespace FlureeDotnetLibrary.FlureeCommand
{
    public interface IFlureeCommandService
    {
        public Task<string> CreateFlureeCollectionCommand(string networkId, string ledgerName, string collectionName, string collectionDescription, string verion = "1");
    }
    public class FlureeCommandService : IFlureeCommandService
    {
        private readonly IFlurlClient _flurlClient;
        public FlureeCommandService(IFlurlClientFactory factory, IConfiguration config)
        {
            _flurlClient = factory.Get(config["fluree"]);
        }
        /// <summary>
        /// Adds a collection(in relational database terms a table) to a given ledger
        /// </summary>
        /// <param name="networkId">THe network</param>
        /// <param name="ledgerName"></param>
        /// <param name="collectionName"></param>
        /// <param name="collectionDescription"></param>
        /// <param name="verion"></param>
        #region ExampleReturnOutput
        /// <returns>Returns a string of the command that haapened. Example output. {"tempids":{"_collection":[17592186044440,17592186044440]},"block":6,"hash":"44e65ef5406a99281aa45b0bfb8908484d56e8d612332f0342d282666c156db9",
        /// "instant":1636128750651,"type":"tx","duration":"7ms","fuel":830,"auth":"TfCSi5KvDYKRdkR9RgSsUhgKBZCM9N85iri","status":200,
        /// "id":"7c4bdd1b7bdad246ac7275ea83565ba072536f022102f782e3ea52987bab6ba8","bytes":820,"t":-11,"flakes":[[17592186044440,40,
        /// "collection5",-11,true,null],[17592186044440,41,"A test collection to add to FLuree",-11,true,null],[17592186044440,42,"1",-11,true,null],
        /// [-11,99,"19bda1dcdd77d871534f49076ef3b3c77f478dd7c5b3558f9391259d97258c52",-11,true,null],[-11,100,"7c4bdd1b7bdad246ac7275ea83565ba072536f022102f782e3ea52987bab6ba8",-11,true,null],[-11,101,105553116266496,-11,true,null],
        /// [-11,103,1636128750637,-11,true,null],[-11,106,"{\"type\":\"tx\",\"db\":\"reporting/yeetly\",\"tx\":[{\"_id\":\"_collection\",\"name\":\"collection5\",\"doc\":\"A test collection to add to FLuree\",\"version\":\"1\"}],\"nonce\":1636128750637,
        /// \"auth\":\"TfCSi5KvDYKRdkR9RgSsUhgKBZCM9N85iri\",\"expire\":1636129050639}",-11,true,null],[-11,107,"1c30440220061713d8dd35e24533603fd561783f63037e3161d1186601ea5754f7e5f6fe8c022056736e5b5c97581d62119332045ed3fa3669bc168a892317a52348faa2421ead",
        /// -11,true,null],[-11,108,"{\"_collection\":[17592186044440,17592186044440]}",-11,true,null]]}</returns> 
        #endregion
        public async Task<string> CreateFlureeCollectionCommand(string networkId, string ledgerName, string collectionName, string collectionDescription, string verion = "1")
        {
            return await _flurlClient.Request($"/fdb/{networkId}/{ledgerName}/transact").PostJsonAsync(new List<FlureeCommandModel.FlureeCollectionBody>()
            {
                new FlureeCommandModel.FlureeCollectionBody
                {
                    CollectionName = $"{collectionName}",
                    CollectionDescription = $"{collectionDescription}",
                    CollectionVersion = $"{verion}"
                }

            }).ReceiveString();
        }
    }
}

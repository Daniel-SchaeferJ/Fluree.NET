using FlureeDotnetLibrary.FlureeDatabase.Model;
using Flurl.Http;
using Flurl.Http.Configuration;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlureeDotnetLibrary.FlureeDatabase
{
    public interface IFlureeDatabaseService
    {
        public Task<string> GetAll();
        public Task<bool> TryCreate(string networkName, string databaseName);
        public Task<string> Create(string networkName, string databaseName);
        public Task<dynamic> Delete(string networkName, string databaseName);
    }
    public class FlureeDatabaseService : BaseService, IFlureeDatabaseService
    {
        public FlureeDatabaseService(IFlurlClientFactory factory, IConfiguration config)
            : base(factory, config) { }

        public FlureeDatabaseService(IFlurlClientFactory factory, string baseUrl)
            : base(factory, baseUrl) { }

        /// <summary>
        /// Returns a list of all ledgers in the transactor group.
        /// </summary>
        /// <returns>A dynamic json representation of all ledgers</returns>
        public async Task<string> GetAll()
        {
            return await _flurlClient.Request("/fdb/dbs").PostAsync().ReceiveString();
        }

        /// <summary>
        /// Creats a new ledger. It can be put under an exsisting network, or if the network does not exsist, a new one is created.
        /// If ledger already exists, nothing will happen.
        /// </summary>
        /// <param name="networkName">The network name to put the ledger in</param>
        /// <param name="ledgerName">The new ledger to be created</param>
        /// <returns>A random string character that confirms the database was created, like 16a358f77s24daf92ad59da</returns>
        public async Task<bool> TryCreate(string networkName, string ledgerName)
        {
            try 
            { 
                await Create(networkName, ledgerName);
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
        /// Creats a new ledger. It can be put under an exsisting network, or if the network does not exsist, a new one is created.
        /// </summary>
        /// <param name="networkName">The network name to put the ledger in</param>
        /// <param name="ledgerName">The new ledger to be created</param>
        /// <returns>A random string character that confirms the database was created, like 16a358f77s24daf92ad59da</returns>
        public async Task<string> Create(string networkName, string ledgerName)
        {
            return await _flurlClient.Request("/fdb/new-db").PostJsonAsync(new FlureeDatabaseModel
            {
                NetworkAndDatabase = $"{networkName}/{ledgerName}"
            }).ReceiveString();
        }

        /// <summary>
        /// This deletes a ledger. Deleting a ledger means that a user will no longer be able to query or transact against that ledger, 
        /// but currently the actual ledger files will not be deleted on disk. 
        /// You can choose to delete those files yourself - or keep them. 
        /// You will not be able to create a new ledger with the same name as the deleted ledger.
        /// </summary>
        /// <param name="networkName">The network name to put the ledger in</param>
        /// <param name="ledgerName">The new ledger to be created</param>
        /// <returns>If deletion was successful it will return the {networkId}/{ledger that was deleted} as a json object</returns>
        public async Task<dynamic> Delete(string networkName, string ledgerName)
        {
            return await _flurlClient.Request("/fdb/delete-db").PostJsonAsync(new FlureeDatabaseModel
            {
                NetworkAndDatabase = $"{networkName}/{ledgerName}"
            }).ReceiveJson();
        }
    }
}

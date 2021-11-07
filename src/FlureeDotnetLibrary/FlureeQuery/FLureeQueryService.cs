﻿using FlureeDotnetLibrary.FlureeQuery.Model;
using Flurl.Http;
using Flurl.Http.Configuration;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlureeDotnetLibrary.FlureeQuery
{
    public interface IExecuteFlureeQuery
    {
        public Task<IList<dynamic>> ExectureSingleFlureeQuery(string networkName, string ledgerName, QueryBuilder queryBuilder); 
    }
    public class FLureeQueryService : IExecuteFlureeQuery
    {
        private readonly IFlurlClient _flurlClient;
        public FLureeQueryService(IFlurlClientFactory factory, IConfiguration config)
        {
            _flurlClient = factory.Get(config["fluree"]);
        }

        //TODO When the user uses the select one statement, this query erros out as it returns a list and not a Json Object. 
        //Will investigate in the future.
        /// <summary>
        /// This will query the fluree node much like how normal SQL works. Its returns a JSON list or individual object desired by user 
        /// based on the query
        /// </summary>
        /// <param name="networkName">The network where the desired data lives under</param>
        /// <param name="ledgerName">The ledger where the desired data lives under</param>
        /// <param name="queryBuilder">The query to be executed baed on what the user entered.</param>
        /// <returns>A list, single object, or nothing based on the query results.</returns>
        public async Task<IList<dynamic>> ExectureSingleFlureeQuery(string networkName, string ledgerName, QueryBuilder queryBuilder)
        {

            return await _flurlClient.Request($"/fdb/{networkName}/{ledgerName}/query").PostJsonAsync(queryBuilder).ReceiveJsonList();

        }
    }
}

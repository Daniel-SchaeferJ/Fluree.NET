using FlureeDotnetLibrary.FlureeQuery.Model;
using Flurl.Http;
using Flurl.Http.Configuration;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlureeDotnetLibrary.FlureeQuery
{
    public interface IFlureeQueryService
    {
        public Task<IList<T>> ExecuteSingleQuery<T>(string networkName, string ledgerName, FlureeQueryBuilder queryBuilder);
    }
    public class FlureeQueryService : BaseService, IFlureeQueryService
    {
        public FlureeQueryService(IFlurlClientFactory factory, IConfiguration config)
            : base(factory, config) { }

        public FlureeQueryService(IFlurlClientFactory factory, string baseUrl)
            : base(factory, baseUrl) { }

        /// <summary>
        /// This will query the fluree node much like how normal SQL works. Its returns a JSON list or individual object desired by user 
        /// based on the query
        /// </summary>
        /// <param name="networkName">The network where the desired data lives under</param>
        /// <param name="ledgerName">The ledger where the desired data lives under</param>
        /// <param name="queryBuilder">The query to be executed baed on what the user entered.</param>
        /// <returns>A list, single object, or nothing based on the query results.</returns>
        public async Task<IList<T>> ExecuteSingleQuery<T>(string networkName, string ledgerName, FlureeQueryBuilder queryBuilder)
        {

            return await _flurlClient.Request($"/fdb/{networkName}/{ledgerName}/query").PostJsonAsync(queryBuilder).ReceiveJson<IList<T>>();
        }
    }
}

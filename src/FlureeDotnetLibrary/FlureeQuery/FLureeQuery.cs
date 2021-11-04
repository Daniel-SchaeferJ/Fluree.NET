using AutoMapper;
using FlureeDotnetLibrary.FlureeQuery.Model;
using Flurl.Http;
using Flurl.Http.Configuration;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FlureeDotnetLibrary.FlureeQuery
{
    public interface IExecuteFlureeQuery
    {
        public Task<dynamic> ExectureSingleFlureeQuery<T>(QueryBuilder queryBuilder, string network, string ledger); 
    }
    public class FLureeQuery : IExecuteFlureeQuery
    {
        private readonly IFlurlClient _flurlClient;
        public FLureeQuery(IFlurlClientFactory factory, IConfiguration config)
        {
            _flurlClient = factory.Get(config["fluree"]);
        }

        public async Task<dynamic> ExectureSingleFlureeQuery<T>(QueryBuilder queryBuilder, string network, string ledger)
        {
            if (queryBuilder is null)
            {
                throw new ArgumentNullException(nameof(queryBuilder));
            }

            if (string.IsNullOrEmpty(network))
            {
                throw new ArgumentException($"'{nameof(network)}' cannot be null or empty.", nameof(network));
            }

            if (string.IsNullOrEmpty(ledger))
            {
                throw new ArgumentException($"'{nameof(ledger)}' cannot be null or empty.", nameof(ledger));
            }

            var result = await _flurlClient.Request($"/fdb/{network}/{ledger}/query").PostJsonAsync(queryBuilder).ReceiveJsonList();

            //try
            //{
            //    //return _mapper.Map<T>(result);
            //}
            //catch
            //{
                return result; 
            //}
        }
    }
}

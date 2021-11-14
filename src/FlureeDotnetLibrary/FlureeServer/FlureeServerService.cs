using FlureeDotnetLibrary.FlureeServer.Model;
using Flurl.Http;
using Flurl.Http.Configuration;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FlureeDotnetLibrary.FlureeServer
{
    public interface IFlureeServerService
    {
        public Task<dynamic> Create(string serverName);
        public Task<dynamic> Delete(string serverName);
    }
    public class FlureeServerService : BaseService, IFlureeServerService
    {
        public FlureeServerService(IFlurlClientFactory factory, IConfiguration config)
            : base(factory, config) { }

        public FlureeServerService(IFlurlClientFactory factory, string baseUrl)
            : base(factory, baseUrl) { }
        /// <summary>
        /// Creates a fluree server 
        /// </summary>
        /// <param name="serverName">The name of the server you wish to create</param>
        /// <returns>Will return a dynamic json object, in which information like operation code, in this case add,
        /// server name, command code, etc are returned to the user
        /// </returns>
        public async Task<dynamic> Create(string serverName)
        {
            return await _flurlClient.Request("/fdb/add-server").PostJsonAsync(new FlureeServerModel
            {
                ServerName = $"{serverName}"
            }).ReceiveJson();
        }

        public async Task<dynamic> Delete(string serverName)
        {
            return await _flurlClient.Request("/fdb/remove-server").PostJsonAsync(new FlureeServerModel
            {
                ServerName = $"{serverName}"
            }).ReceiveJson();
        }
    }
}

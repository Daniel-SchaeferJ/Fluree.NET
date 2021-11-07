using Flurl.Http;
using Flurl.Http.Configuration;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FlureeDotnetLibrary.FlureeMonitoring
{
    public interface IFlureeMonitoringService
    {
        public Task<dynamic> GetFlureeNetworkStatus();
        public Task<dynamic> GetServerHasDeployedToNetwork();
        public Task<string> GetLedgerInformation(string networkName, string ledgerName);
    }
    public class FlureeMonitoringService : IFlureeMonitoringService
    {
        private readonly IFlurlClient _flurlClient;
        public FlureeMonitoringService(IFlurlClientFactory factory, IConfiguration config)
        {
            _flurlClient = factory.Get(config["fluree"]);
        }

        public async Task<dynamic> GetFlureeNetworkStatus()
        {
            return await _flurlClient.Request($"/fdb/nw-state").PostAsync().ReceiveJson();
        }

        public async Task<string> GetLedgerInformation(string networkName, string ledgerName)
        {
            return await _flurlClient.Request($"/fdb/{networkName}/{ledgerName}/database-stats").PostAsync().ReceiveString();
        }

        public async Task<dynamic> GetServerHasDeployedToNetwork()
        {
            return await _flurlClient.Request($"/fdb/health").PostAsync().ReceiveJson();
        }
    }
}

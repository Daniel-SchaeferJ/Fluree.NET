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
        public Task<dynamic> GetNetworkStatus();
        public Task<dynamic> HasServerDeployedToNetwork();
        public Task<dynamic> GetLedgerInformation(string networkName, string ledgerName);
    }
    public class FlureeMonitoringService : BaseService, IFlureeMonitoringService
    {
        public FlureeMonitoringService(IFlurlClientFactory factory, IConfiguration config)
            : base(factory, config) { }

        public FlureeMonitoringService(IFlurlClientFactory factory, string baseUrl)
            : base(factory, baseUrl) { }
        /// <summary>
        /// Get the network status of the entire deployed fluree network
        /// </summary>
        /// <returns>A JSON object of the statistics of the entire fluree network currently being run</returns>
        public async Task<dynamic> GetNetworkStatus()
        {
            return await _flurlClient.Request($"/fdb/nw-state").PostAsync().ReceiveJson();
        }
        /// <summary>
        /// Gets ledger information based upon the desired ledger
        /// </summary>
        /// <param name="networkName">The network the ledger lives under</param>
        /// <param name="ledgerName">The desired ledger to get information from</param>
        /// <returns>Returns a JSON object with statistics about the desired ledger</returns>
        public async Task<dynamic> GetLedgerInformation(string networkName, string ledgerName)
        {
            return await _flurlClient.Request($"/fdb/{networkName}/{ledgerName}/ledger-stats").PostAsync().ReceiveJson();
        }
        /// <summary>
        /// See if the server deployed to the network
        /// </summary>
        /// <returns>Returns a status of the created network</returns>
        public async Task<dynamic> HasServerDeployedToNetwork()
        {
            return await _flurlClient.Request($"/fdb/health").PostAsync().ReceiveJson();
        }
    }
}

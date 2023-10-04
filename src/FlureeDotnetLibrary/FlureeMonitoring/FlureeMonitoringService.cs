using System.Threading.Tasks;
using Flurl.Http;
using Flurl.Http.Configuration;
using Microsoft.Extensions.Configuration;

namespace FlureeDotnetLibrary.FlureeMonitoring;

public interface IFlureeMonitoringService
{
    public Task<object> GetNetworkStatus();
    public Task<object> HasServerDeployedToNetwork();
    public Task<object> GetLedgerInformation(string networkName, string ledgerName);
}

public class FlureeMonitoringService : BaseService, IFlureeMonitoringService
{
    public FlureeMonitoringService(IFlurlClientFactory factory, IConfiguration config)
        : base(factory, config)
    {
    }

    public FlureeMonitoringService(IFlurlClientFactory factory, string baseUrl)
        : base(factory, baseUrl)
    {
    }

    /// <summary>
    ///     Get the network status of the entire deployed fluree network
    /// </summary>
    /// <returns>
    ///     A JSON object of the statistics of the entire fluree network currently being run
    ///     Example here https://developers.flur.ee/docs/reference/http/examples/#nw-state
    /// </returns>
    public async Task<object> GetNetworkStatus()
    {
        return await FlurlClient.Request("/fdb/nw-state").PostAsync().ReceiveJson();
    }

    /// <summary>
    ///     Gets ledger information based upon the desired ledger
    /// </summary>
    /// <param name="networkName">The network the ledger lives under</param>
    /// <param name="ledgerName">The desired ledger to get information from</param>
    /// <returns>
    ///     Returns a JSON object with statistics about the desired ledger
    /// </returns>
    public async Task<object> GetLedgerInformation(string networkName, string ledgerName)
    {
        return await FlurlClient.Request($"/fdb/{networkName}/{ledgerName}/ledger-stats").PostAsync().ReceiveJson();
    }

    /// <summary>
    ///     See if the server deployed to the network
    /// </summary>
    /// <returns>Returns a status of the created network</returns>
    public async Task<object> HasServerDeployedToNetwork()
    {
        return await FlurlClient.Request("/fdb/health").PostAsync().ReceiveJson();
    }
}
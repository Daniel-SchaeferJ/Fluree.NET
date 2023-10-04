using System.Threading.Tasks;
using FlureeDotnetLibrary.FlureeLedger.Model;
using FlureeDotnetLibrary.Utilities;
using Flurl.Http;
using Flurl.Http.Configuration;
using Microsoft.Extensions.Configuration;

namespace FlureeDotnetLibrary.FlureeLedger;

public interface IFlureeLedgerService
{
    public Task<string?> GetAll();
    public Task<bool> TryCreate(string networkName, string ledgerName, bool waitForCreationBeforeReturning = true);
    public Task<string> Create(string networkName, string ledgerName, bool waitForCreationBeforeReturning = true);
    public Task<object> Delete(string networkName, string ledgerName);
    public Task<object> LedgerStats(string networkName, string ledgerName);
}

public class FlureeLedgerService : BaseService, IFlureeLedgerService
{
    public FlureeLedgerService(IFlurlClientFactory factory, IConfiguration config)
        : base(factory, config)
    {
    }

    public FlureeLedgerService(IFlurlClientFactory factory, string baseUrl)
        : base(factory, baseUrl)
    {
    }

    /// <summary>
    ///     Returns a list of all ledgers in the transactor group.
    /// </summary>
    /// <returns>A object json representation of all ledgers</returns>
    public async Task<string?> GetAll()
    {
        return await FlurlClient.Request("/fdb/ledgers").PostAsync().ReceiveString();
    }

    /// <summary>
    ///     Creats a new ledger. It can be put under an exsisting network, or if the network does not exsist, a new one is
    ///     created.
    ///     If ledger already exists, nothing will happen.
    /// </summary>
    /// <param name="networkName">The network name to put the ledger in</param>
    /// <param name="ledgerName">The new ledger to be created</param>
    /// <returns>A random string character that confirms the ledger was created, like 16a358f77s24daf92ad59da</returns>
    public async Task<bool> TryCreate(string networkName, string ledgerName, bool waitForCreationBeforeReturning = true)
    {
        try
        {
            await Create(networkName, ledgerName, waitForCreationBeforeReturning);
            return true;
        }
        catch (FlurlHttpException ex)
        {
            await ex.Message.GetJsonAsync();
            return ex.StatusCode is 400;
        }
    }

    /// <summary>
    ///     Creats a new ledger. It can be put under an exsisting network, or if the network does not exsist, a new one is
    ///     created.
    /// </summary>
    /// <param name="networkName">The network name to put the ledger in</param>
    /// <param name="ledgerName">The new ledger to be created</param>
    /// <param name="waitForCreationBeforeReturning">
    ///     Turn this to false if you want to not wait for ledger creation before this
    ///     method returns
    /// </param>
    /// <returns>A random string character that confirms the ledger was created, like 16a358f77s24daf92ad59da</returns>
    public async Task<string> Create(string networkName, string ledgerName, bool waitForCreationBeforeReturning = true)
    {
        var ledgerResult = await FlurlClient.Request("/fdb/new-ledger").PostJsonAsync(new FlureeLedgerModel
        {
            NetworkAndLedger = $"{networkName}/{ledgerName}"
        }).ReceiveString();

        if (!waitForCreationBeforeReturning) return ledgerResult;

        object ledgers = null;
        await PollyPolicy.GetPollyPolicy().ExecuteAsync(async () =>
        {
            ledgers = await LedgerStats(networkName, ledgerName);
        });

        return ledgerResult;
    }

    /// <summary>
    ///     This deletes a ledger. Deleting a ledger means that a user will no longer be able to query or transact against that
    ///     ledger,
    ///     but currently the actual ledger files will not be deleted on disk.
    ///     You can choose to delete those files yourself - or keep them.
    ///     You will not be able to create a new ledger with the same name as the deleted ledger.
    /// </summary>
    /// <param name="networkName">The network name to put the ledger in</param>
    /// <param name="ledgerName">The new ledger to be created</param>
    /// <returns>If deletion was successful it will return the {networkId}/{ledger that was deleted} as a json object</returns>
    public async Task<object> Delete(string networkName, string ledgerName)
    {
        return await FlurlClient.Request("/fdb/delete-ledger").PostJsonAsync(new FlureeLedgerModel
        {
            NetworkAndLedger = $"{networkName}/{ledgerName}"
        }).ReceiveJson();
    }

    public async Task<object> LedgerStats(string networkName, string ledgerName)
    {
        return await FlurlClient.Request($"/fdb/{networkName}/{ledgerName}/ledger-stats").PostJsonAsync(
            new FlureeLedgerModel
            {
                NetworkAndLedger = $"{networkName}/{ledgerName}"
            }).ReceiveJson();
    }
}
using System.Threading.Tasks;
using FlureeDotnetLibrary.FlureeIdentity.Models;
using Flurl.Http;
using Flurl.Http.Configuration;
using Microsoft.Extensions.Configuration;

namespace FlureeDotnetLibrary.FlureeIdentity;

public interface IFlureeIdentityService
{
    Task<AuthenticationModel> GenerateNewKeys();
}

public class FlureeIdentityService : BaseService, IFlureeIdentityService
{
    public FlureeIdentityService(IFlurlClientFactory factory, IConfiguration config)
        : base(factory, config)
    {
    }

    public FlureeIdentityService(IFlurlClientFactory factory, string baseUrl)
        : base(factory, baseUrl)
    {
    }

    public async Task<AuthenticationModel> GenerateNewKeys()
    {
        return await FlurlClient.Request("/fdb/new-keys").PostAsync().ReceiveJson<AuthenticationModel>();
    }
}
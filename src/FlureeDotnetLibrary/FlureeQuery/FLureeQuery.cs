using Flurl.Http;
using Flurl.Http.Configuration;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FlureeDotnetLibrary.FlureeQuery
{
    public interface IExecuteSingleFlureeQuery
    {

    }
    public class FLureeQuery
    {
        private readonly IFlurlClient _flurlClient;

        public FLureeQuery(IFlurlClientFactory factory, IConfiguration config)
        {
            _flurlClient = factory.Get(config["fluree"]);
        }

        public async Task ExectureSingleFlureeQuery()
        {
            throw new NotImplementedException();
        }
    }
}

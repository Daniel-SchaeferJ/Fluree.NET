using FlureeDotnetLibrary.Utility;
using Flurl.Http;
using Flurl.Http.Configuration;
using Newtonsoft.Json;
using System;

namespace FlureeDotnetLibrary
{
    public abstract class FlureeService
    {
        private static readonly JsonSerializer _serializer = Serializer.JsonSerializer;

        private readonly IFlurlClient _flurlClient;

        protected Uri? FlureeUrl { get; set; }

        public FlureeService(IFlurlClientFactory factory)
        {
            _flurlClient = factory.Get("fluree");
        }
    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlureeDotnetLibrary.FlureeServer.Model
{
    public class FlureeServerModel
    {
            [JsonProperty("server")]
            public string? ServerName { get; set; }

    }
}

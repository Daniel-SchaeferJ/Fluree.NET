using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlureeDotnetLibrary.Utility
{
    public static class Serializer
    {
        public static JsonSerializerSettings Settings { get; } = new JsonSerializerSettings()
        {
            NullValueHandling = NullValueHandling.Ignore
        };

        public static JsonSerializer JsonSerializer { get; } = new JsonSerializer
        {
            DateParseHandling = DateParseHandling.DateTimeOffset
        };

        public static string Serialize(object data)
        {
            if (data is null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            return JsonConvert.SerializeObject(data, Settings);
        }

        public static T Deserialize<T>(string json)
        {
            if (json is null)
            {
                throw new ArgumentNullException(nameof(json));
            }

            return JsonConvert.DeserializeObject<T>(json, Settings);
        }
    }
}

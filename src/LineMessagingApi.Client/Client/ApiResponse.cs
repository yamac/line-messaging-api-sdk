using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;

namespace Yamac.LineMessagingApi.Client
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class ApiResponse
    {
        public string Message { get; set; }

        public List<dynamic> Details { get; set; } = new List<dynamic>();
    }
}

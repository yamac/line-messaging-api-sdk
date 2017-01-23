using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;

namespace Yamac.LineMessagingApi.Client
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class ErrorResponse
    {
        public string Message { get; set; }

        public List<ErrorDetail> Details { get; set; } = new List<ErrorDetail>();
    }
}

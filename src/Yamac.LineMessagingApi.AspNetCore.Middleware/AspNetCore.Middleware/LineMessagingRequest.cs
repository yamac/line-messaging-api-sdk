using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;
using Yamac.LineMessagingApi.Models.Events;

namespace Yamac.LineMessagingApi.AspNetCore.Middleware
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class LineMessagingRequest
    {
        [JsonConverter(typeof(JsonEventConverter))]
        public List<Event> Events { get; set; }
    }
}

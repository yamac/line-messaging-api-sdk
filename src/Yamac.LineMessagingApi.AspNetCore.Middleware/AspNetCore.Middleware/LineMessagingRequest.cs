using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;
using Yamac.LineMessagingApi.Events;

namespace Yamac.LineMessagingApi.AspNetCore.Middleware
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class LineMessagingRequest
    {
        [JsonConverter(typeof(JsonEventConverter))]
        public List<Events.Event> Events { get; set; }
    }
}

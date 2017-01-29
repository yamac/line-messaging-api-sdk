using Yamac.LineMessagingApi.Event;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;

namespace Yamac.LineMessagingApi.AspNetCore.Middleware
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class LineMessagingRequest
    {
        [JsonConverter(typeof(JsonEventConverter))]
        public List<Event.Event> Events { get; set; }
    }
}

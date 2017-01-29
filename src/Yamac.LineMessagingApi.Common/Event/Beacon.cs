using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Yamac.LineMessagingApi.Event
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class Beacon
    {
        public string Hwid { get; set; }

        public BeaconType Type { get; set; }
    }
}

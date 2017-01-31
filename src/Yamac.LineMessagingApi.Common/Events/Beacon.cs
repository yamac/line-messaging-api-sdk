using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Yamac.LineMessagingApi.Events
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class Beacon
    {
        public string Hwid { get; set; }

        public BeaconType Type { get; set; }
    }
}

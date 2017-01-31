using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System;
using Yamac.LineMessagingApi.Utilities.Json;

namespace Yamac.LineMessagingApi.Events
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public abstract class Source
    {
        [JsonConverter(typeof(StringEnumConverter), true)]
        public abstract SourceType Type { get; }

        [JsonIgnore]
        public abstract string SenderId { get; }
    }

    public class JsonSourceConverter : JsonCreationConverter<Source>
    {
        protected override Source Create(Type objectType, JObject jsonObject)
        {
            var typeName = jsonObject["type"].ToString();
            switch (typeName)
            {
                case "user": return new UserSource();
                case "group": return new GroupSource();
                case "room": return new RoomSource();
                default: return new UnknownSource();
            }
        }
    }
}

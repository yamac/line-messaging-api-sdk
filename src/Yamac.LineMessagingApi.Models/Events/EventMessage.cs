using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System;
using Yamac.LineMessagingApi.Models.Utilities.Json;

namespace Yamac.LineMessagingApi.Models.Events
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public abstract class EventMessage
    {
        [JsonConverter(typeof(StringEnumConverter), true)]
        public abstract EventMessageType Type { get; }

        public string Id { get; set; }
    }

    public class JsonMessageConverter : JsonCreationConverter<EventMessage>
    {
        protected override EventMessage Create(Type objectType, JObject jsonObject)
        {
            var typeName = jsonObject["type"].ToString();
            switch (typeName)
            {
                case "text": return new TextEventMessage();
                case "image": return new ImageEventMessage();
                case "video": return new VideoEventMessage();
                case "audio": return new AudioEventMessage();
                case "location": return new LocationEventMessage();
                case "sticker": return new StickerEventMessage();
                default: return new UnknownEventMessage();
            }
        }
    }
}

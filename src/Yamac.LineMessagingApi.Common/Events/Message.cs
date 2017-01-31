using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System;
using Yamac.LineMessagingApi.Utilities.Json;

namespace Yamac.LineMessagingApi.Events
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public abstract class Message
    {
        [JsonConverter(typeof(StringEnumConverter), true)]
        public abstract MessageType Type { get; }

        public string Id { get; set; }
    }

    public class JsonMessageConverter : JsonCreationConverter<Message>
    {
        protected override Message Create(Type objectType, JObject jsonObject)
        {
            var typeName = jsonObject["type"].ToString();
            switch (typeName)
            {
                case "text": return new TextMessage();
                case "image": return new ImageMessage();
                case "video": return new VideoMessage();
                case "audio": return new AudioMessage();
                case "location": return new LocationMessage();
                case "sticker": return new StickerMessage();
                default: return new UnknownMessage();
            }
        }
    }
}

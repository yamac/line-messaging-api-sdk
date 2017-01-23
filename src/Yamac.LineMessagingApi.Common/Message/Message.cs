using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System;
using Yamac.LineMessagingApi.Common.Utilities.Json;

namespace Yamac.LineMessagingApi.Message
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public abstract class Message
    {
        [JsonConverter(typeof(StringEnumConverter), true)]
        public abstract MessageType Type { get; }
    }

    public enum MessageType
    {
        Text,
        Image,
        Video,
        Audio,
        Location,
        Sticker,
        Template,
        Imagemap,
        Unknown,
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

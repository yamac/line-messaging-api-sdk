using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System;
using Yamac.LineMessagingApi.Utilities.Json;

namespace Yamac.LineMessagingApi.Messages.Templates
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public abstract class Action
    {
        [JsonConverter(typeof(StringEnumConverter), true)]
        public abstract ActionType Type { get; }
    }

    public class JsonActionConverter : JsonCreationConverter<Action>
    {
        protected override Action Create(Type objectType, JObject jsonObject)
        {
            var typeName = jsonObject["type"].ToString();
            switch (typeName)
            {
                case "postback": return new PostbackAction();
                case "message": return new MessageAction();
                case "uri": return new UriAction();
                default: return new UnknownAction();
            }
        }
    }
}

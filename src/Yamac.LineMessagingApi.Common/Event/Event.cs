using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System;
using Yamac.LineMessagingApi.Utilities.Json;

namespace Yamac.LineMessagingApi.Event
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public abstract class Event
    {
        [JsonConverter(typeof(StringEnumConverter), true)]
        public abstract EventType Type { get; }

        [JsonConverter(typeof(JsonSourceConverter))]
        public Source Source { get; set; }

        [JsonConverter(typeof(JsonEpochMillisDateTimeConverter))]
        public DateTimeOffset Timestamp { get; set; }
    }

    public class JsonEventConverter : JsonCreationConverter<Event>
    {
        protected override Event Create(Type objectType, JObject jsonObject)
        {
            var typeName = jsonObject["type"].ToString();
            switch (typeName)
            {
                case "message": return new MessageEvent();
                case "follow": return new FollowEvent();
                case "unfollow": return new UnfollowEvent();
                case "join": return new JoinEvent();
                case "leave": return new LeaveEvent();
                case "postback": return new PostbackEvent();
                case "beacon": return new BeaconEvent();
                default: return new UnknownEvent();
            }
        }
    }
}

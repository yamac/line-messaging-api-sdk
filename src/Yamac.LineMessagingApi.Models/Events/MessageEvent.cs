using Newtonsoft.Json;

namespace Yamac.LineMessagingApi.Models.Events
{
    public class MessageEvent : Event
    {
        public override EventType Type { get { return EventType.Message; } }

        public string ReplyToken { get; set; }

        [JsonConverter(typeof(JsonMessageConverter))]
        public EventMessage Message { get; set; }
    }
}

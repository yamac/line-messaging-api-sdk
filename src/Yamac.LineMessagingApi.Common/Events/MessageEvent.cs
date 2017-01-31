﻿using Newtonsoft.Json;

namespace Yamac.LineMessagingApi.Events
{
    public class MessageEvent : Event
    {
        public override EventType Type { get { return EventType.Message; } }

        public string ReplyToken { get; set; }

        [JsonConverter(typeof(JsonMessageConverter))]
        public Message Message { get; set; }
    }
}

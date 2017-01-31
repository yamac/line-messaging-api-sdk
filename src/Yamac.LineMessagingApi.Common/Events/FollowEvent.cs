﻿using Newtonsoft.Json;

namespace Yamac.LineMessagingApi.Events
{
    public class FollowEvent : Event
    {
        public override EventType Type { get { return EventType.Follow; } }

        [JsonProperty("replyToken")]
        public string ReplyToken { get; set; }
    }
}

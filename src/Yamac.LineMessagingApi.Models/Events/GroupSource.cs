﻿using Newtonsoft.Json;

namespace Yamac.LineMessagingApi.Models.Events
{
    public class GroupSource : Source
    {
        public override SourceType Type { get { return SourceType.Group; } }

        public override string SenderId { get { return GroupId; } }

        [JsonProperty("userId")]
        public string UserId { get; set; }

        [JsonProperty("groupId")]
        public string GroupId { get; set; }
    }
}

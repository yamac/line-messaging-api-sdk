﻿namespace Yamac.LineMessagingApi.Models.Events
{
    public class UserSource : Source
    {
        public override SourceType Type { get { return SourceType.User; } }

        public override string SenderId { get { return UserId; } }

        public string UserId { get; set; }
    }
}

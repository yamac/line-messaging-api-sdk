﻿namespace Yamac.LineMessagingApi.Models.Events
{
    public class LeaveEvent : Event
    {
        public override EventType Type { get { return EventType.Leave; } }
    }
}

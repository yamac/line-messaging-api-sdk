﻿namespace Yamac.LineMessagingApi.Event
{
    public class AudioMessage : Message
    {
        public override MessageType Type { get { return MessageType.Audio; } }
    }
}

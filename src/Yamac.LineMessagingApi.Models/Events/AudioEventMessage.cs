namespace Yamac.LineMessagingApi.Models.Events
{
    public class AudioEventMessage : EventMessage
    {
        public override EventMessageType Type { get { return EventMessageType.Audio; } }
    }
}

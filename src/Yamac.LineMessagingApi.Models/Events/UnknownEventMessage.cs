namespace Yamac.LineMessagingApi.Models.Events
{
    public class UnknownEventMessage : EventMessage
    {
        public override EventMessageType Type { get { return EventMessageType.Unknown; } }
    }
}

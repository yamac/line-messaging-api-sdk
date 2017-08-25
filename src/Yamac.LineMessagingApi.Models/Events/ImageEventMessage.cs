namespace Yamac.LineMessagingApi.Models.Events
{
    public class ImageEventMessage : EventMessage
    {
        public override EventMessageType Type { get { return EventMessageType.Image; } }
    }
}

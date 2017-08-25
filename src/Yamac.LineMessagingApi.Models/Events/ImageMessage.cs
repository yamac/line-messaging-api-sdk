namespace Yamac.LineMessagingApi.Models.Events
{
    public class ImageMessage : EventMessage
    {
        public override EventMessageType Type { get { return EventMessageType.Image; } }
    }
}

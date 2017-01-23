namespace Yamac.LineMessagingApi.Event
{
    public class ImageMessage : Message
    {
        public override MessageType Type { get { return MessageType.Image; } }
    }
}

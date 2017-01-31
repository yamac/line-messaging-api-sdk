namespace Yamac.LineMessagingApi.Events
{
    public class ImageMessage : Message
    {
        public override MessageType Type { get { return MessageType.Image; } }
    }
}

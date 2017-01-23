namespace Yamac.LineMessagingApi.Event
{
    public class VideoMessage : Message
    {
        public override MessageType Type { get { return MessageType.Video; } }
    }
}

namespace Yamac.LineMessagingApi.Events
{
    public class VideoMessage : Message
    {
        public override MessageType Type { get { return MessageType.Video; } }
    }
}

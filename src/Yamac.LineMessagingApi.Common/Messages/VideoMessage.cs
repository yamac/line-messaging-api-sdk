namespace Yamac.LineMessagingApi.Messages
{
    public class VideoMessage : Message
    {
        public override MessageType Type { get { return MessageType.Video; } }

        public string OriginalContentUrl { get; set; }

        public string PreviewImageUrl { get; set; }
    }
}

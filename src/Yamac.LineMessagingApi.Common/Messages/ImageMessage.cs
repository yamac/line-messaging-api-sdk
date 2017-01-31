namespace Yamac.LineMessagingApi.Messages
{
    public class ImageMessage : Message
    {
        public override MessageType Type { get { return MessageType.Image; } }

        public string OriginalContentUrl { get; set; }

        public string PreviewImageUrl { get; set; }
    }
}

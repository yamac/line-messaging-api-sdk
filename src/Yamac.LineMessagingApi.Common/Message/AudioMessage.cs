namespace Yamac.LineMessagingApi.Message
{
    public class AudioMessage : Message
    {
        public override MessageType Type { get { return MessageType.Audio; } }

        public string OriginalContentUrl { get; set; }

        public int Duration { get; set; }
    }
}

namespace Yamac.LineMessagingApi.Models.Messages
{
    public class TextMessage : Message
    {
        public override MessageType Type { get { return MessageType.Text; } }

        public string Text { get; set; }
    }
}

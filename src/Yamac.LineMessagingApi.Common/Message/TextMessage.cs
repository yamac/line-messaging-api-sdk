namespace Yamac.LineMessagingApi.Message
{
    public class TextMessage : Message
    {
        public override MessageType Type { get { return MessageType.Text; } }

        public string Text { get; set; }
    }
}

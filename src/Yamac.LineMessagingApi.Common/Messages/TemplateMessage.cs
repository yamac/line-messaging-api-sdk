namespace Yamac.LineMessagingApi.Messages
{
    public class TemplateMessage : Message
    {
        public override MessageType Type { get { return MessageType.Template; } }

        public string AltText { get; set; }

        public Templates.Template Template { get; set; }
    }
}

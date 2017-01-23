namespace Yamac.LineMessagingApi.Message
{
    public class TemplateMessage : Message
    {
        public override MessageType Type { get { return MessageType.Template; } }

        public string AltText { get; set; }

        public Template.Template Template { get; set; }
    }
}

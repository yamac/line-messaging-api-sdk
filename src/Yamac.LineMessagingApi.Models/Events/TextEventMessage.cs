namespace Yamac.LineMessagingApi.Models.Events
{
    public class TextEventMessage : EventMessage
    {
        public override EventMessageType Type { get { return EventMessageType.Text; } }

        public string Text { get; set; }
    }
}

namespace Yamac.LineMessagingApi.Event
{
    public class UnknownMessage : Message
    {
        public override MessageType Type { get { return MessageType.Unknown; } }
    }
}

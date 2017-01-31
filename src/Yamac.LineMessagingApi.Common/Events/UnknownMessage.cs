namespace Yamac.LineMessagingApi.Events
{
    public class UnknownMessage : Message
    {
        public override MessageType Type { get { return MessageType.Unknown; } }
    }
}

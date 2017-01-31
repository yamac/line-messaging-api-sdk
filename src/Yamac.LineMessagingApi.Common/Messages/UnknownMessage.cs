namespace Yamac.LineMessagingApi.Messages
{
    public class UnknownMessage : Message
    {
        public override MessageType Type { get { return MessageType.Unknown; } }
    }
}

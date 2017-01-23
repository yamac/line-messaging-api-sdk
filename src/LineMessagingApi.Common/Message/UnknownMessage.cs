namespace Yamac.LineMessagingApi.Message
{
    public class UnknownMessage : Message
    {
        public override MessageType Type { get { return MessageType.Unknown; } }
    }
}

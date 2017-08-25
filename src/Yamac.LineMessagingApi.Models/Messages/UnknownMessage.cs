namespace Yamac.LineMessagingApi.Models.Messages
{
    public class UnknownMessage : Message
    {
        public override MessageType Type { get { return MessageType.Unknown; } }
    }
}

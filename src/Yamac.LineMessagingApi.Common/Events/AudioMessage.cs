namespace Yamac.LineMessagingApi.Events
{
    public class AudioMessage : Message
    {
        public override MessageType Type { get { return MessageType.Audio; } }
    }
}

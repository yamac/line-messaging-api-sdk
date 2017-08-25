namespace Yamac.LineMessagingApi.Models.Events
{
    public class VideoMessage : EventMessage
    {
        public override EventMessageType Type { get { return EventMessageType.Video; } }
    }
}

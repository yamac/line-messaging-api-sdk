namespace Yamac.LineMessagingApi.Models.Events
{
    public class VideoEventMessage : EventMessage
    {
        public override EventMessageType Type { get { return EventMessageType.Video; } }
    }
}

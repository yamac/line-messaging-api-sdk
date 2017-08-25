namespace Yamac.LineMessagingApi.Models.Events
{
    public class UnknownEvent : Event
    {
        public override EventType Type { get { return EventType.Unknown; } }
    }
}

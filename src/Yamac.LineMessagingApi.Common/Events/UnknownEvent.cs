namespace Yamac.LineMessagingApi.Events
{
    public class UnknownEvent : Event
    {
        public override EventType Type { get { return EventType.Unknown; } }
    }
}

namespace Yamac.LineMessagingApi.Event
{
    public class UnknownEvent : Event
    {
        public override EventType Type { get { return EventType.Unknown; } }
    }
}

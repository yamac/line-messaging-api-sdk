namespace Yamac.LineMessagingApi.Event
{
    public class LeaveEvent : Event
    {
        public override EventType Type { get { return EventType.Leave; } }
    }
}

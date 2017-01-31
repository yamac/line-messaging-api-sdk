namespace Yamac.LineMessagingApi.Events
{
    public class LeaveEvent : Event
    {
        public override EventType Type { get { return EventType.Leave; } }
    }
}

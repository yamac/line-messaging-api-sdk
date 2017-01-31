namespace Yamac.LineMessagingApi.Events
{
    public class UnfollowEvent : Event
    {
        public override EventType Type { get { return EventType.Unfollow; } }
    }
}

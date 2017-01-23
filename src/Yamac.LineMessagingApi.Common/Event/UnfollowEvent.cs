namespace Yamac.LineMessagingApi.Event
{
    public class UnfollowEvent : Event
    {
        public override EventType Type { get { return EventType.Unfollow; } }
    }
}

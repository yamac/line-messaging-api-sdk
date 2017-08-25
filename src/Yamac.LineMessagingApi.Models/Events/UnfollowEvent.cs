namespace Yamac.LineMessagingApi.Models.Events
{
    public class UnfollowEvent : Event
    {
        public override EventType Type { get { return EventType.Unfollow; } }
    }
}

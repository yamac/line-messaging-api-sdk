namespace Yamac.LineMessagingApi.Models.Events
{
    public class JoinEvent : Event
    {
        public override EventType Type { get { return EventType.Join; } }

        public string ReplyToken { get; set; }
    }
}

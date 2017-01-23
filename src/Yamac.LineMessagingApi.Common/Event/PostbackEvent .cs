namespace Yamac.LineMessagingApi.Event
{
    public class PostbackEvent : Event
    {
        public override EventType Type { get { return EventType.Postback; } }

        public string ReplyToken { get; set; }

        public Postback Postback { get; set; }
    }
}

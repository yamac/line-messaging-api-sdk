namespace Yamac.LineMessagingApi.Models.Events
{
    public class BeaconEvent : Event
    {
        public override EventType Type { get { return EventType.Beacon; } }

        public string ReplyToken { get; set; }

        public Beacon Beacon { get; set; }
    }
}

namespace Yamac.LineMessagingApi.Events
{
    public class RoomSource : Source
    {
        public override SourceType Type { get { return SourceType.Room; } }

        public override string SenderId { get { return RoomId; } }

        public string UserId { get; set; }

        public string RoomId { get; set; }
    }
}

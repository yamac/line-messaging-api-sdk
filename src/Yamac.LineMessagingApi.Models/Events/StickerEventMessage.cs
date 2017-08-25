namespace Yamac.LineMessagingApi.Models.Events
{
    public class StickerEventMessage : EventMessage
    {
        public override EventMessageType Type { get { return EventMessageType.Sticker; } }

        public string PackageId { get; set; }

        public string StickerId { get; set; }
    }
}

namespace Yamac.LineMessagingApi.Message
{
    public class StickerMessage : Message
    {
        public override MessageType Type { get { return MessageType.Sticker; } }

        public string PackageId { get; set; }

        public string StickerId { get; set; }
    }
}

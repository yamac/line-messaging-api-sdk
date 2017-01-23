namespace Yamac.LineMessagingApi.Message
{
    public class LocationMessage : Message
    {
        public override MessageType Type { get { return MessageType.Location; } }

        public string Title { get; set; }

        public string Address { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }
    }
}

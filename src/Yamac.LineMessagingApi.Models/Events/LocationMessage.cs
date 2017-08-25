namespace Yamac.LineMessagingApi.Models.Events
{
    public class LocationMessage : EventMessage
    {
        public override EventMessageType Type { get { return EventMessageType.Location; } }

        public string Title { get; set; }

        public string Address { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }
    }
}

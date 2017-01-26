namespace Yamac.LineMessagingApi.Middleware
{
    public class LineMessagingMiddlewareOptions
    {
        public string ChannelId { get; set; }

        public string ChannelSecret { get; set; }

        public string ChannelAccessToken { get; set; }

        public string WebhookPath { get; set; }
    }
}

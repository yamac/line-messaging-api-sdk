namespace Yamac.LineMessagingApi.AspNetCore.Middleware
{
    public class LineMessagingMiddlewareOptions
    {
        public string ChannelId { get; set; }

        public string ChannelSecret { get; set; }

        public string ChannelAccessToken { get; set; }

        public string WebhookPath { get; set; }
    }
}

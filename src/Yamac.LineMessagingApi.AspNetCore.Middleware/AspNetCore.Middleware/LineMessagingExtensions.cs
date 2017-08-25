using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Options;
using System;

namespace Yamac.LineMessagingApi.AspNetCore.Middleware
{
    public static class LineMessagingExtensions
    {
        public static IApplicationBuilder UseLineMessaging(this IApplicationBuilder app, LineMessagingMiddlewareOptions options)
        {
            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }

            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            if (options.ChannelId == null)
            {
                throw new ArgumentNullException(nameof(options.ChannelId));
            }

            if (options.ChannelSecret == null)
            {
                throw new ArgumentNullException(nameof(options.ChannelSecret));
            }

            if (options.ChannelAccessToken == null)
            {
                throw new ArgumentNullException(nameof(options.ChannelAccessToken));
            }

            if (options.WebhookPath == null)
            {
                throw new ArgumentNullException(nameof(options.WebhookPath));
            }

            return app.UseMiddleware<LineMessagingMiddleware>(Options.Create(options));
        }
    }
}

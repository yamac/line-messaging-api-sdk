using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Options;
using System;

namespace Yamac.LineMessagingApi.Middleware
{
    public static class LineMessagingExtensions
    {
        private const string DEFAULT_REQUEST_PATH = "/linemessaging/callback";

        public static IApplicationBuilder UseLineMessaging(this IApplicationBuilder app)
        {
            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }

            return app.UseLineMessaging(new LineMessagingMiddlewareOptions
            {
                RequestPath = DEFAULT_REQUEST_PATH,
            });
        }

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

            return app.UseMiddleware<LineMessagingMiddleware>(Options.Create(options));
        }
    }
}

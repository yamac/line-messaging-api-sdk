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

            return app.UseMiddleware<LineMessagingMiddleware>(Options.Create(options));
        }
    }
}

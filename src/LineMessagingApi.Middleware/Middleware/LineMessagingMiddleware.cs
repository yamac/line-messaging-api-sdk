using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Text;
using System.Threading.Tasks;

namespace Yamac.LineMessagingApi.Middleware
{
    public class LineMessagingMiddleware
    {
        private const string X_LINE_SIGNATURE = "X-Line-Signature";

        private readonly RequestDelegate _next;

        private readonly LineMessagingMiddlewareOptions _middlewareOptions;

        private readonly LineMessagingOptions _options;

        private readonly ILineMessagingRequestHandler _handler;

        private readonly ILogger _logger;

        private readonly LineMessagingSignatureValidator _signatureValidator;

        public LineMessagingMiddleware(
            RequestDelegate next,
            IOptions<LineMessagingMiddlewareOptions> middlewareOptions,
            IOptions<LineMessagingOptions> options,
            ILineMessagingRequestHandler handler,
            ILoggerFactory loggerFactory)
        {
            _next = next;
            _middlewareOptions = middlewareOptions?.Value ?? throw new ArgumentNullException(nameof(middlewareOptions));
            _options = options?.Value ?? throw new ArgumentNullException(nameof(_options));
            _handler = handler ?? throw new ArgumentNullException(nameof(_handler));
            _logger = loggerFactory.CreateLogger<LineMessagingMiddleware>();
            _signatureValidator = new LineMessagingSignatureValidator(_options.ChannelSecret);
        }

        public async Task Invoke(HttpContext context)
        {
            if (ShouldHandleRequest(context))
            {
                HandleRequest(context);
            }
            else
            {
                await _next(context);
            }
        }

        private bool ShouldHandleRequest(HttpContext context)
        {
            var request = context.Request;

            // Handle only if the signature header is provided.
            if (!request.Headers.ContainsKey(X_LINE_SIGNATURE))
            {
                return false;
            }

            // Handle only POST method.
            if (!HttpMethods.IsPost(request.Method))
            {
                return false;
            }

            // Handle only if the request path matches.
            if (!request.Path.Equals(_middlewareOptions.RequestPath, StringComparison.Ordinal))
            {
                return false;
            }

            return true;
        }

        private void HandleRequest(HttpContext context)
        {
            var request = context.Request;

            // Read content as an array of bytes.
            var contentBytes = new byte[request.ContentLength.Value];
            request.Body.Read(contentBytes, 0, (int)request.ContentLength.Value);

            // Validate signature header.
            bool isValid = _signatureValidator.ValidateSignature(contentBytes, request.Headers[X_LINE_SIGNATURE]);
            if (!isValid)
            {
            }

            // Deserialize content to a CallbackRequest object.
            var contentJson = Encoding.UTF8.GetString(contentBytes);
            _logger.LogDebug("request: {}", contentJson);
            var lineMessagingRequest = JsonConvert.DeserializeObject<LineMessagingRequest>(contentJson);

            // Handle LineMessagingRequest by handler.
            _handler.HandleRequest(lineMessagingRequest);

            // Write response.
            context.Response.ContentType = "text/plain";
            context.Response.WriteAsync("OK");
        }
    }
}

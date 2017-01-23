namespace Yamac.LineMessagingApi.Middleware
{
    public interface ILineMessagingRequestHandler
    {
        void HandleRequest(LineMessagingRequest request);
    }
}

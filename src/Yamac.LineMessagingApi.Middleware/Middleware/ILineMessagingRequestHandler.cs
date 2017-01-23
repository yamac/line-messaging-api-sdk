using System.Threading.Tasks;

namespace Yamac.LineMessagingApi.Middleware
{
    public interface ILineMessagingRequestHandler
    {
        Task HandleRequestAsync(LineMessagingRequest request);
    }
}

using System.Threading.Tasks;

namespace Yamac.LineMessagingApi.AspNetCore.Middleware
{
    public interface ILineMessagingRequestHandler
    {
        Task HandleRequestAsync(LineMessagingRequest request);
    }
}

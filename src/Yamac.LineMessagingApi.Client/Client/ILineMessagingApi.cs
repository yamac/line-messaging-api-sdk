using System.IO;
using System.Threading.Tasks;
using Yamac.LineMessagingApi.Message;
using Yamac.LineMessagingApi.User;

namespace Yamac.LineMessagingApi.Client
{
    public interface ILineMessagingApi
    {
        Task<ApiResponse> ReplyMessageAsync(ReplyMessage replyMessage);

        Task<ApiResponse> PushMessageAsync(PushMessage pushMessage);

        Task<ApiResponse> MulticastAsync(Multicast multicast);

        Task<Stream> GetMessageContentAsync(string messageId);

        Task<Profile> GetProfileAsync(string userId);

        Task<ApiResponse> LeaveGroupAsync(string groupId);

        Task<ApiResponse> LeaveRoomAsync(string roomId);
    }
}

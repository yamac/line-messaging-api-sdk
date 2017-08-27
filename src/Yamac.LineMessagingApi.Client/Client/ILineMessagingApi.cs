using System.IO;
using System.Threading.Tasks;
using Yamac.LineMessagingApi.Models.Messages;
using Yamac.LineMessagingApi.Models.Users;

namespace Yamac.LineMessagingApi.Client
{
    public interface ILineMessagingApi
    {
        Task<ApiResponse> ReplyMessageAsync(ReplyMessage replyMessage);

        Task<ApiResponse> PushMessageAsync(PushMessage pushMessage);

        Task<ApiResponse> MulticastAsync(Multicast multicast);

        Task<Stream> GetMessageContentAsync(string messageId);

        Task<Profile> GetProfileAsync(string userId);

        Task<MemberProfile> GetGroupMemberProfileAsync(string groupId, string userId);

        Task<MemberProfile> GetRoomMemberProfileAsync(string roomId, string userId);

        Task<ApiResponse> LeaveGroupAsync(string groupId);

        Task<ApiResponse> LeaveRoomAsync(string roomId);
    }
}

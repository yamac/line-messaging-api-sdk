using System.IO;
using Yamac.LineMessagingApi.Message;
using Yamac.LineMessagingApi.User;

namespace Yamac.LineMessagingApi.Client
{
    public interface ILineMessagingApi
    {
        ApiResponse ReplyMessage(ReplyMessage replyMessage);

        ApiResponse PushMessage(PushMessage pushMessage);

        ApiResponse Multicast(Multicast multicast);

        Stream GetMessageContent(string messageId);

        Profile GetProfile(string userId);

        ApiResponse LeaveGroup(string groupId);

        ApiResponse LeaveRoom(string roomId);
    }
}

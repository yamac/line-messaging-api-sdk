using Newtonsoft.Json;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Yamac.LineMessagingApi.Models.Messages;
using Yamac.LineMessagingApi.Models.Users;

namespace Yamac.LineMessagingApi.Client
{
    public class LineMessagingApi : ILineMessagingApi
    {
        private HttpClient HttpClient { get; set; } = new HttpClient();

        public string ApiEndpointBase { get; set; } = "https://api.line.me/";

        public LineMessagingApi() { }

        public LineMessagingApi(string channelToken) : this()
        {
            HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", channelToken);
        }

        private async Task<T> CallGetApiAsJsonResponseAsync<T>(string endpointUrl)
        {
            var response = await HttpClient.GetAsync(ApiEndpointBase + endpointUrl);
            if (response.IsSuccessStatusCode)
            {
                var responseJson = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(responseJson);
            }
            else
            {
                await HandleErrorAsync(response);
                return default(T);
            }
        }

        private async Task<Stream> CallGetApiAsStreamAsync(string endpointUrl)
        {
            var response = await HttpClient.GetAsync(ApiEndpointBase + endpointUrl);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStreamAsync();
            }
            else
            {
                await HandleErrorAsync(response);
                return default(Stream);
            }
        }

        private async Task<T> CallPostApiAsJsonResponseAsync<T>(string endpointUrl, object contentToPost = null)
        {
            var requestJson = contentToPost != null ? JsonConvert.SerializeObject(contentToPost) : string.Empty;
            var content = new StringContent(requestJson, Encoding.UTF8, "application/json");
            var response = await HttpClient.PostAsync(ApiEndpointBase + endpointUrl, content);
            if (response.IsSuccessStatusCode)
            {
                var responseJson = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(responseJson);
            }
            else
            {
                await HandleErrorAsync(response);
                return default(T);
            }
        }

        private async Task HandleErrorAsync(HttpResponseMessage response)
        {
            var contentJson = await response.Content.ReadAsStringAsync();
            var errorResponse = JsonConvert.DeserializeObject<ErrorResponse>(contentJson);
            throw new ErrorResponseException(errorResponse);
        }

        public async Task<ApiResponse> ReplyMessageAsync(ReplyMessage replyMessage)
        {
            return await CallPostApiAsJsonResponseAsync<ApiResponse>("v2/bot/message/reply", replyMessage);
        }

        public async Task<ApiResponse> PushMessageAsync(PushMessage pushMessage)
        {
            return await CallPostApiAsJsonResponseAsync<ApiResponse>("v2/bot/message/push", pushMessage);
        }

        public async Task<ApiResponse> MulticastAsync(Multicast multicast)
        {
            return await CallPostApiAsJsonResponseAsync<ApiResponse>("v2/bot/message/multicast", multicast);
        }

        public async Task<Stream> GetMessageContentAsync(string messageId)
        {
            return await CallGetApiAsStreamAsync($"v2/bot/message/{messageId}/content");
        }

        public async Task<Profile> GetProfileAsync(string userId)
        {
            return await CallGetApiAsJsonResponseAsync<Profile>($"v2/bot/profile/{userId}");
        }

        public async Task<MemberProfile> GetGroupMemberProfileAsync(string groupId, string userId)
        {
            return await CallGetApiAsJsonResponseAsync<MemberProfile>($"v2/bot/group/{groupId}/member/{userId}");
        }

        public async Task<MemberProfile> GetRoomMemberProfileAsync(string roomId, string userId)
        {
            return await CallGetApiAsJsonResponseAsync<MemberProfile>($"v2/bot/room/{roomId}/member/{userId}");
        }

        public async Task<ApiResponse> LeaveGroupAsync(string groupId)
        {
            return await CallPostApiAsJsonResponseAsync<ApiResponse>($"v2/bot/group/{groupId}/leave");
        }

        public async Task<ApiResponse> LeaveRoomAsync(string roomId)
        {
            return await CallPostApiAsJsonResponseAsync<ApiResponse>($"v2/bot/room/{roomId}/leave");
        }
    }
}

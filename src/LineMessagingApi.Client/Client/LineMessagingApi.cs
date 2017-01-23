using Newtonsoft.Json;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Yamac.LineMessagingApi.Message;
using Yamac.LineMessagingApi.User;

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

        private T CallGetApiAsJsonResponse<T>(string endpointUrl)
        {
            var response = HttpClient.GetAsync(ApiEndpointBase + endpointUrl).Result;
            if (response.IsSuccessStatusCode)
            {
                var responseJson = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<T>(responseJson);
            }
            else
            {
                HandleError(response);
                return default(T);
            }
        }

        private Stream CallGetApiAsStream(string endpointUrl)
        {
            var response = HttpClient.GetAsync(ApiEndpointBase + endpointUrl).Result;
            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsStreamAsync().Result;
            }
            else
            {
                HandleError(response);
                return default(Stream);
            }
        }

        private T CallPostApiAsJsonResponse<T>(string endpointUrl, object contentToPost = null)
        {
            var requestJson = contentToPost != null ? JsonConvert.SerializeObject(contentToPost) : string.Empty;
            var content = new StringContent(requestJson, Encoding.UTF8, "application/json");
            var response = HttpClient.PostAsync(ApiEndpointBase + endpointUrl, content).Result;
            if (response.IsSuccessStatusCode)
            {
                var responseJson = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<T>(responseJson);
            }
            else
            {
                HandleError(response);
                return default(T);
            }
        }

        private void HandleError(HttpResponseMessage response)
        {
            var contentJson = response.Content.ReadAsStringAsync().Result;
            var errorResponse = JsonConvert.DeserializeObject<ErrorResponse>(contentJson);
            throw new ErrorResponseException(errorResponse);
        }

        public ApiResponse ReplyMessage(ReplyMessage replyMessage)
        {
            return CallPostApiAsJsonResponse<ApiResponse>("v2/bot/message/reply", replyMessage);
        }

        public ApiResponse PushMessage(PushMessage pushMessage)
        {
            return CallPostApiAsJsonResponse<ApiResponse>("v2/bot/message/push", pushMessage);
        }

        public ApiResponse Multicast(Multicast multicast)
        {
            return CallPostApiAsJsonResponse<ApiResponse>("v2/bot/message/multicast", multicast);
        }

        public Stream GetMessageContent(string messageId)
        {
            return CallGetApiAsStream($"v2/bot/message/{messageId}/content");
        }

        public Profile GetProfile(string userId)
        {
            return CallGetApiAsJsonResponse<Profile>($"v2/bot/profile/{userId}");
        }

        public ApiResponse LeaveGroup(string groupId)
        {
            return CallPostApiAsJsonResponse<ApiResponse>($"v2/bot/group/{groupId}/leave");
        }

        public ApiResponse LeaveRoom(string roomId)
        {
            return CallPostApiAsJsonResponse<ApiResponse>($"v2/bot/room/{roomId}/leave");
        }
    }
}

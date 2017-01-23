using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Yamac.LineMessagingApi.User
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class Profile
    {
        public string DisplayName { get; set; }

        public string UserId { get; set; }

        public string PictureUrl { get; set; }

        public string StatusMessage { get; set; }
    }
}

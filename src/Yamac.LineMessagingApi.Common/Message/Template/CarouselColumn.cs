using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;

namespace Yamac.LineMessagingApi.Message.Template
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class CarouselColumn
    {
        public string ThumbnailImageUrl { get; set; }

        public string Title { get; set; }

        public string Text { get; set; }

        [JsonConverter(typeof(JsonActionConverter))]
        public List<Action> Actions { get; set; } = new List<Action>();
    }
}

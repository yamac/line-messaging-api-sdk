using Newtonsoft.Json;
using System.Collections.Generic;
using Yamac.LineMessagingApi.Models.Messages.Imagemaps;

namespace Yamac.LineMessagingApi.Models.Messages
{
    public class ImagemapMessage : Message
    {
        public override MessageType Type { get { return MessageType.Imagemap; } }

        public string BaseUrl { get; set; }

        public string AltText { get; set; }

        public BaseSize BaseSize { get; set; }

        [JsonConverter(typeof(JsonActionConverter))]
        public List<Action> Actions { get; set; } = new List<Action>();
    }
}

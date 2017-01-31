using Newtonsoft.Json;
using System.Collections.Generic;
using Yamac.LineMessagingApi.Messages.Imagemaps;

namespace Yamac.LineMessagingApi.Messages
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

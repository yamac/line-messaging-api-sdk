using Newtonsoft.Json;
using System.Collections.Generic;

namespace Yamac.LineMessagingApi.Message.Template
{
    public class ButtonsTemplate : Template
    {
        public override TemplateType Type { get { return TemplateType.Buttons; } }

        public string ThumbnailImageUrl { get; set; }

        public string Title { get; set; }

        public string Text { get; set; }

        [JsonConverter(typeof(JsonActionConverter))]
        public List<Action> Actions { get; set; } = new List<Action>();
    }
}

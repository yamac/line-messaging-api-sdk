using Newtonsoft.Json;
using System.Collections.Generic;

namespace Yamac.LineMessagingApi.Messages.Templates
{
    public class ConfirmTemplate : Template
    {
        public override TemplateType Type { get { return TemplateType.Confirm; } }

        public string Text { get; set; }

        [JsonConverter(typeof(JsonActionConverter))]
        public List<Action> Actions { get; set; } = new List<Action>();
    }
}

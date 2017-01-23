using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System;
using Yamac.LineMessagingApi.Common.Utilities.Json;

namespace Yamac.LineMessagingApi.Message.Template
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public abstract class Template
    {
        [JsonConverter(typeof(StringEnumConverter), true)]
        public abstract TemplateType Type { get; }
    }

    public enum TemplateType
    {
        Buttons,
        Confirm,
        Carousel,
        Unknown,
    }

    public class JsonTemplateConverter : JsonCreationConverter<Template>
    {
        protected override Template Create(Type objectType, JObject jsonObject)
        {
            var typeName = jsonObject["type"].ToString();
            switch (typeName)
            {
                case "buttons": return new ButtonsTemplate();
                case "confirm": return new ConfirmTemplate();
                case "carousel": return new CarouselTemplate();
                default: return new UnknownTemplate();
            }
        }
    }
}

using System.Collections.Generic;

namespace Yamac.LineMessagingApi.Message.Template
{
    public class CarouselTemplate : Template
    {
        public override TemplateType Type { get { return TemplateType.Carousel; } }

        public List<CarouselColumn> Columns { get; set; } = new List<CarouselColumn>();
    }
}

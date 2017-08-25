using System;

namespace Yamac.LineMessagingApi.Models.Events
{
    public class UnknownSource : Source
    {
        public override SourceType Type { get { return SourceType.Unknown; } }

        public override string SenderId => throw new NotSupportedException("Unknown SenderId.");
    }
}

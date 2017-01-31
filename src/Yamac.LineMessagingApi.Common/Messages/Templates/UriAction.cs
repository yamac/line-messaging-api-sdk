namespace Yamac.LineMessagingApi.Messages.Templates
{
    public class UriAction : Action
    {
        public override ActionType Type { get { return ActionType.Uri; } }

        public string Label { get; set; }

        public string Uri { get; set; }
    }
}

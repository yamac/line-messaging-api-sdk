namespace Yamac.LineMessagingApi.Messages.Imagemaps
{
    public class UriAction : Action
    {
        public override ActionType Type { get { return ActionType.Uri; } }

        public string LinkUri { get; set; }

        public Area Area { get; set; }
    }
}

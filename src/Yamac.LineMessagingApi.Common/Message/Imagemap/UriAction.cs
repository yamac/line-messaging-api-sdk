namespace Yamac.LineMessagingApi.Message.Imagemap
{
    public class UriAction : Action
    {
        public override ActionType Type { get { return ActionType.Uri; } }

        public string LinkUri { get; set; }

        public Area Area { get; set; }
    }
}

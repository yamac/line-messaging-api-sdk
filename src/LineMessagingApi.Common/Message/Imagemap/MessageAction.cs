namespace Yamac.LineMessagingApi.Message.Imagemap
{
    public class MessageAction : Action
    {
        public override ActionType Type { get { return ActionType.Message; } }

        public string Text { get; set; }

        public Area Area { get; set; }
    }
}

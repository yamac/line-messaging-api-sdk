namespace Yamac.LineMessagingApi.Messages.Templates
{
    public class MessageAction : Action
    {
        public override ActionType Type { get { return ActionType.Message; } }

        public string Label { get; set; }

        public string Text { get; set; }
    }
}

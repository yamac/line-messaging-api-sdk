namespace Yamac.LineMessagingApi.Models.Messages.Templates
{
    public class PostbackAction : Action
    {
        public override ActionType Type { get { return ActionType.Postback; } }

        public string Label { get; set; }

        public string Data { get; set; }

        public string Text { get; set; }
    }
}

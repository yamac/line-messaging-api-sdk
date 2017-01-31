namespace Yamac.LineMessagingApi.Messages.Templates
{
    public class UnknownAction : Action
    {
        public override ActionType Type { get { return ActionType.Unknown; } }
    }
}

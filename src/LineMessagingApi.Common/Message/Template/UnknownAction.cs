﻿namespace Yamac.LineMessagingApi.Message.Template
{
    public class UnknownAction : Action
    {
        public override ActionType Type { get { return ActionType.Unknown; } }
    }
}

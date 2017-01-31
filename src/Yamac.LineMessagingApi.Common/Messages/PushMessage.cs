using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;

namespace Yamac.LineMessagingApi.Messages
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class PushMessage
    {
        public string To { get; set; }

        public List<Message> Messages { get; set; } = new List<Message>();

        public PushMessage(string to, List<Message> messages)
        {
            To = to ?? throw new ArgumentNullException(nameof(to));
            Messages.AddRange(messages ?? throw new ArgumentNullException(nameof(messages)));
        }

        public PushMessage(string to, Message message)
        {
            To = to ?? throw new ArgumentNullException(nameof(to));
            Messages.Add(message ?? throw new ArgumentNullException(nameof(message)));
        }
    }
}

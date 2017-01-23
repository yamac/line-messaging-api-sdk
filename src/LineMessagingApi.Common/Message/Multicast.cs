using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;

namespace Yamac.LineMessagingApi.Message
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class Multicast
    {
        public List<string> To { get; set; } = new List<string>();

        public List<Message> Messages { get; set; } = new List<Message>();

        public Multicast(List<string> to, List<Message> messages)
        {
            To = to ?? throw new ArgumentNullException(nameof(to));
            Messages.AddRange(messages ?? throw new ArgumentNullException(nameof(messages)));
        }

        public Multicast(List<string> to, Message message)
        {
            To = to ?? throw new ArgumentNullException(nameof(to));
            Messages.Add(message ?? throw new ArgumentNullException(nameof(message)));
        }
    }
}

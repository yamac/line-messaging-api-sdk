using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;

namespace Yamac.LineMessagingApi.Messages
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class ReplyMessage
    {
        public string ReplyToken { get; set; }

        public List<Message> Messages { get; set; } = new List<Message>();

        public ReplyMessage(string replyToken, ICollection<Message> messages)
        {
            ReplyToken = replyToken ?? throw new ArgumentNullException(nameof(replyToken));
            Messages.AddRange(messages ?? throw new ArgumentNullException(nameof(messages)));
        }

        public ReplyMessage(string replyToken, Message message)
        {
            ReplyToken = replyToken ?? throw new ArgumentNullException(nameof(replyToken));
            Messages.Add(message ?? throw new ArgumentNullException(nameof(message)));
        }
    }
}

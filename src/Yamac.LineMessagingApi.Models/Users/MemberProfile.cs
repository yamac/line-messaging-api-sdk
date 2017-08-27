﻿using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Yamac.LineMessagingApi.Models.Users
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class MemberProfile
    {
        public string DisplayName { get; set; }

        public string UserId { get; set; }

        public string PictureUrl { get; set; }
    }
}

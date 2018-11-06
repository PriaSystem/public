using System;
using Newtonsoft.Json;

namespace PublicChat.Entity
{
    public class User
    {
        [JsonProperty("uid")]
        public string Uid { get; set; }

        [JsonProperty("nickname")]
        public string Nickname { get; set; }

        [JsonProperty("timestamp")]
        public long Timestamp { get; set; }
    }
}

using System;
using Newtonsoft.Json;

namespace PublicChat.Entity
{
    public class Message
    {
        [JsonProperty("nickname")]
        public string Nickname { get; set; }

        [JsonProperty("message")]
        public string Body { get; set; }

        [JsonProperty("timestamp")]
        public long Timestamp { get; set; }

        string time;
        [JsonIgnore]
        public string Time { get { return time ?? (time = FormatedTimestamp()); } }

        string FormatedTimestamp()
        {
            return new DateTime(Timestamp * 1000).ToString("HH:mm:ss");
        }
    }
}

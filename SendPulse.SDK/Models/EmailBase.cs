using Newtonsoft.Json;
using System.Collections.Generic;

namespace SendPulse.SDK.Models
{
    public abstract class EmailBase
    {
        [JsonProperty("subject")]
        public string Subject { get; set; }

        [JsonProperty("from")]
        public EmailAddress From { get; set; }

        [JsonProperty("to")]
        public List<EmailAddress> To { get; set; }
    }
}

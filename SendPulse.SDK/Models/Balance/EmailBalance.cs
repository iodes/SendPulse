using Newtonsoft.Json;
using System;

namespace SendPulse.SDK.Models
{
    public class EmailBalance
    {
        [JsonProperty("tariff_name")]
        public string TariffName { get; set; }

        [JsonProperty("finished_time")]
        public DateTime FinishedTime { get; set; }

        [JsonProperty("emails_left")]
        public int EmailsLeft { get; set; }

        [JsonProperty("maximum_subscribers")]
        public int MaximumSubscribers { get; set; }

        [JsonProperty("current_subscribers")]
        public int CurrentSubscribers { get; set; }
    }
}

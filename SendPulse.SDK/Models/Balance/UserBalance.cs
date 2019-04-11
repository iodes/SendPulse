using Newtonsoft.Json;

namespace SendPulse.SDK.Models
{
    public class UserBalance
    {
        [JsonProperty("eighty_min_score")]
        public decimal Main { get; set; }

        [JsonProperty("bonus")]
        public decimal Bonus { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }
    }
}

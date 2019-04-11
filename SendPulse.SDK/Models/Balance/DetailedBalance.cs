using Newtonsoft.Json;

namespace SendPulse.SDK.Models
{
    public class DetailedBalance
    {
        [JsonProperty("balance")]
        public UserBalance Balance { get; set; }

        [JsonProperty("email")]
        public EmailBalance Email { get; set; }

        [JsonProperty("smtp")]
        public SMTPBalance SMTP { get; set; }
    }
}

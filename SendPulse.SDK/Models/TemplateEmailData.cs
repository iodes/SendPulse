using Newtonsoft.Json;
using System.Collections.Generic;

namespace SendPulse.SDK.Models
{
    public class TemplateEmailData : EmailBase
    {
        [JsonIgnore]
        public string TemplateID { get; set; }

        [JsonIgnore]
        public Dictionary<string, string> TemplateVariables { get; set; }

        [JsonProperty("template")]
        internal object TemplateData => new
        {
            id = TemplateID,
            variables = TemplateVariables
        };
    }
}

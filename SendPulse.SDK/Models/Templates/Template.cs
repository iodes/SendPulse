using Newtonsoft.Json;
using System;

namespace SendPulse.SDK.Models
{
    public class Template
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("real_id")]
        public string RealId { get; set; }

        [JsonProperty("lang")]
        public string Language { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("name_slug")]
        public string NameSlug { get; set; }

        [JsonProperty("created")]
        public DateTime Created { get; set; }

        [JsonProperty("full_description")]
        public string Description { get; set; }

        [JsonProperty("preview")]
        public string PreviewUrl { get; set; }

        [JsonProperty("owner")]
        public string Owner { get; set; }
    }
}

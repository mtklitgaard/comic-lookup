using Newtonsoft.Json;

namespace ComicLookup.Domain.Marvel
{
    public class MarvelUrl
    {
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }

        [JsonProperty(PropertyName = "returned")]
        public string Returned { get; set; }
    }
}
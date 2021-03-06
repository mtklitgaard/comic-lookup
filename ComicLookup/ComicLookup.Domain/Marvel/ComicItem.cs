using Newtonsoft.Json;

namespace ComicLookup.Domain.Marvel
{
    public class ComicItem
    {
        [JsonProperty(PropertyName = "resourceURI")]
        public string ResourceURI { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
    }
}
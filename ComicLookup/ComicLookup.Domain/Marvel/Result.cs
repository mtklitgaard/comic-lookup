using System.Collections.Generic;
using Newtonsoft.Json;

namespace ComicLookup.Domain.Marvel
{
    public class Result
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "modified")]
        public string Modified { get; set; }

        [JsonProperty(PropertyName = "thumbnail")]
        public ThumbNail Thumbnail { get; set; }

        [JsonProperty(PropertyName = "resourceURI")]
        public string ResourceURI { get; set; }

        [JsonProperty(PropertyName = "comics")]
        public CommonMarvelElements Comics { get; set; }

        [JsonProperty(PropertyName = "series")]
        public CommonMarvelElements ComicSeries { get; set; }

        [JsonProperty(PropertyName = "stories")]
        public Story Stories { get; set; }

        [JsonProperty(PropertyName = "events")]
        public CommonMarvelElements Events { get; set; }

        [JsonProperty(PropertyName = "urls")]
        public List<MarvelUrl> MarvelUrls { get; set; }
    }
}
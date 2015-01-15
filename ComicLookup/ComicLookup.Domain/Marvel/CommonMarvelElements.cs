using System.Collections.Generic;
using Newtonsoft.Json;

namespace ComicLookup.Domain.Marvel
{
    public class CommonMarvelElements
    {
        [JsonProperty(PropertyName = "available")]
        public string Available { get; set; }

        [JsonProperty(PropertyName = "collectionURI")]
        public string CollectionURI { get; set; }

        [JsonProperty(PropertyName = "items")]
        public List<ComicItem> StoryItems { get; set; }

        [JsonProperty(PropertyName = "returned")]
        public string Returned { get; set; }
    }
}
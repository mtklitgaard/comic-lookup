using System.Collections.Generic;
using Newtonsoft.Json;

namespace ComicLookup.Domain.Marvel
{
    public class CommonMarvelElements
    {
        [JsonProperty(PropertyName = "available")]
        string Available { get; set; }

        [JsonProperty(PropertyName = "collectionURI")]
        string CollectionURI { get; set; }

        [JsonProperty(PropertyName = "items")]
        List<ComicItem> ComicItems { get; set; }

        [JsonProperty(PropertyName = "returned")]
        string Returned { get; set; }
    }
}
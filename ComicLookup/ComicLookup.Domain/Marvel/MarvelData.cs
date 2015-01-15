using System.Collections.Generic;
using Newtonsoft.Json;

namespace ComicLookup.Domain.Marvel
{
    public class MarvelData
    {
        [JsonProperty(PropertyName = "offset")]
        public string Offset { get; set; }

        [JsonProperty(PropertyName = "limit")]
        public string Limit { get; set; }

        [JsonProperty(PropertyName = "total")]
        public string Total { get; set; }

        [JsonProperty(PropertyName = "count")]
        public string Count { get; set; }

        [JsonProperty(PropertyName = "results")]
        public List<Result> Results { get; set; }
    }
}
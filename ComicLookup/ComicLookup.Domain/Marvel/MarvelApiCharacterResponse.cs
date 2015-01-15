using Newtonsoft.Json;

namespace ComicLookup.Domain.Marvel
{
    public class MarvelApiCharacterResponse
    {
        [JsonProperty(PropertyName = "code")]
        public string Code { get; set; }
        
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        [JsonProperty(PropertyName = "copyright")]
        public string Copyright { get; set; }

        [JsonProperty(PropertyName = "attributionText")]
        public string AttributionText { get; set; }

        [JsonProperty(PropertyName = "attributionHTML")]
        public string AttributionHTML { get; set; }

        [JsonProperty(PropertyName = "etag")]
        public string Etag { get; set; }

        [JsonProperty(PropertyName = "data")]
        public MarvelData MarvelDataItem { get; set; }
    }
}
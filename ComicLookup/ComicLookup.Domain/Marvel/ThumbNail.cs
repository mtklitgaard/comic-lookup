using Newtonsoft.Json;

namespace ComicLookup.Domain.Marvel
{
    public class ThumbNail
    {
        [JsonProperty(PropertyName = "path")]
        public string Path { get; set; }

        [JsonProperty(PropertyName = "extension")]
        public string Extension { get; set; }
    }

}
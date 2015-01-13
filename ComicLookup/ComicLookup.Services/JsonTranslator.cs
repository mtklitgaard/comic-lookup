using ComicLookup.Services.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Formatting = System.Xml.Formatting;

namespace ComicLookup.Services
{
    public class JsonTranslator : IJsonTranslator
    {
        public T Deserialize<T>(string content)
        {
            var result = JsonConvert.DeserializeObject<dynamic>(content);
            if (result != null && result["data"] != null)
            {
                content = JsonConvert.SerializeObject(result["data"]);
            }

            var deserializeObject = JsonConvert.DeserializeObject<T>(content);
            return deserializeObject;
        }

        public string Serialize(object objectToTranslate)
        {
            return JsonConvert.SerializeObject(objectToTranslate, (Newtonsoft.Json.Formatting)Formatting.None, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver(), MissingMemberHandling = MissingMemberHandling.Ignore, NullValueHandling = NullValueHandling.Ignore });
        }
    }
}
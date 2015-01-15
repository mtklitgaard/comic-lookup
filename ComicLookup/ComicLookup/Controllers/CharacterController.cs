using System.Web.Http;
using ComicLookup.Domain;
using ComicLookup.Domain.Marvel;
using ComicLookup.Services.Builders.Interfaces;

namespace ComicLookup.Controllers
{
    public class CharacterController : ApiController
    {
        private readonly ICharacterBuilder _characterBuilder;

        public CharacterController(ICharacterBuilder characterBuilder)
        {
            _characterBuilder = characterBuilder;
        }

        [HttpGet]
        public ResponseEnvelope<MarvelApiCharacterResponse> Name(string name)
        {
            var responseEnvelope = new ResponseEnvelope<MarvelApiCharacterResponse>();
            if (!string.IsNullOrWhiteSpace(name))
            {
                responseEnvelope.Result = _characterBuilder.GetCharacterByName(name);
            }
            return responseEnvelope;
        }
    }
}
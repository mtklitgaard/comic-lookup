using System.Web.Http;
using ComicLookup.Domain;
using ComicLookup.Domain.Marvel;
using ComicLookup.Infrastructure;
using ComicLookup.Services.Builders.Interfaces;

namespace ComicLookup.Controllers
{
    public class CharacterController : ApiController
    {
        private readonly ICharacterBuilder _characterBuilder;
        private readonly ICharacterComicsBuilder _characterComicsBuilder;

        public CharacterController(ICharacterBuilder characterBuilder, ICharacterComicsBuilder characterComicsBuilder)
        {
            _characterBuilder = characterBuilder;
            _characterComicsBuilder = characterComicsBuilder;
        }

        [HttpGet]
        [ApiKeyFilter]
        public ResponseEnvelope<MarvelApiCharacterResponse> Name(string name)
        {
            var responseEnvelope = new ResponseEnvelope<MarvelApiCharacterResponse>();
            
            if (!string.IsNullOrWhiteSpace(name))
            {
                responseEnvelope.Result = _characterBuilder.GetCharacterByName(name);
            }
            return responseEnvelope;
        }

        public ResponseEnvelope<MarvelApiCharacterComicsResponse> Comics(int characterId)
        {
            var responseEnvelope = new ResponseEnvelope<MarvelApiCharacterComicsResponse>();
            var response = new ResponseEnvelope<MarvelApiCharacterComicsResponse>
            {
                Result = _characterComicsBuilder.GetComics(characterId)
            };
            return response;
        }
    }
}
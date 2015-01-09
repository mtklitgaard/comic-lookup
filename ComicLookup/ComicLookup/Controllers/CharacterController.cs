using System.Web.Http;
using ComicLookup.Domain;
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
        public ResponseEnvelope<Character> Name(string name)
        {
            var responseEnvelope = new ResponseEnvelope<Character>();
            if (!string.IsNullOrWhiteSpace(name))
            {
                responseEnvelope.Result = _characterBuilder.GetCharacterByName(name);
            }
            return responseEnvelope;
        }
    }
}
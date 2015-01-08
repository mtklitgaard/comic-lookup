using System.Web.Http;
using ComicLookup.Domain;

namespace ComicLookup.Controllers
{
    public class CharacterController : ApiController
    {
        public ResponseEnvelope<Character> Name(string name)
        {
            var responseEnvelope = new ResponseEnvelope<Character>();
            responseEnvelope.Result = new Character();
            return responseEnvelope;
        }
    }
}
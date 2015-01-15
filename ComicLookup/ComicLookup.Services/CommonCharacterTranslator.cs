using ComicLookup.Domain;
using ComicLookup.Domain.Marvel;
using ComicLookup.Services.Interfaces;

namespace ComicLookup.Services
{
    public class CommonCharacterTranslator : ICommonCharacterTranslator
    {
        public Character Translate(MarvelApiCharacterResponse marvelApiCharacterResponse)
        {
            throw new System.NotImplementedException();
        }
    }
}
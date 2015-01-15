using ComicLookup.Domain;
using ComicLookup.Domain.Marvel;

namespace ComicLookup.Services.Interfaces
{
    public interface ICommonCharacterTranslator
    {
        Character Translate(MarvelApiCharacterResponse marvelApiCharacterResponse);
    }
}
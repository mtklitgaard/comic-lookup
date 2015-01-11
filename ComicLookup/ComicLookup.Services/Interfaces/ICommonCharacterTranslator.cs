using ComicLookup.Domain;

namespace ComicLookup.Services.Interfaces
{
    public interface ICommonCharacterTranslator
    {
        Character Translate(MarvelApiCharacterResponse marvelApiCharacterResponse);
    }
}
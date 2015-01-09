using ComicLookup.Domain;

namespace ComicLookup.Services.Adapters.Interfaces
{
    public interface IMarvelApiAdapter
    {
        MarvelApiCharacterResponse GetCharacterByName(string name);
    }
}
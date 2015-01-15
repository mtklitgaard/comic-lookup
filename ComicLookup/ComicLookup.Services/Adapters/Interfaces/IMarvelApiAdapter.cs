using ComicLookup.Domain;
using ComicLookup.Domain.Marvel;

namespace ComicLookup.Services.Adapters.Interfaces
{
    public interface IMarvelApiAdapter
    {
        MarvelApiCharacterResponse GetCharacterByName(string name);
    }
}
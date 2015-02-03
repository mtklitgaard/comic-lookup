using ComicLookup.Domain;

namespace ComicLookup.Services.Builders.Interfaces
{
    public interface ICharacterComicsBuilder
    {
        MarvelApiCharacterComicsResponse GetComics(int characterId);
    }
}
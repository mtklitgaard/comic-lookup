using ComicLookup.Domain.Marvel;

namespace ComicLookup.Services.Builders.Interfaces
{
    public interface ICharacterBuilder
    {
        MarvelApiCharacterResponse GetCharacterByName(string characterName);
    }
}
using ComicLookup.Domain;

namespace ComicLookup.Services.Builders.Interfaces
{
    public interface ICharacterBuilder
    {
        Character GetCharacterByName(string characterName);
    }
}
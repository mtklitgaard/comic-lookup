using ComicLookup.Domain;
using ComicLookup.Services.Adapters.Interfaces;
using ComicLookup.Services.Builders.Interfaces;

namespace ComicLookup.Services.Builders
{
    public class CharacterBuilder : ICharacterBuilder
    {
        private readonly IMarvelApiAdapter _marvelApiAdapter;

        public CharacterBuilder(IMarvelApiAdapter marvelApiAdapter)
        {
            _marvelApiAdapter = marvelApiAdapter;
        }

        public Character GetCharacterByName(string characterName)
        {
            _marvelApiAdapter.GetCharacterByName(characterName);
            return null;
        }
    }
}
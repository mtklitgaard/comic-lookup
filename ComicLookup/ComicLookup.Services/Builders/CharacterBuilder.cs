using ComicLookup.Domain;
using ComicLookup.Domain.Marvel;
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

        public MarvelApiCharacterResponse GetCharacterByName(string characterName)
        {
            var marvelResponse = _marvelApiAdapter.GetCharacterByName(characterName);
            return marvelResponse;
        }
    }
}
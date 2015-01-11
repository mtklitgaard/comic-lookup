using ComicLookup.Domain;
using ComicLookup.Services.Adapters.Interfaces;
using ComicLookup.Services.Builders.Interfaces;
using ComicLookup.Services.Interfaces;

namespace ComicLookup.Services.Builders
{
    public class CharacterBuilder : ICharacterBuilder
    {
        private readonly IMarvelApiAdapter _marvelApiAdapter;
        private readonly ICommonCharacterTranslator _commonCharacterTranslator;

        public CharacterBuilder(IMarvelApiAdapter marvelApiAdapter, ICommonCharacterTranslator commonCharacterTranslator)
        {
            _marvelApiAdapter = marvelApiAdapter;
            _commonCharacterTranslator = commonCharacterTranslator;
        }

        public Character GetCharacterByName(string characterName)
        {
            var marvelResponse = _marvelApiAdapter.GetCharacterByName(characterName);
            var character = _commonCharacterTranslator.Translate(marvelResponse);
            return character;
        }
    }
}
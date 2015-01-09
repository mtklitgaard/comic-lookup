using System;
using ComicLookup.Domain;
using ComicLookup.Services.Adapters.Interfaces;

namespace ComicLookup.Services.Adapters
{
    public class MarvelApiAdapter : IMarvelApiAdapter
    {
        public MarvelApiCharacterResponse GetCharacterByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
using System;
using ComicLookup.Domain;
using ComicLookup.Services.Adapters.Interfaces;
using ComicLookup.Services.Interfaces;
using RestSharp;

namespace ComicLookup.Services.Adapters
{
    public class MarvelApiAdapter : IMarvelApiAdapter
    {
        private readonly IMarvelRequestBuilder _marvelRequestBuilder;

        public MarvelApiAdapter(IMarvelRequestBuilder marvelRequestBuilder)
        {
            _marvelRequestBuilder = marvelRequestBuilder;
        }

        public MarvelApiCharacterResponse GetCharacterByName(string name)
        {
            var request = _marvelRequestBuilder.Build("/v1/public/characters", Method.GET);
            return null;
        }
    }
}
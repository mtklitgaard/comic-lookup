using System;
using ComicLookup.Domain;
using ComicLookup.Services.Adapters.Interfaces;
using ComicLookup.Services.Interfaces;
using RestSharp;

namespace ComicLookup.Services.Adapters
{
    public class MarvelApiAdapter : IMarvelApiAdapter
    {
        private readonly IRestRequestBuilder _restRequestBuilder;

        public MarvelApiAdapter(IRestRequestBuilder restRequestBuilder)
        {
            _restRequestBuilder = restRequestBuilder;
        }

        public MarvelApiCharacterResponse GetCharacterByName(string name)
        {
            var request = _restRequestBuilder.Build("/v1/public/characters", Method.GET);
            return null;
        }
    }
}
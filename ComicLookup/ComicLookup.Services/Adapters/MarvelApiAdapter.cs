using System;
using System.Linq.Expressions;
using ComicLookup.Domain;
using ComicLookup.Services.Adapters.Interfaces;
using ComicLookup.Services.Interfaces;
using RestSharp;

namespace ComicLookup.Services.Adapters
{
    public class MarvelApiAdapter : IMarvelApiAdapter
    {
        private readonly IMarvelRequestBuilder _marvelRequestBuilder;
        private readonly IRestClient _restClient;
        private readonly IJsonTranslator _jsonTranslator;

        public MarvelApiAdapter(IMarvelRequestBuilder marvelRequestBuilder, IRestClient restClient, IJsonTranslator jsonTranslator)
        {
            _marvelRequestBuilder = marvelRequestBuilder;
            _restClient = restClient;
            _jsonTranslator = jsonTranslator;
        }

        public MarvelApiCharacterResponse GetCharacterByName(string name)
        {
            var request = _marvelRequestBuilder.Build("/v1/public/characters", Method.GET);
            //add base url
            var response = _restClient.Execute(request);
            var marvelCharacterResponse = _jsonTranslator.Deserialize<MarvelApiCharacterResponse>(response.Content);
            return marvelCharacterResponse;
        }
    }
}
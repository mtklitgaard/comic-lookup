using System;
using System.Linq.Expressions;
using ComicLookup.Domain;
using ComicLookup.Domain.Marvel;
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
        private readonly IMarvelKeyRepository _marvelKeyRepository;

        public MarvelApiAdapter(IMarvelRequestBuilder marvelRequestBuilder, IRestClient restClient, IJsonTranslator jsonTranslator, IMarvelKeyRepository marvelKeyRepository)
        {
            _marvelRequestBuilder = marvelRequestBuilder;
            _restClient = restClient;
            _jsonTranslator = jsonTranslator;
            _marvelKeyRepository = marvelKeyRepository;
        }

        public MarvelApiCharacterResponse GetCharacterByName(string name)
        {
            var request = _marvelRequestBuilder.Build("/v1/public/characters", Method.GET, "name", name);
            _restClient.BaseUrl = _marvelKeyRepository.MarvelBaseUrl;
            var response = _restClient.Execute(request);
            var marvelCharacterResponse = _jsonTranslator.Deserialize<MarvelApiCharacterResponse>(response.Content);
            return marvelCharacterResponse;
        }
    }
}
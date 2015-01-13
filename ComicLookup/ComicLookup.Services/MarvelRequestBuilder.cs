using ComicLookup.Services.Interfaces;
using RestSharp;

namespace ComicLookup.Services
{
    public class MarvelRequestBuilder : IMarvelRequestBuilder
    {
        private readonly IMarvelKeyRepository _marvelKeyRepository;

        public MarvelRequestBuilder(IMarvelKeyRepository marvelKeyRepository)
        {
            _marvelKeyRepository = marvelKeyRepository;
        }

        public RestRequest Build(string characterUrl, Method method, string searchName, string searchTerm)
        {
            var request = new RestRequest
            {
                Method = method,
                Resource = characterUrl
            };

            request.AddParameter("apikey", _marvelKeyRepository.ApiKey, ParameterType.QueryString);
            request.AddParameter("ts", _marvelKeyRepository.TimeStamp, ParameterType.QueryString);
            request.AddParameter("hash", _marvelKeyRepository.Hash(), ParameterType.QueryString);
            request.AddParameter(searchName, searchTerm, ParameterType.QueryString);

            return request;
        }
    }
}
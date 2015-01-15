using System;
using ComicLookup.Services.Interfaces;
using RestSharp;

namespace ComicLookup.Services
{
    public class MarvelRequestBuilder : IMarvelRequestBuilder
    {
        private readonly IMarvelKeyRepository _marvelKeyRepository;
        private readonly IDateTimeWrapper _dateTimeWrapper;

        public MarvelRequestBuilder(IMarvelKeyRepository marvelKeyRepository, IDateTimeWrapper dateTimeWrapper)
        {
            _marvelKeyRepository = marvelKeyRepository;
            _dateTimeWrapper = dateTimeWrapper;
        }

        public RestRequest Build(string characterUrl, Method method, string searchName, string searchTerm)
        {
            var request = new RestRequest
            {
                Method = method,
                Resource = characterUrl
            };

            var timeStamp = _dateTimeWrapper.GetDateString();
            request.AddParameter("apikey", _marvelKeyRepository.ApiKey, ParameterType.QueryString);
            request.AddParameter("ts", timeStamp, ParameterType.QueryString);
            request.AddParameter("hash", _marvelKeyRepository.Hash(timeStamp), ParameterType.QueryString);
            request.AddParameter(searchName, searchTerm, ParameterType.QueryString);

            return request;
        }
    }
}
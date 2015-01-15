using System;
using ComicLookup.Domain;
using ComicLookup.Domain.Marvel;
using ComicLookup.Services.Adapters;
using ComicLookup.Services.Interfaces;
using Moq;
using NUnit.Framework;
using RestSharp;

namespace ComicLookup.Services.Tests
{
    public class MarvelApiAdapterTests
    {
        private Mock<IMarvelRequestBuilder> _marvelRequestBuilder;
        private MarvelApiAdapter _classUnderTest;
        private Mock<IRestClient> _restClient;
        private Mock<IJsonTranslator> _jsonTranslator;
        private Mock<IMarvelKeyRepository> _marvelKeyRepository;

        [SetUp]
        public void SetUp()
        {
            _marvelRequestBuilder = new Mock<IMarvelRequestBuilder>();
            _restClient = new Mock<IRestClient>();
            _jsonTranslator = new Mock<IJsonTranslator>();
            _marvelKeyRepository = new Mock<IMarvelKeyRepository>();
            _classUnderTest = new MarvelApiAdapter(_marvelRequestBuilder.Object, _restClient.Object, _jsonTranslator.Object, _marvelKeyRepository.Object);
        }

        public class GetCharacterByName : MarvelApiAdapterTests
        {
            [Test]
            public void CallsMarvelRequestBuildAndRestExecute_WithTheResultFromMarvelRequestBuilder()
            {
                const string characterUrl = "/v1/public/characters";
                const string characterName = "Hulk";

                var restRequest = new RestRequest();

                _marvelRequestBuilder
                    .Setup(x => x.Build(characterUrl, Method.GET, "name", characterName))
                    .Returns(restRequest);

                _restClient
                    .Setup(x => x.Execute(restRequest))
                    .Returns(new RestResponse());

                _classUnderTest.GetCharacterByName(characterName);

                _marvelRequestBuilder
                    .Verify(x => x.Build(characterUrl, Method.GET, "name", characterName));

                _restClient
                    .Verify(x => x.Execute(restRequest));
            }
            
            [Test]
            public void CallsJSONTranslatorWithTheResponseFromRestExecute_WhenResponseIsNotNull()
            {
                const string characterUrl = "/v1/public/characters";
                const string characterName = "Hulk";

                var restRequest = new RestRequest();
                var restResponse = new RestResponse();
                var expected = new MarvelApiCharacterResponse();

                _marvelRequestBuilder
                    .Setup(x => x.Build(characterUrl, Method.GET, "name", characterName))
                    .Returns(restRequest);

                _restClient
                    .Setup(x => x.Execute(restRequest))
                    .Returns(restResponse);

                _jsonTranslator
                    .Setup(x => x.Deserialize<MarvelApiCharacterResponse>(restResponse.Content))
                    .Returns(expected);

                var actual = _classUnderTest.GetCharacterByName(characterName);

                _marvelRequestBuilder
                    .Verify(x => x.Build(characterUrl, Method.GET, "name", characterName));

                _restClient
                    .Verify(x => x.Execute(restRequest));

                _jsonTranslator
                    .Verify(x => x.Deserialize<MarvelApiCharacterResponse>(restResponse.Content));

                Assert.That(actual, Is.SameAs(expected));
            }

            [Test]
            public void CallsMarvelKeyRepository_AndSetsBaseUrlOnRestClient()
            {
                const string characterUrl = "/v1/public/characters";
                const string characterName = "Hulk";
                var expected = new Uri("http://here");
                var restRequest = new RestRequest();
                var restResponse = new RestResponse();
                var marvelApiCharacterResponse = new MarvelApiCharacterResponse();

                _marvelKeyRepository
                    .Setup(x => x.MarvelBaseUrl)
                    .Returns(expected);

                _marvelRequestBuilder
                  .Setup(x => x.Build(characterUrl, Method.GET, "name", characterName))
                  .Returns(restRequest);

               _restClient
                    .Setup(x => x.Execute(restRequest))
                    .Returns(restResponse);

                _jsonTranslator
                    .Setup(x => x.Deserialize<MarvelApiCharacterResponse>(restResponse.Content))
                    .Returns(marvelApiCharacterResponse);

                _classUnderTest.GetCharacterByName(characterName);

                _marvelKeyRepository
                    .Verify(x => x.MarvelBaseUrl);

                _restClient
                    .VerifySet(x => x.BaseUrl = expected);
            }

        }
    }
}

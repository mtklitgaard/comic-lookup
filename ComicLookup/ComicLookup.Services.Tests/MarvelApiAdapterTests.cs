using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComicLookup.Domain;
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

        [SetUp]
        public void SetUp()
        {
            _marvelRequestBuilder = new Mock<IMarvelRequestBuilder>();
            _restClient = new Mock<IRestClient>();
            _jsonTranslator = new Mock<IJsonTranslator>();
            _classUnderTest = new MarvelApiAdapter(_marvelRequestBuilder.Object, _restClient.Object, _jsonTranslator.Object);
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
                    .Setup(x => x.Build(characterUrl, Method.GET))
                    .Returns(restRequest);

                _restClient
                    .Setup(x => x.Execute(restRequest))
                    .Returns(new RestResponse());

                _classUnderTest.GetCharacterByName(characterName);

                _marvelRequestBuilder
                    .Verify(x => x.Build(characterUrl, Method.GET));

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
                    .Setup(x => x.Build(characterUrl, Method.GET))
                    .Returns(restRequest);

                _restClient
                    .Setup(x => x.Execute(restRequest))
                    .Returns(restResponse);

                _jsonTranslator
                    .Setup(x => x.Deserialize<MarvelApiCharacterResponse>(restResponse.Content))
                    .Returns(expected);

                var actual = _classUnderTest.GetCharacterByName(characterName);

                _marvelRequestBuilder
                    .Verify(x => x.Build(characterUrl, Method.GET));

                _restClient
                    .Verify(x => x.Execute(restRequest));

                _jsonTranslator
                    .Verify(x => x.Deserialize<MarvelApiCharacterResponse>(restResponse.Content));

                Assert.That(actual, Is.SameAs(expected));
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        [SetUp]
        public void SetUp()
        {
            _marvelRequestBuilder = new Mock<IMarvelRequestBuilder>();
            _classUnderTest = new MarvelApiAdapter(_marvelRequestBuilder.Object);
        }

        public class GetCharacterByName : MarvelApiAdapterTests
        {
            [Test]
            public void CallsMarvelRequestBuilder_WithCharacterUrlAndGetMethod()
            {
                const string characterUrl = "/v1/public/characters";
                const string characterName = "Hulk";

                _marvelRequestBuilder
                    .Setup(x => x.Build(characterUrl, Method.GET))
                    .Returns(new RestRequest());

                _classUnderTest.GetCharacterByName(characterName);

                _marvelRequestBuilder
                    .Verify(x => x.Build(characterUrl, Method.GET));
            }
        }
    }
}

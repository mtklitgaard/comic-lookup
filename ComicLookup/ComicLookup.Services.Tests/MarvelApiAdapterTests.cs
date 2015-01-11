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
        private Mock<IRestRequestBuilder> _restRequestBuilder;
        private MarvelApiAdapter _classUnderTest;

        [SetUp]
        public void SetUp()
        {
            _restRequestBuilder = new Mock<IRestRequestBuilder>();
            _classUnderTest = new MarvelApiAdapter(_restRequestBuilder.Object);
        }
        
        public class GetCharacterByName : MarvelApiAdapterTests
        {
            [Test]
            public void CallsRequestBuilder_WithCharacterUrlAndGetMethod()
            {
                const string characterUrl = "/v1/public/characters";
                const string characterName = "Hulk";

                _restRequestBuilder
                    .Setup(x => x.Build(characterUrl, Method.GET))
                    .Returns(new RestRequest());

                _classUnderTest.GetCharacterByName(characterName);

                _restRequestBuilder
                    .Verify(x => x.Build(characterUrl, Method.GET));
            }

        }
    }
}

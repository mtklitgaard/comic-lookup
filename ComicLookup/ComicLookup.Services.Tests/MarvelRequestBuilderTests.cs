﻿using System;
using System.Linq;
using ComicLookup.Services.Interfaces;
using Moq;
using NUnit.Framework;
using RestSharp;

namespace ComicLookup.Services.Tests
{
    public class MarvelRequestBuilderTests
    {
        private MarvelRequestBuilder _classUnderTest;
        private Mock<IMarvelKeyRepository> _marvelKeyRepository;
        private Mock<IDateTimeWrapper> _dateTimeWrapper;

        [SetUp]
        public void SetUp()
        {
            _marvelKeyRepository = new Mock<IMarvelKeyRepository>();
            _dateTimeWrapper = new Mock<IDateTimeWrapper>();
            _classUnderTest = new MarvelRequestBuilder(_marvelKeyRepository.Object, _dateTimeWrapper.Object);
        }

        public class Build : MarvelRequestBuilderTests
        {
            [TestCase(Method.GET)]
            [TestCase(Method.POST)]
            public void ReturnsRequest_WithCorrectMethod(Method expected)
            {
                var actual = _classUnderTest.Build("test", expected, "name", "hulk");
                Assert.That(actual.Method, Is.EqualTo(expected));
            }

            [Test]
            public void ReturnsRequest_WithCorrectResourceUrl()
            {
                var expected = "test";
                var actual = _classUnderTest.Build(expected, Method.GET, "name", "hulk");
                Assert.That(actual.Resource, Is.EqualTo(expected));
            }

            [Test]
            public void CallsMarvelKeyRepositoryForApiKey_AndAddsApiKeyToQueryString()
            {
                var apiKey = "test";

                var expected = new Parameter();
                expected.Name = "apikey";
                expected.Type = ParameterType.QueryString;
                expected.Value = apiKey;

                _marvelKeyRepository
                    .Setup(x => x.ApiKey)
                    .Returns(apiKey);

                var actual = _classUnderTest.Build("url", Method.GET, "name", "hulk");

                _marvelKeyRepository
                    .Verify(x => x.ApiKey);

                Assert.That(
                    actual.Parameters.Any(
                        x => x.Name == expected.Name && x.Type == expected.Type && x.Value == expected.Value), Is.True);
            }

            [Test]
            public void CallsDateTimeWrapperToGetTimeStamp_AndAddsTimeStampToQueryString()
            {
                var timeStamp = "test";

                var expected = new Parameter();
                expected.Name = "ts";
                expected.Type = ParameterType.QueryString;
                expected.Value = timeStamp;

                _dateTimeWrapper
                    .Setup(x => x.GetDateString())
                    .Returns(timeStamp);

                var actual = _classUnderTest.Build("url", Method.GET, "name", "hulk");

                _dateTimeWrapper
                    .Verify(x => x.GetDateString());

                Assert.That(
                    actual.Parameters.Any(
                        x => x.Name == expected.Name && x.Type == expected.Type && x.Value == expected.Value), Is.True);
            }

            [Test]
            public void CallsMarvelKeyRepositoryForHashKey_AndAddsHashKeyToQueryString()
            {
                var hash = "test";
                var timeStamp = "test";

                var expected = new Parameter();
                expected.Name = "hash";
                expected.Type = ParameterType.QueryString;
                expected.Value = hash;

                _dateTimeWrapper
                   .Setup(x => x.GetDateString())
                   .Returns(timeStamp);

                _marvelKeyRepository
                    .Setup(x => x.Hash(timeStamp))
                    .Returns(hash);

                var actual = _classUnderTest.Build("url", Method.GET, "name", "hulk");

                _marvelKeyRepository
                    .Verify(x => x.Hash(timeStamp));

                Assert.That(
                    actual.Parameters.Any(
                        x => x.Name == expected.Name && x.Type == expected.Type && x.Value == expected.Value), Is.True);
            }  
            
            [Test]
            public void AddsSearchNameAndSearchTermToQueryString()
            {
                var searchTerm = "hullk";
                var searchName = "name";

                var expected = new Parameter();
                expected.Name = searchName;
                expected.Type = ParameterType.QueryString;
                expected.Value = searchTerm;
                
                var actual = _classUnderTest.Build("url", Method.GET, searchName, searchTerm);
                
                Assert.That(
                    actual.Parameters.Any(
                        x => x.Name == expected.Name && x.Type == expected.Type && x.Value == expected.Value), Is.True);
            }
        }
    }
}

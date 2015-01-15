using ComicLookup.Domain.Marvel;
using ComicLookup.Services.Adapters.Interfaces;
using ComicLookup.Services.Builders;
using ComicLookup.Services.Interfaces;
using Moq;
using NUnit.Framework;

namespace ComicLookup.Services.Tests
{
    public class CharacterBuilderTests
    {
        private CharacterBuilder _classUnderTest;
        private Mock<IMarvelApiAdapter> _marvelApiAdapter;
        private Mock<ICommonCharacterTranslator> _commonCharacterTranslator;

        [SetUp]
        public void Setup()
        {
            _marvelApiAdapter = new Mock<IMarvelApiAdapter>();
            _commonCharacterTranslator = new Mock<ICommonCharacterTranslator>();
            _classUnderTest = new CharacterBuilder(_marvelApiAdapter.Object);
        }

        public class GetCharacterByName : CharacterBuilderTests
        {
            [Test]
            public void CallsMarvelRequestBuilderGetCharactersByName()
            {
                var name = "Hulk";
                var expected = new MarvelApiCharacterResponse();
                _marvelApiAdapter
                    .Setup(x => x.GetCharacterByName(name))
                    .Returns(expected);

                var actual = _classUnderTest.GetCharacterByName(name);

                _marvelApiAdapter
                    .Verify(x => x.GetCharacterByName(name));

                Assert.That(actual, Is.SameAs(expected));
            }
        }
    }
}

using ComicLookup.Domain;
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
            _classUnderTest = new CharacterBuilder(_marvelApiAdapter.Object, _commonCharacterTranslator.Object);
        }

        public class GetCharacterByName : CharacterBuilderTests
        {
            [Test]
            public void CallsMarvelRequestBuilderGetCharactersByName()
            {
                var name = "Hulk";
                _marvelApiAdapter
                    .Setup(x => x.GetCharacterByName(name))
                    .Returns(new MarvelApiCharacterResponse());

                _classUnderTest.GetCharacterByName(name);

                _marvelApiAdapter
                    .Verify(x => x.GetCharacterByName(name));
            }

            [Test]
            public void CallsCommonCharacterTranslatorTranslate_AndReturnsCharacterFromCommonCharacterTranslator()
            {
                var name = "Hulk";
                var expected = new Character();

                _commonCharacterTranslator
                    .Setup(x => x.Translate(It.IsAny<MarvelApiCharacterResponse>()))
                    .Returns(expected);

                var actual = _classUnderTest.GetCharacterByName(name);

                _commonCharacterTranslator
                    .Verify(x => x.Translate(It.IsAny<MarvelApiCharacterResponse>()));

                Assert.That(actual, Is.SameAs(expected));
            }
        }
    }
}

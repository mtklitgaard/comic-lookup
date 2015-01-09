using ComicLookup.Domain;
using ComicLookup.Services.Adapters.Interfaces;
using ComicLookup.Services.Builders;
using Moq;
using NUnit.Framework;

namespace ComicLookup.Services.Tests
{
    public class CharacterBuilderTests
    {
        private CharacterBuilder _classUnderTest;
        private Mock<IMarvelApiAdapter> _marvelApiAdapter;
        [SetUp]
        public void Setup()
        {
             _marvelApiAdapter = new Mock<IMarvelApiAdapter>();
            _classUnderTest = new CharacterBuilder(_marvelApiAdapter.Object);
        }

        [TestFixture]
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
        }
    }
}

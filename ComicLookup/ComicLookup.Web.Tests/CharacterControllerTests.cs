using ComicLookup.Controllers;
using ComicLookup.Domain;
using ComicLookup.Domain.Marvel;
using ComicLookup.Services.Builders.Interfaces;
using Moq;
using NUnit.Framework;

namespace ComicLookup.Web.Tests
{
    public class CharacterControllerTests
    {
        private CharacterController _classUnderTest;
        private Mock<ICharacterBuilder> _characterBuilder;
        private Mock<ICharacterComicsBuilder> _characterComicsBuilder;

        [SetUp]
        public void Setup()
        {
            var mockRepository = new MockRepository(MockBehavior.Loose);

            _characterBuilder = mockRepository.Create<ICharacterBuilder>();
            _characterComicsBuilder = mockRepository.Create<ICharacterComicsBuilder>();
            _classUnderTest = new CharacterController(_characterBuilder.Object, _characterComicsBuilder.Object);
        }

        [TestFixture]
        public class Name : CharacterControllerTests
        {
            [Test]
            public void ReturnsResponseWithCharacter_WhenNameIsNotNullOrWhiteSpace()
            {
                var name = "Hulk";
                var actual = _classUnderTest.Name(name);
                Assert.That(actual, Is.TypeOf(typeof(ResponseEnvelope<MarvelApiCharacterResponse>)));
            } 
            
            [Test]
            public void ReturnsResponseWithNullCharacter_WhenNameIsNull()
            {
                var actual = _classUnderTest.Name(null);
                Assert.That(actual, Is.TypeOf(typeof(ResponseEnvelope<MarvelApiCharacterResponse>)));
                Assert.That(actual.Result, Is.Null);
            } 
            
            [Test]
            public void ReturnsResponseWithNullCharacter_WhenNameIsEmpty()
            {
                var name = string.Empty;
                var actual = _classUnderTest.Name(name);
                Assert.That(actual, Is.TypeOf(typeof(ResponseEnvelope<MarvelApiCharacterResponse>)));
                Assert.That(actual.Result, Is.Null);
            } 
            
            [Test]
            public void ReturnsResponseWithNullCharacter_WhenNameIsWhiteSpace()
            {
                var name = "    ";
                var actual = _classUnderTest.Name(name);
                Assert.That(actual, Is.TypeOf(typeof(ResponseEnvelope<MarvelApiCharacterResponse>)));
                Assert.That(actual.Result, Is.Null);
            }

            [Test]
            public void CallsCharacterBuilderGetCharacterByNameAndReturnsCharacter_WhenCharacterNameIsNotNullOrEmpty()
            {
                var name = "Hulk";
                var expected = new MarvelApiCharacterResponse();
                _characterBuilder
                    .Setup(x => x.GetCharacterByName(name))
                    .Returns(expected);

                var actual = _classUnderTest.Name(name);

                _characterBuilder
                    .Verify(x => x.GetCharacterByName(name));

                Assert.That(actual.Result, Is.SameAs(expected));
            }

        }

        [TestFixture]
        public class Comics : CharacterControllerTests
        {
            [Test]
            public void ReturnsMarvelApiCharacterComicsResponse()
            {
                var characterId = 123;
                var actual = _classUnderTest.Comics(characterId);
                Assert.That(actual, Is.TypeOf(typeof(ResponseEnvelope<MarvelApiCharacterComicsResponse>)));
            }
            
            [Test]
            public void CallsCharacterComicsBuilderAndReturnsMarvelApiCharacterComicsResponse()
            {
                var characterId = 123;
                var expected = new MarvelApiCharacterComicsResponse();

                _characterComicsBuilder
                    .Setup(x => x.GetComics(characterId))
                    .Returns(expected);

                var actual = _classUnderTest.Comics(characterId);

                _characterComicsBuilder
                    .Verify(x => x.GetComics(characterId));

                Assert.That(actual.Result, Is.SameAs(expected));
            }
        }
    }
}

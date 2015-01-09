using ComicLookup.Controllers;
using ComicLookup.Domain;
using ComicLookup.Services.Builders.Interfaces;
using Moq;
using NUnit.Framework;

namespace ComicLookup.Web.Tests
{
    public class CharacterControllerTests
    {
        private CharacterController _classUnderTest;
        private Mock<ICharacterBuilder> _characterBuilder;

        [SetUp]
        public void Setup()
        {
            var mockRepository = new MockRepository(MockBehavior.Loose);

            _characterBuilder = mockRepository.Create<ICharacterBuilder>();
            _classUnderTest = new CharacterController(_characterBuilder.Object);
        }

        public class Name : CharacterControllerTests
        {
            [Test]
            public void ReturnsResponseWithCharacter_WhenNameIsNotNullOrWhiteSpace()
            {
                var name = "Hulk";
                var actual = _classUnderTest.Name(name);
                Assert.That(actual, Is.TypeOf(typeof(ResponseEnvelope<Character>)));
            } 
            
            [Test]
            public void ReturnsResponseWithNullCharacter_WhenNameIsNull()
            {
                var actual = _classUnderTest.Name(null);
                Assert.That(actual, Is.TypeOf(typeof(ResponseEnvelope<Character>)));
                Assert.That(actual.Result, Is.Null);
            } 
            
            [Test]
            public void ReturnsResponseWithNullCharacter_WhenNameIsEmpty()
            {
                var name = string.Empty;
                var actual = _classUnderTest.Name(name);
                Assert.That(actual, Is.TypeOf(typeof(ResponseEnvelope<Character>)));
                Assert.That(actual.Result, Is.Null);
            } 
            
            [Test]
            public void ReturnsResponseWithNullCharacter_WhenNameIsWhiteSpace()
            {
                var name = "    ";
                var actual = _classUnderTest.Name(name);
                Assert.That(actual, Is.TypeOf(typeof(ResponseEnvelope<Character>)));
                Assert.That(actual.Result, Is.Null);
            }

            [Test]
            public void CallsCharacterBuilderGetCharacterByNameAndReturnsCharacter_WhenCharacterNameIsNotNullOrEmpty()
            {
                var name = "Hulk";
                var expected = new Character();
                _characterBuilder
                    .Setup(x => x.GetCharacterByName(name))
                    .Returns(expected);

                var actual = _classUnderTest.Name(name);

                _characterBuilder
                    .Verify(x => x.GetCharacterByName(name));

                Assert.That(actual.Result, Is.SameAs(expected));
            }

        }
    }
}

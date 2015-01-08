using ComicLookup.Controllers;
using ComicLookup.Domain;
using NUnit.Framework;

namespace ComicLookup.Web.Tests
{
    public class CharacterControllerTests
    {
        private CharacterController _classUnderTest;

        [SetUp]
        public void Setup()
        {
            _classUnderTest = new CharacterController();
        }

        public class Name : CharacterControllerTests
        {
            [Test]
            public void ReturnsResponseWithCharacter_WhenNameIsNotNullOrWhiteSpace()
            {
                var name = "Hulk";
                var actual = _classUnderTest.Name(name);
                Assert.That(actual, Is.TypeOf(typeof(ResponseEnvelope<Character>)));
                Assert.That(actual.Result, Is.TypeOf(typeof(Character)));
            }
        }
    }
}

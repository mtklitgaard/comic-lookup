using System.Collections;
using ComicLookup.Domain;
using ComicLookup.Domain.Marvel;
using NUnit.Framework;

namespace ComicLookup.Services.Tests
{
    public class CommonCharacterTranslatorTests
    {
        private CommonCharacterTranslator _classUnderTest;

        [SetUp]
        public void SetUp()
        {
            _classUnderTest = new CommonCharacterTranslator();
        }

        public class Translate : CommonCharacterTranslatorTests
        {
            [Test]
            public void TranslatesMarvelResponseCharacter_ToCommonCharacterObject()
            {
                var marvelCharacterResponse = new MarvelApiCharacterResponse();
                var expected = new Character();

                var actual = _classUnderTest.Translate(marvelCharacterResponse);

                Assert.That(actual, Is.EqualTo(expected));
            }

        }
    }
}

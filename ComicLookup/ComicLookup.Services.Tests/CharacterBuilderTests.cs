using ComicLookup.Services.Builders;
using NUnit.Framework;

namespace ComicLookup.Services.Tests
{
    public class CharacterBuilderTests
    {
        private CharacterBuilder _classUnderTest;

        [SetUp]
        public void Setup()
        {
            _classUnderTest = new CharacterBuilder();
        }

        [TestFixture]
        public class GetCharacterByName : CharacterBuilderTests
        {
           

        }
    }
}

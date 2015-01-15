using NUnit.Framework;

namespace ComicLookup.Services.Tests
{
    public class MarvelKeyRepositoryTests
    {
        private MarvelKeyRepository _classUnderTest;
        private string _timeStamp;

        [SetUp]
        public void SetUp()
        {
            _timeStamp = "timestamp";
            _classUnderTest = new MarvelKeyRepository(_timeStamp);
        }

        public class Hash : MarvelKeyRepositoryTests
        {
            [Test]
            public void ReturnsCorrectHash()
            {
                var expected = "EXPECTEDHASH";

                var actual = _classUnderTest.Hash();
                Assert.That(actual, Is.EqualTo(expected));
            }

        }
    }
}

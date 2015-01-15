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
                var expected = "01bb31985695fad8fd0d8ce20c9e8d47";

                var actual = _classUnderTest.Hash();
                Assert.That(actual, Is.EqualTo(expected));
            }

        }
    }
}

using Hejkal;

namespace CoreTest
{
	[TestFixture]
	public class SongDataTests
	{
		SongData sut;

		[SetUp]
		public void Setup()
		{
			sut = new SongData("number", "title", "author", "source");
		}

		[Test]
		public void TestGetters()
		{
			Assert.AreEqual("number", sut.GetNumber());
			Assert.AreEqual("title", sut.GetTitle());
			Assert.AreEqual("author", sut.GetAuthor());
			Assert.AreEqual("source", sut.GetSource());
		}
	}
}
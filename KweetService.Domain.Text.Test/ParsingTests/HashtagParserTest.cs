using KweetService.Domain.Text.Parsers.EntityParsers;
using NUnit.Framework;

namespace KweetService.Domain.Text.Test.ParsingTests
{
    [TestFixture]
    public class HashtagParserTest
    {
        private readonly HashtagParser parser = new HashtagParser();
        
        [Test]
        public void Given_A_Kweet_Without_Hashtags__When_Calling_HashtagParser__Then_Return_Empty_List()
        {
            // Arrange
            var kweetText = "Hello world";
            
            // Act
            var hashtags = HashtagParser.Parse(kweetText);
            
            // Assert
            Assert.IsEmpty(hashtags);
        }

        [Test]
        public void Given_An_Empty_Kweet__When_Calling_HashtagParser__Then_Return_Empty_List()
        {
            // Arrange
            var kweetText = "";
            
            // Act
            var hashtags = HashtagParser.Parse(kweetText);
            
            // Assert
            Assert.IsEmpty(hashtags);
        }

        [Test]
        public void Given_A_Null_Value__When_Calling_HashtagParser__Then_Return_Empty_List()
        {
            // Act
            var hashtags = HashtagParser.Parse(null);
            
            // Assert
            Assert.IsEmpty(hashtags);
        }

        [Test]
        public void Given_A_Kweet_With_Only_Whitespaces__When_Calling_HashtagParser__Then_Return_Empty_List()
        {
            // Arrange
            var kweetText = " ";
            
            // Act
            var hashtags = HashtagParser.Parse(kweetText);
            
            // Assert
            Assert.IsEmpty(hashtags);
        }

        [TestCase("Hello #World this is a #UnitTest", 2)]
        [TestCase("Hello #World, this is a #UnitTest!", 2)]
        [TestCase("Hello #World... This is a #UnitTest!!", 2)]
        [TestCase("Hello #World..., This is a #UnitTest?", 2)]
        public void Given_A_Kweet_With_Valid_Hashtags__When_Calling_HashtagParser__Then_Contains_Expected_Amount_Of_Hashtags(string kweet, int expectedSize)
        {
            // Act
            var hashtags = HashtagParser.Parse(kweet);

            // Assert
            Assert.AreEqual(expectedSize, hashtags.Count);
        }

        [TestCase("Hello #123")]
        [TestCase("Hello #1HashTag")]
        [TestCase("Hello #?")]
        [TestCase("Hello #.")]
        [TestCase("Hello #,")]
        [TestCase("Hello #")]
        [TestCase("Hello #@$")]
        [TestCase("Hello ###")]
        public void Given_A_Kweet_With_An_Invalid_Hashtag__When_Calling_HashtagParser__Then_Contains_No_Hastags(string kweet)
        {
            // Act
            var hashtags = HashtagParser.Parse(kweet);

            // Assert
            Assert.AreEqual(0, hashtags.Count); 
        }
    }
}

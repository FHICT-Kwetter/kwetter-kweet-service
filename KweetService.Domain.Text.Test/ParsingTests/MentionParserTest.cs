using KweetService.Domain.Text.Parsers.EntityParsers;
using NUnit.Framework;

namespace KweetService.Domain.Text.Test.ParsingTests
{
    [TestFixture]
    public class MentionParserTest
    {
        private readonly MentionParser parser = new MentionParser();
        
        [Test]
        public void Given_A_Kweet_Without_Mentions__When_Calling_MentionParser__Then_Return_Empty_List()
        {
            // Arrange
            var kweetText = "Hello world";
            
            // Act
            var mentions = MentionParser.Parse(kweetText);
            
            // Assert
            Assert.IsEmpty(mentions);
        }

        [Test]
        public void Given_An_Empty_Kweet__When_Calling_MentionParser__Then_Return_Empty_List()
        {
            // Arrange
            var kweetText = "";
            
            // Act
            var mentions = MentionParser.Parse(kweetText);
            
            // Assert
            Assert.IsEmpty(mentions);
        }

        [Test]
        public void Given_A_Null_Value__When_Calling_MentionParser__Then_Return_Empty_List()
        {
            // Act
            var mentions = MentionParser.Parse(null);
            
            // Assert
            Assert.IsEmpty(mentions);
        }

        [Test]
        public void Given_A_Kweet_With_Only_Whitespaces__When_Calling_MentionParser__Then_Return_Empty_List()
        {
            // Arrange
            var kweetText = " ";
            
            // Act
            var mentions = MentionParser.Parse(kweetText);
            
            // Assert
            Assert.IsEmpty(mentions);
        }

        [TestCase("Hello @User this is a UnitTest", 1)]
        [TestCase("Hello @User, this is a UnitTest", 1)]
        [TestCase("Hello @User... this is a UnitTest", 1)]
        [TestCase("Hello @User! This is a UnitTest", 1)]
        public void Given_A_Kweet_With_A_Valid_Mention__When_Calling_MentionParser__Then_Contains_Expected_Amount_Of_Mentions(string kweet, int expectedSize)
        {
            // Act
            var mentions = MentionParser.Parse(kweet);
        
            // Assert
            Assert.AreEqual(expectedSize, mentions.Count);
        }
        
        [TestCase("Hello @@")]
        [TestCase("Hello @123")]
        [TestCase("Hello @U?er")]
        [TestCase("Hello @..")]
        public void Given_A_Kweet_With_An_Invalid_Mention__When_Calling_MentionParser__Then_Contains_No_Mentions(string kweet)
        {
            // Act
            var mentions = MentionParser.Parse(kweet);
        
            // Assert
            Assert.AreEqual(0, mentions.Count); 
        }
    }
}
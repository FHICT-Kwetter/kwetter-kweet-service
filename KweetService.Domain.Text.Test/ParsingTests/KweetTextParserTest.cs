using System.Linq;
using KweetService.Domain.Text.Exceptions;
using KweetService.Domain.Text.Parsers;
using NUnit.Framework;

namespace KweetService.Domain.Text.Test.ParsingTests
{
    public class KweetTextParserTest
    {
        [Test]
        public void Given_A_Kweet_With_Only_Text__When_Calling_KweetTextParser__Then_Returns_Correct_KweetText()
        {
            // Arrange
            var content = "Hello, this is a test kweet";
            
            // Act
            var kweetText = KweetTextParser.Parse(content);
            
            // Assert
            Assert.AreEqual(content, kweetText.Content);
            Assert.AreEqual(content.Length, kweetText.Length);
            Assert.IsEmpty(kweetText.Hashtags);
            Assert.IsEmpty(kweetText.Mentions);
        }

        [Test]
        public void Given_A_Kweet_With_A_Mention__When_Calling_KweetTextParser__Then_Returns_Correct_KweetText()
        {
            // Arrange
            var content = "Hello @username, this is a test kweet";
            
            // Act
            var kweetText = KweetTextParser.Parse(content);
            
            // Assert
            Assert.AreEqual(content, kweetText.Content);
            Assert.AreEqual(content.Length, kweetText.Length);
            Assert.IsEmpty(kweetText.Hashtags);
            Assert.IsNotEmpty(kweetText.Mentions);
            Assert.AreEqual("username", kweetText.Mentions.First().Username);
            Assert.AreEqual("@username", kweetText.Mentions.First().Value);
            Assert.AreEqual(6, kweetText.Mentions.First().Start);
            Assert.AreEqual(14, kweetText.Mentions.First().End);
        }

        [Test]
        public void Given_A_Kweet_With_A_Hashtag__When_Calling_KweetTextParser__Then_Returns_Correct_KweetText()
        {
            // Arrange
            var content = "Hello #username, this is a test kweet";
            
            // Act
            var kweetText = KweetTextParser.Parse(content);
            
            // Assert
            Assert.AreEqual(content, kweetText.Content);
            Assert.AreEqual(content.Length, kweetText.Length);
            Assert.IsEmpty(kweetText.Mentions);
            Assert.IsNotEmpty(kweetText.Hashtags);
            Assert.AreEqual("username", kweetText.Hashtags.First().Topic);
            Assert.AreEqual("#username", kweetText.Hashtags.First().Value);
            Assert.AreEqual(6, kweetText.Hashtags.First().Start);
            Assert.AreEqual(14, kweetText.Hashtags.First().End);
        }

        [Test]
        public void Given_A_Kweet_With_A_Hashtag_And_Mention__When_Calling_KweetTextParser__Then_Returns_Correct_KweetText()
        {
            // Arrange
            var content = "Hello @username, this is a #test kweet!";

            // Act
            var kweetText = KweetTextParser.Parse(content);
            
            // Assert
            Assert.AreEqual(content, kweetText.Content);
            Assert.AreEqual(content.Length, kweetText.Length);
            Assert.IsNotEmpty(kweetText.Mentions);
            Assert.AreEqual("username", kweetText.Mentions.First().Username);
            Assert.AreEqual("@username", kweetText.Mentions.First().Value);
            Assert.AreEqual(6, kweetText.Mentions.First().Start);
            Assert.AreEqual(14, kweetText.Mentions.First().End);
            Assert.IsNotEmpty(kweetText.Hashtags);
            Assert.AreEqual("test", kweetText.Hashtags.First().Topic);
            Assert.AreEqual("#test", kweetText.Hashtags.First().Value);
            Assert.AreEqual(27, kweetText.Hashtags.First().Start);
            Assert.AreEqual(31, kweetText.Hashtags.First().End);
        }

        [Test]
        public void Given_A_Kweet_That_Exceeds_The_Maximum_Length__When_Calling_KweetTextParser__Then_Throws_KweetTooLongException()
        {
            // Arrange
            var content = string.Concat(Enumerable.Repeat("A", 150));
            
            // Act + Assert
            Assert.Throws<KweetTextTooLongException>(() => KweetTextParser.Parse(content));
        }
    }
}
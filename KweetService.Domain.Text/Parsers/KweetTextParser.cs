using KweetService.Domain.Text.Exceptions;
using KweetService.Domain.Text.Models;
using KweetService.Domain.Text.Parsers.EntityParsers;

namespace KweetService.Domain.Text.Parsers
{
    public class KweetTextParser
    {
        private static readonly int MAX_KWEET_LENGTH = 140;

        public static KweetText Parse(string kweetText)
        {
            if (kweetText.Length > MAX_KWEET_LENGTH)
            {
                throw new KweetTextTooLongException();
            }

            return new KweetText
            {
                Content = kweetText,
                Length = kweetText.Length,
                Hashtags = HashtagParser.Parse(kweetText),
                Mentions = MentionParser.Parse(kweetText),
            };
        }
    }
}

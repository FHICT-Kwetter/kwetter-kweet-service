// <copyright file="KweetTextParser.cs" company="Kwetter">
//     Copyright Kwetter. All rights reserved.
// </copyright>
// <author>Dirk Heijnen</author>

namespace KweetService.Domain.Text.Parsers
{
    using KweetService.Domain.Text.Entities;
    using KweetService.Domain.Text.Exceptions;
    using KweetService.Domain.Text.Models;
    using KweetService.Domain.Text.Parsers.EntityParsers;

    /// <summary>
    /// The public parser for <see cref="KweetText"/>.
    /// This is the parser which creates kweet texts and returns them.
    /// </summary>
    public class KweetTextParser
    {
        /// <summary>
        /// A constant representing the maximum kweet length.
        /// </summary>
        private static readonly int MAX_KWEET_LENGTH = 140;

        /// <summary>
        /// Parses a kweet text and finds all present hashtags, then returns them in a list.
        /// </summary>
        /// <param name="kweetText">The full kweet text.</param>
        /// <returns>The list of all <see cref="Hashtag"/> found within the kweet. If no hashtags are present an empty list is returned.</returns>
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

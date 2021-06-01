// <copyright file="HashtagParser.cs" company="Kwetter">
//     Copyright Kwetter. All rights reserved.
// </copyright>
// <author>Dirk Heijnen</author>

namespace KweetService.Domain.Text.Parsers.EntityParsers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using KweetService.Domain.Text.Entities;
    using KweetService.Domain.Text.Utils;

    /// <summary>
    /// A part of a kweet text where it contains a topic preceded by the "#" symbol.
    ///
    /// Rules for hashtags:
    ///
    ///     - Hashtags ('#') count as a 1 character.
    ///     - Hashtags are limited to the 140 characters of a kweet.
    ///     - Hashtags cannot contains spaces, when writing two words skip the space: #FirstSecond.
    ///     - Hashtags cannot start with numbers.
    ///     - Hashtags cannot contain only numerical values.
    ///     - Hashtags do not support special characters like (!, $, %, ^, *, +, .).
    ///     - Special character terminate a hashtag, ex: #WorldCup!  will be seen as #WorldCup.
    ///
    /// </summary>
    internal sealed class HashtagParser
    {
        /// <summary>
        /// The characters that indicates the start of a hashtag.
        /// </summary>
        private static char HASHTAG_CHAR = '#';

        /// <summary>
        /// The characters that are accepted to be indications of the end of a hashtag.
        /// </summary>
        private static char[] HASHTAG_TERMINATING_CHARACTERS = { ' ', '!', '?', '.', ',', };

        /// <summary>
        /// Parses a kweet text and finds all present hashtags, then returns them in a list.
        /// </summary>
        /// <param name="kweetText">The full kweet text.</param>
        /// <returns>The list of all <see cref="Hashtag"/> found within the kweet. If no hashtags are present an empty list is returned.</returns>
        public static ICollection<Hashtag> Parse(string kweetText)
        {
            // Create list to store hashtags.
            var hashTags = new List<Hashtag>();

            // Empty kweets do not contain any hashtags, text without the '#' symbol don't contain hastags either.
            if (string.IsNullOrWhiteSpace(kweetText))
            {
                return new List<Hashtag>();
            }

            // If kweets do not contain the '#' symbol, there are not hashtags to be found.
            if (!kweetText.Contains('#'))
            {
                return new List<Hashtag>();
            }

            // Make a list of all words within the kweet.
            foreach (var word in kweetText.Split(' '))
            {
                if (word.StartsWith(HASHTAG_CHAR) && IsValidHashtag(word))
                {
                    var startIndex = kweetText.IndexOf(word, StringComparison.Ordinal);
                    var hashtagText = word.TrimEnd(HASHTAG_TERMINATING_CHARACTERS.ToArray());
                    var endIndex = startIndex + hashtagText.Length - 1; // -1 because of zero-based indexing.

                    hashTags.Add(new Hashtag(startIndex, endIndex, hashtagText));
                }
            }

            return hashTags;
        }

        /// <summary>
        /// Checks if a hashtag is a valid hashtag or not.
        /// </summary>
        /// <param name="hashtag">The full hashtag, including the # symbol, untill the terminating character.</param>
        /// <returns>True if the hashtag is valid, otherwise false.</returns>
        private static bool IsValidHashtag(string hashtag)
        {
            hashtag = hashtag.TrimStart(HASHTAG_CHAR);
            hashtag = hashtag.TrimEnd(HASHTAG_TERMINATING_CHARACTERS);

            if (string.IsNullOrEmpty(hashtag) || char.IsDigit(hashtag.First()))
            {
                return false;
            }

            return Regex.IsMatch(hashtag, RegexConstants.ONLY_LETTERS_AND_NUMBERS);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using KweetService.Domain.Text.Entities;
using KweetService.Domain.Text.Utils;

namespace KweetService.Domain.Text.Parsers.EntityParsers
{
    /// <summary>
    /// A part of a kweet text where it contains a user mention preceded by the "@" symbol.
    ///
    /// Rules for mention:
    ///
    ///     - Mention symbol ('@') counts as a 1 character.
    ///     - Mentions are limited to the length of a username (minimum 4 and maximum 15 characters).
    ///     - Mentions can only contains letters and numbers.
    ///     - Certain characters can terminate a mention ('?', ',', '.', '!', ' ').
    ///
    /// </summary>
    internal sealed class MentionParser
    {
        /// <summary>
        /// The characters that indicates the start of a hashtag.
        /// </summary>
        private static readonly char MENTION_CHAR = '@';

        /// <summary>
        /// The space character.
        /// </summary>
        private static readonly char SPACE_CHAR = ' ';

        /// <summary>
        /// The minimum number of characters for a username.
        /// </summary>
        private static readonly int MIN_USERNAME_LENGTH = 4;

        /// <summary>
        /// The maximum number of characters for a username.
        /// </summary>
        private static readonly int MAX_USERNAME_LENGTH = 15;

        /// <summary>
        /// The characters that are accepted to be indications of the end of a hashtag.
        /// </summary>
        private static readonly char[] MENTION_TERMINATING_CHARACTERS = { ' ',  '!',  '?',  '.',   ',', };

        /// <summary>
        /// Parses a kweet text and finds all present mentions, then returns them in a list.
        /// </summary>
        /// <param name="kweetText">The full kweet text.</param>
        /// <returns>The list of all <see cref="Mention"/> found within the kweet. If no mentions are present an empty list is returned.</returns>
        public static ICollection<Mention> Parse(string kweetText)
        {
            // Create list to store mentions.
            var mentions = new List<Mention>();

            // Empty kweets do not contain any mentions.
            if (string.IsNullOrWhiteSpace(kweetText))
            {
                return new List<Mention>();
            }

            // If kweets do not contain the '@' symbol, there are not mentions to be found.
            if (!kweetText.Contains(MENTION_CHAR))
            {
                return new List<Mention>();
            }

            foreach (var word in kweetText.Split(SPACE_CHAR))
            {
                if (word.StartsWith(MENTION_CHAR) && IsValidMention(word))
                {
                    var startIndex = kweetText.IndexOf(word, StringComparison.Ordinal);
                    var mentionText = word.TrimEnd(MENTION_TERMINATING_CHARACTERS);
                    var endIndex = startIndex + mentionText.Length - 1; // -1 because of zero-based indexing.

                    mentions.Add(new Mention(startIndex, endIndex, mentionText));
                }
            }

            return mentions;
        }

        /// <summary>
        /// Checks if a mention is a valid mention or not.
        /// </summary>
        /// <param name="mention">The full mention, including the @ symbol, until the terminating character.</param>
        /// <returns>True if the mention is valid, otherwise false.</returns>
        private static bool IsValidMention(string mention)
        {
            mention = mention.TrimStart(MENTION_CHAR);
            mention = mention.TrimEnd(MENTION_TERMINATING_CHARACTERS);

            if (mention.Length < MIN_USERNAME_LENGTH || mention.Length > MAX_USERNAME_LENGTH)
            {
                return false;
            }

            return Regex.IsMatch(mention, RegexConstants.ONLY_LETTERS_AND_NUMBERS);
        }
    }
}

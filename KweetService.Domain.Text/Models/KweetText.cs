// <copyright file="KweetText.cs" company="Kwetter">
//     Copyright Kwetter. All rights reserved.
// </copyright>
// <author>Dirk Heijnen</author>

namespace KweetService.Domain.Text.Models
{
    using System.Collections.Generic;
    using KweetService.Domain.Text.Entities;

    /// <summary>
    /// The kweet text is an OOP model which replaces the string content of the kweet by an object with all
    /// attributes extracted from it.
    /// </summary>
    public class KweetText
    {
        /// <summary>
        /// Gets the content of the kweet.
        /// </summary>
        public string Content { get; init; }

        /// <summary>
        /// Gets the length of the content of the kweet.
        /// </summary>
        public int Length { get; init; }

        /// <summary>
        /// The list of hashtags in the kweet.
        /// </summary>
        public IEnumerable<Hashtag> Hashtags { get; init; }

        /// <summary>
        /// The list of mentions in the kweet.
        /// </summary>
        public IEnumerable<Mention> Mentions { get; init; }
    }
}

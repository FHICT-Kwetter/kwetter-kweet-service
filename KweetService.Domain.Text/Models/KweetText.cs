using System.Collections.Generic;
using KweetService.Domain.Text.Entities;

namespace KweetService.Domain.Text.Models
{
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

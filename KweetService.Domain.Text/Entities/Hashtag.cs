// <copyright file="Hashtag.cs" company="Kwetter">
//     Copyright Kwetter. All rights reserved.
// </copyright>
// <author>Dirk Heijnen</author>

namespace KweetService.Domain.Text.Entities
{
    using KweetService.Domain.Text.Entities.Base;

    /// <summary>
    /// A part of a kweet text where it contains a topic preceded by the "#" symbol.
    /// </summary>
    public class Hashtag : TextEntity
    {
        /// <summary>
        /// The topic of the hashtag.
        /// Example 1: #Hello123 -> Topic will be Hello123.
        /// Example 2: #WorldCup! -> Topic will be WorldCup.
        /// </summary>
        public string Topic { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Hashtag"/> class.
        /// </summary>
        /// <param name="start">The starting index of the hashtag in the text.</param>
        /// <param name="end">The ending index (inclusive) of the hastag topic in the text.</param>
        /// <param name="value">The full value of the hashtag, including the # symbol.</param>
        public Hashtag(int start, int end, string value) : base(start, end, value)
        {
            this.Topic = value.Remove(0, 1);
        }
    }
}

// <copyright file="KweetTextTooLongException.cs" company="Kwetter">
//     Copyright Kwetter. All rights reserved.
// </copyright>
// <author>Dirk Heijnen</author>

namespace KweetService.Domain.Text.Exceptions
{
    using KweetService.Domain.Text.Exceptions.Base;

    /// <summary>
    /// Describes the exception which is thrown when a kweet is being parsed which is too long.
    /// </summary>
    public class KweetTextTooLongException : KwetterTextException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="KweetTextTooLongException"/> class.
        /// </summary>
        internal KweetTextTooLongException() : base("The kweet content has too many characteres, the limit is 140.")
        {
        }
    }
}
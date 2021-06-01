// <copyright file="KwetterTextException.cs" company="Kwetter">
//     Copyright Kwetter. All rights reserved.
// </copyright>
// <author>Dirk Heijnen</author>

namespace KweetService.Domain.Text.Exceptions.Base
{
    using System;

    /// <summary>
    /// Describes the base exception for any exception thrown specifically by the Kwetter.Domain.Text package.
    /// </summary>
    public class KwetterTextException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="KwetterTextException"/> class.
        /// Creates an <see cref="KwetterTextException"/> with a set message.
        /// </summary>
        /// <param name="message">The message of the exception.</param>
        internal KwetterTextException(string message) : base(message)
        {
        }
    }
}
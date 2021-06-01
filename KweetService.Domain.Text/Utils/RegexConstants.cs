// <copyright file="RegexConstants.cs" company="Kwetter">
//     Copyright Kwetter. All rights reserved.
// </copyright>
// <author>Dirk Heijnen</author>

namespace KweetService.Domain.Text.Utils
{
    /// <summary>
    /// Defines a static class holding regex expressions.
    /// </summary>
    public static class RegexConstants
    {
        /// <summary>
        /// This regex only accepts letters.
        /// </summary>
        public static readonly string ONLY_LETTERS = @"^[a-zA-Z]+$";

        /// <summary>
        /// This regex only accepts letters and numbers.
        /// </summary>
        public static readonly string ONLY_LETTERS_AND_NUMBERS = @"^[a-zA-Z0-9]+$";

        /// <summary>
        /// This regex only accepts letters, numbers and underscores.
        /// </summary>
        public static readonly string ONLY_LETTERS_NUMBERS_AND_UNDERSCORES = @"^[a-zA-Z0-9_]+$";
    }
}
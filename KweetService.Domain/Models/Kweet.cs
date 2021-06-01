// <copyright file="Kweet.cs" company="Kwetter">
//     Copyright Kwetter. All rights reserved.
// </copyright>
// <author>Dirk Heijnen</author>

namespace KweetService.Domain.Models
{
    using System;
    using KweetService.Domain.Text.Models;

    /// <summary>
    /// The kweet model.
    /// </summary>
    public class Kweet
    {
        /// <summary>
        /// The identifier of the kweet.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The identifier of the user who created the kweet.
        /// </summary>
        public Guid AuthorId { get; set; }

        /// <summary>
        /// The date when the kweet was created.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// The text of the kweet.
        /// </summary>
        public KweetText Text { get; set; }
    }
}
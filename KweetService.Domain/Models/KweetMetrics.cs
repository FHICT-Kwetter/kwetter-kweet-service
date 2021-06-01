// <copyright file="KweetMetrics.cs" company="Kwetter">
//     Copyright Kwetter. All rights reserved.
// </copyright>
// <author>Dirk Heijnen</author>

namespace KweetService.Domain.Models
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Holds the metrics of the kweet.
    /// </summary>
    public class KweetMetrics
    {
        /// <summary>
        /// The amount of likes the kweet has.
        /// </summary>
        public IList<KweetLike> Likes { get; set; } = new List<KweetLike>();

        /// <summary>
        /// The amount of replies given to the kweet.
        /// </summary>
        public int ReplyCount { get; set; }
    }

    public class KweetLike
    {
        public Guid UserId { get; set; }
    }
}
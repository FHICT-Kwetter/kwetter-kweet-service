using System;
using KweetService.Domain.Text.Models;

namespace KweetService.Domain.Models
{
    public class Kweet
    {
        public Guid Id { get; set; }

        public Guid AuthorId { get; set; }

        public DateTime CreatedAt { get; set; }

        public KweetText Text { get; set; }
    }
}
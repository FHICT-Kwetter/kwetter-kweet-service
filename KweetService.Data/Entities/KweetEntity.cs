using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KweetService.Data.Entities
{
    [Table("Kweets", Schema = "Kweets")]
    public class KweetEntity
    {
        [Key]
        public Guid Id { get; set; }
        
        public Guid AuthorId { get; set; }
        
        public DateTime CreatedAt { get; set; }
        
        public string Text { get; set; }
    }
}
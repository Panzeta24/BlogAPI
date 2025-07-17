using System;
using System.ComponentModel.DataAnnotations;

namespace BlogAPI.Domain.Entities
{
    public class Comment
    {
        
        public int Id { get; set; }

        [Required]
        public string Author { get; set; } = string.Empty;
        
        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public string Content { get; set; } = string.Empty;

        [Required]
        public int PostId { get; set; }

        public virtual Post Post { get; set; }      // desde una instancia de Comment. ej: myComment.Post.Title
    }
}
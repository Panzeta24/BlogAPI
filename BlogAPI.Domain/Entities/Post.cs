using System.ComponentModel.DataAnnotations;


namespace BlogAPI.Domain.Entities
{
    public class Post
    {
        public int id { get; set; }
        [Required]
        [StringLength(200)]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Content { get; set; } = string.Empty;
            
        // resumen opcional
        [MaxLength(500)]     // un maximo de 500 caracteres
        public string Summary {  get; set; } = string.Empty;
            
        // fecha de creacion
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // fecha de actualizacion
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public int UserId { get; set; } // usuario creador

        public virtual User User { get; set; } // propiedad de navegacion

        public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();
    }

}
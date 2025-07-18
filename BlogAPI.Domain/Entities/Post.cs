


namespace BlogAPI.Domain.Entities
{
    public class Post
    {
        public int Id { get; set; }
       
        public string Title { get; set; } = string.Empty;

       
        public string Content { get; set; } = string.Empty;
            
        // resumen opcional
        public string Summary {  get; set; } = string.Empty;
            
        // fecha de creacion
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // fecha de actualizacion
        public DateTime? UpdatedAt { get; set; } 

        public int UserId { get; set; } // usuario creador

        public virtual User User { get; set; } = null!;// propiedad de navegacion

        public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();
    }

}
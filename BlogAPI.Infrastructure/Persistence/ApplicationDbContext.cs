using System;
using BlogAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlogAPI.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options) : base(options)
        {

        }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Post>(entity => // estos simbolos avisan que entraran varias reglas a la misma entidad "Post"
            {
                // #1 regla: "Title" es obligatoria y con un maximo de 200 caracteres.
                entity.Property(p => p.Title).IsRequired().HasMaxLength(200);

                // #2 regla: "Content" es obligatoria.
                entity.Property(p => p.Content).IsRequired();

                // #3 regla: "Summary" maximo de 500 caracteres.
                entity.Property(p => p.Summary).HasMaxLength(500);

                // #4 regla: Por "Post" va a haber solo UN "User", pero un "User" puede tener varios "Post".
                // con el "UserId" definimos esta regla.
                entity.HasOne(p => p.User)  // HasOne (tiene UNO) solo va a tener un User
                .WithMany(p => p.Posts).  // WhitMany (con varios) mas de un solo Post
                HasForeignKey(p => p.Id).
                OnDelete(DeleteBehavior.Restrict); // es una regla para la base de datos, basicamente "No borrar el "User" si tiene asociados "Posts"
            });


            modelBuilder.Entity<User>(entity =>
            {
                // #1 regla: No pueden existir usuarios con el mismo "UserName"
                // se creara un Indice unico en la DB para eso.
                entity.HasIndex(u => u.UserName).IsUnique();  // HasIndex (Tiene un Indice) y IsUnique (es unico).

                // #2 regla: El Email debe ser unico.
                entity.HasIndex(u => u.Email).IsUnique();
            });

            modelBuilder.Entity<Role>(entity =>
            {
                // #1 regla: los nombres de los roles son unicos.
                entity.HasIndex(r => r.Name).IsUnique();
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                // #1 regla: la llave de esta tabla no solo es un Id. Es la combinacion de "UserId" y "RoleId".
                // Esto es para NO dar el mismo ROL dos veces al mismo usuario.

                entity.HasKey(ur => new { ur.UserId, ur.RoleId });

                // #2 regla de relacion: Un UserRole "Tiene Uno" y solo un User.
                // A su vez, un User "Tiene Muchas" entradas en UserRoles.
                entity.HasOne(ur => ur.User)
                .WithMany(u => u.UserRoles)
                .HasForeignKey(u => u.UserId);
            });
        }
    }
}

using System;
using System.Collections.Generic;

namespace BlogAPI.Domain.Entities
{
	public class User
	{
		public int Id {  get; set; }

		public string UserName { get; set; } = null!;

		public string Email { get; set; } = null!;
		
		public string PasswordHash { get; set; } = null!;// IMPORTANTE hash para la contraseña

		public virtual ICollection<Post> Posts {  get; set; }
	
		public virtual ICollection<UserRole> UserRoles {  get; set; }

	}
}

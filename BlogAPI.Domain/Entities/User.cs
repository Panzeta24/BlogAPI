using System;
using System.Collections.Generic;

namespace BlogAPI.Domain.Entities
{
	public User
	{
		public int Id {  get; set; }

		public string UserName {  get; set; }

		public string Email {  get; set; }
		
		public string PasswordHash {  get; set; }	// IMPORTANTE hash para la contraseña

		public virtual ICollection<Post> Posts {  get; set; }
	
		public virtual ICollection<UserRole> UserRoles {  get; set; }

	}
}

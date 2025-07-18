using System;
using System.Collections.Generic;

namespace BlogAPI.Domain.Entities
{
	public class Role
	{
		public int Id { get; set; }
		public string Name { get; set; } = null!;// "admin", "author", "reader" 

        public virtual ICollection<UserRole> UserRoles { get; set; } 

	}
}

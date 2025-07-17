using System;
using System.Collections.Generic;

namespace BlogAPI.Domain.Entities
{
    public class UserRole       // Esta clase no tiene un Id propio. Su llave primaria será la combinación de UserId y RoleId. Le diremos a Entity Framework cómo manejar esto en el siguiente paso.
    {
        public int UserId { get; set; }
        public virtual User User { get; set; }

        public int RoleId { get; set; }
        public virtual Role Role { get; set; }
    }
}
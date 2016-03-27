using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OkamiBooks.Models.Entities
{
    public class User: Entity
    {
        public string Login { get; set; }
        public string Email { get; set; }
        public string HashedPassword { get; set; }
        public Role UserRole { get; set; }
    }
}
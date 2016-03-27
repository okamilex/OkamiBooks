using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using OkamiBooks.Models.Entities;

namespace OkamiBooks.Models
{
    public class DatabaseContext: DbContext
    {
        public DatabaseContext()
            : base("DefaultConnection")
        {
            
        }

        public DbSet<User> Users { get; set; } 
        public DbSet<Role> Roles { get; set; }
    }
}
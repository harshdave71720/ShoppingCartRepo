using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using KeyBasedAuthenticator.Models;

namespace ShoppingSystemWebAPI.Authentication
{
    public class AuthDbContext : DbContext
    {
        public AuthDbContext() {
            Database.SetInitializer<AuthDbContext>(new DropCreateDatabaseIfModelChanges<AuthDbContext>());
        }

        public AuthDbContext(string connectionString) : base(connectionString) { 
        
        }
        public DbSet<AppUser> AppUsers { get; set; }
    }
}
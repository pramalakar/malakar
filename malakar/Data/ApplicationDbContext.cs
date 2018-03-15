using malakar.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace malakar.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("malakar")
        {
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<User> User { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}
using malakar.Models;
using malakar.Models.Entities;
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
        public DbSet<Role> Role { get; set; }
        public DbSet<Layout> Layout { get; set; }
        public DbSet<WidgetRow> WidgetRow { get; set; }
        public DbSet<Widget> Widget { get; set; }


        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}
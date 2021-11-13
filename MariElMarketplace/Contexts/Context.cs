using Microsoft.EntityFrameworkCore;
using MariElMarketplace.Models;

namespace MariElMarketplace.Contexts
{
    public class Context : DbContext
    {

        public DbSet<Distance> Distances { get; set;}

        public DbSet<Product> Products { get; set;  }

        public DbSet<IdentityRole> Roles { get; set;}

        public DbSet<Requests> Requests { get; set; }


        public Context(DbContextOptions<Context> options) : base(options)
        {
            Database.EnsureCreated();
        }

    }
}

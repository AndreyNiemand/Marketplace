using Microsoft.EntityFrameworkCore;
using MariElMarketplace.Models;

namespace MariElMarketplace.Contexts
{
    public class Context : DbContext
    {

        public DbSet<Distance> Distances { get; set; }

        public Context(DbContextOptions<Context> options) : base(options)
        {
            Database.EnsureCreated();
        }

    }
}

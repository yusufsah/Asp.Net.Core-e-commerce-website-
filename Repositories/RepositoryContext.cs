using Entites.Models;
using Microsoft.EntityFrameworkCore;

namespace Repositories
{
    public class RepositoryContext : DbContext
    {

        public DbSet<Product> Products { get; set; }

        public DbSet<Category> categories { get; set; }

        public DbSet<Order> Orders { get; set; }


        public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }

    }
}

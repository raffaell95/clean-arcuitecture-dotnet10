using CleanArchitecture.Domain.Models;
using CleanArchitecture.InfraStructure.Maps;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.InfraStructure.Data
{
    public class CleanArchitectureContext : DbContext
    {
        public CleanArchitectureContext(DbContextOptions<CleanArchitectureContext> options) : base(options)
        {

        }

        //Dbsets
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new CategoryMap());
            modelBuilder.ApplyConfiguration(new ProductMap());
        }
    }
}

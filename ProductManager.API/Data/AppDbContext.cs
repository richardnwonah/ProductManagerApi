using Microsoft.EntityFrameworkCore;
using ProductManager.API.Models;

namespace ProductManager.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { 

        }
        
        public DbSet<Business> Businesses { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Product> Products { get; set; }
       

      protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
              .Entity<User>()
              .HasMany(x => x.Businesses)
              .WithOne(x => x.User); 

             modelBuilder
              .Entity<Business>()
              .HasMany(x => x.ProductCategories)
              .WithOne(x => x.Business);

              modelBuilder
              .Entity<ProductCategory>()
              .HasMany(x => x.Products);
        }
    }
}
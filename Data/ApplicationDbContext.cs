using BlazorWithDB.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlazorWithDB.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Models.Product> Products { get; set; }
        public DbSet<Models.ProductCat> Product_Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.Product_ID);
                entity.Property(e => e.Product_ID).ValueGeneratedOnAdd(); // Identity column
                entity.Property(e => e.P_name).IsRequired().HasMaxLength(100);
                
            });
            modelBuilder.Entity<ProductCat>(entity =>
            {
                entity.HasKey(e => e.Category_Id);
                entity.Property(e => e.Category_Id).ValueGeneratedOnAdd(); // Identity column
                entity.Property(e => e.Category_Name).IsRequired().HasMaxLength(50);
            });
        }
    }
}

using Ecommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> Categories { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<ProductMenu> ProductMenus { get; set; }
        

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {      
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductMenu>()
                .HasKey(c => new { c.ProductID, c.MenuID });
        }
    }
}

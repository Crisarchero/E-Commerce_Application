using Microsoft.EntityFrameworkCore;
using E_Commerce_Application.Models;

namespace E_Commerce_Application.Data
{
    public class ShopDbContext : DbContext
    {
        public ShopDbContext(DbContextOptions<ShopDbContext> options) :base(options)
        {
            
        }
        public DbSet<Category> Categories { get;set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Review> Reviews { get; set; }

    }
}

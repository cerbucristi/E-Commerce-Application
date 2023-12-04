using ECommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class ECommerceContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<User> Users { get; set; }
        public ECommerceContext(DbContextOptions<ECommerceContext> options) : base(options) { }

    }
}



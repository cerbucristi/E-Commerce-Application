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


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Server=(lCocaldb)\\MSSQLLocalDB;Database=ECommerceDB;Trusted_Connection=True;");

            optionsBuilder.UseNpgsql("Server=localhost; Port=5433; Database=ECommerceDB; User Id=postgres; Password=postgresql");
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlite("Data Source=ECommerceDB.db");
        //}
    
    }
}

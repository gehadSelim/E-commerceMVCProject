using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using E_commerceMVCProject.Models;
using System.Reflection.Emit;
using E_commerceMVCProject.Configurations;

namespace E_commerceMVCProject.Models
{
    public class EComEntity : IdentityDbContext<ApplicationUser>
    {
        public EComEntity() : base() { }
        public EComEntity(DbContextOptions options) : base(options) { }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<ShoppingCart> Carts { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            new OrderEntityTypeConfiguration().Configure(modelBuilder.Entity<Order>());

            new OrderDetailEntityTypeConfiguration().Configure(modelBuilder.Entity<OrderDetail>());

            new ProductEntityTypeConfiguration().Configure(modelBuilder.Entity<Product>());


        }
    }
}

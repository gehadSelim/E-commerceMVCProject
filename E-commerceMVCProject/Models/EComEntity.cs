using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace E_commerceMVCProject.Models
{
    public class EComEntity : IdentityDbContext
    {
        public EComEntity() : base() { }
        public EComEntity(DbContextOptions options) : base(options) { }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Order>()
                .HasMany(o => o.OrderDetails)
                .WithOne(od => od.Order)
                .HasForeignKey(od => od.OrderId);

            modelBuilder.Entity<Product>()
                .HasMany(p => p.OrderDetails)
                .WithOne(od => od.Product)
                .HasForeignKey(od => od.ProductId);

            modelBuilder.Entity<Cart>()
                .HasMany(c => c.CartItems)
                .WithOne(i => i.Cart)
                .HasForeignKey(i => i.CartId);

            modelBuilder.Entity<OrderDetail>()
                    .Property(o => o.TotalSellingPrice)
                    .HasComputedColumnSql("[SellingPrice] * [Quantity]");

            modelBuilder.Entity<OrderDetail>()
               .Property(o => o.TotalBuyingPrice)
               .HasComputedColumnSql("[BuyingPrice] * [Quantity]");

            modelBuilder.Entity<OrderDetail>()
                .Property(o => o.Profit)
                .HasComputedColumnSql("[SellingPrice] * [Quantity] - [BuyingPrice] * [Quantity]");

            modelBuilder.Entity<Order>()
                .Property(o => o.OrderDate)
                .HasDefaultValueSql("GETDATE()");

        }
    }
}

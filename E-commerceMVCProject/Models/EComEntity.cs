using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using E_commerceMVCProject.Models;
using System.Reflection.Emit;
using E_commerceMVCProject.Configurations;
using Microsoft.AspNetCore.Identity;

namespace E_commerceMVCProject.Models
{
    public class EComEntity : IdentityDbContext<ApplicationUser>
    {
        public EComEntity() : base() { }
        public EComEntity(DbContextOptions options) : base(options) { }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ProductBrand> ProductBrands { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<ShoppingCart> Carts { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            new OrderEntityTypeConfiguration().Configure(modelBuilder.Entity<Order>());

            new OrderDetailEntityTypeConfiguration().Configure(modelBuilder.Entity<OrderDetail>());

            new ProductEntityTypeConfiguration().Configure(modelBuilder.Entity<Product>());

            modelBuilder.Entity<IdentityRole>().HasData(
               new { Id = "f2c3f0d1-77e5-4fc2-bb59-b6b811380be7", Name = "Admin" },
               new { Id = "f2c3f0d1-77e5-4fc2-bb59-b6b811380be6", Name = "Customer" }
               );

            ApplicationUser user = new ApplicationUser()
            {
                FullName = "Admin",
                Email = "ayaahmed199910@gmail.com",
                Address = "cairo",
                BirthDate = "28-10-1999",
                Gender = "Female",
                UserName = "Admin",
                NormalizedUserName = "ADMIN",
                NormalizedEmail = "AYAAHMED199910@GMAIL.COM",
                EmailConfirmed = true
            };
            var password = "Admin1234#";
            var passwordHasher = new PasswordHasher<ApplicationUser>();
            var hashedPassword = passwordHasher.HashPassword(user, password);
            user.PasswordHash = hashedPassword;
            modelBuilder.Entity<ApplicationUser>().HasData(user);

            modelBuilder.Entity<IdentityUserRole<string>>()
                     .HasKey(ur => new { ur.UserId, ur.RoleId });

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string> { UserId = user.Id, RoleId = "f2c3f0d1-77e5-4fc2-bb59-b6b811380be7" });


        }
    }
}

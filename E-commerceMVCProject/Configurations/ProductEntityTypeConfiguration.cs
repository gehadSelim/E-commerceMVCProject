using E_commerceMVCProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace E_commerceMVCProject.Configurations
{
    public class ProductEntityTypeConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder
                .HasMany(p => p.OrderDetails)
                .WithOne(od => od.Product)
                .HasForeignKey(od => od.ProductId);
        }
    }
}

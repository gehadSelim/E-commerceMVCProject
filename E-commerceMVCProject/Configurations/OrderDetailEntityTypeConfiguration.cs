using E_commerceMVCProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace E_commerceMVCProject.Configurations
{
    public class OrderDetailEntityTypeConfiguration : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder
               .Property(o => o.TotalSellingPrice)
               .HasComputedColumnSql("[SellingPrice] * [Quantity]");

            builder
               .Property(o => o.TotalBuyingPrice)
               .HasComputedColumnSql("[BuyingPrice] * [Quantity]");

            builder
               .Property(o => o.Profit)
               .HasComputedColumnSql("[SellingPrice] * [Quantity] - [BuyingPrice] * [Quantity]");
        }
    }
}

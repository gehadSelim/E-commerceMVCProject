using E_commerceMVCProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace E_commerceMVCProject.Configurations
{
    public class OrderEntityTypeConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder
                .HasMany(o => o.OrderDetails)
                .WithOne(od => od.Order)
                .HasForeignKey(od => od.OrderId);

            builder
                .Property(o => o.OrderDate)
                .HasDefaultValueSql("GETDATE()");

            builder.HasQueryFilter(o => !o.IsDeleted);
        }
    }
}

using E_commerceMVCProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace E_commerceMVCProject.Configurations
{
    public class ShoppingCartEntityTypeConfiguration : IEntityTypeConfiguration<ShoppingCart>
    {
        public void Configure(EntityTypeBuilder<ShoppingCart> builder)
        {
            builder
                .HasMany(c => c.CartItems)
                .WithOne(i => i.Cart)
                .HasForeignKey(i => i.ShoppingCartId);
        }
    }
}

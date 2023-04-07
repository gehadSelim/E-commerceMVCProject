using E_commerceMVCProject.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;


namespace E_commerceMVCProject.Repository
{
    public class CartItemRepository : Repository<CartItem>, ICartItemRepository
    {
        public CartItemRepository(EComEntity context) : base(context)
        {
        }

        public void DecreaseQuantity(int Id)
        {
            CartItem cartItem = GetByIdWithInclude(ci => ci.Id == Id, ci => ci.Product);
            if (cartItem.Quantity < cartItem.Product.StockCount)
                cartItem.Quantity++;
            Update(cartItem);
        }

        public void IncreaseQuantity(int Id)
        {
            CartItem cartItem = GetById(Id);
            if (cartItem.Quantity > 0)
                cartItem.Quantity--;
            Update(cartItem);
        }
    }
}

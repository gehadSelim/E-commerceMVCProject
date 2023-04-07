using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using E_commerceMVCProject.Models;

namespace E_commerceMVCProject.Repository
{
    public class ShoppingCartRepository : Repository<ShoppingCart>, IShoppingCartRepository
    {
        public ShoppingCartRepository(EComEntity context) : base(context)
        {
        }
        public void ClearCartItems(int id)
        {
            var cart = GetByIdWithInclude(c => c.Id == id, c => c.CartItems);
            if (cart != null)
            {
                cart.CartItems = new List<CartItem>();
                Save();
            }
        }
        public ShoppingCart GetByUserId(string userId)
        {
            return GetByIdWithInclude(s => s.UserId == userId, s => s.CartItems);
        }
    }
}

using E_commerceMVCProject.Models;

namespace E_commerceMVCProject.Services
{
    public interface IShoppingCartService
    {
        void AddCart(ShoppingCart cart);
        void UpdateCart(ShoppingCart cart);
        void DeletefromCart(int id);
        ShoppingCart GetCartById(int id);
        ShoppingCart GetCartByProductandUserId(int productId,string userId);
        List<ShoppingCart> GetCartByUserId(string userId);
    }
}

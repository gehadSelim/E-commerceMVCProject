using E_commerceMVCProject.Models;
using E_commerceMVCProject.viewmodels;

namespace E_commerceMVCProject.Services
{
    public interface IShoppingCartService
    {
        void AddCart(ShoppingCartVM cartVm);
        void UpdateCart(ShoppingCartVM cartVm);
        void DeletefromCart(int id);
        ShoppingCartVM GetCartById(int id);
        ShoppingCartVM GetCartByProductandUserId(int productId,string userId);
        List<ShoppingCartVM> GetCartByUserId(string userId);
    }
}

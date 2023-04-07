using E_commerceMVCProject.Models;

namespace E_commerceMVCProject.Repository
{
    public interface IShoppingCartRepository : IRepository<ShoppingCart>
    {
        void ClearCartItems(int id);
        ShoppingCart GetByUserId(string userId);
    }
    
}

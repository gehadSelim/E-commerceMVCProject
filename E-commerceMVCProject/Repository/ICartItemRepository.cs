using E_commerceMVCProject.Models;

namespace E_commerceMVCProject.Repository
{
    public interface ICartItemRepository : IRepository<CartItem>
    {
        void IncreaseQuantity(int Id);
        void DecreaseQuantity(int Id);
    }
}

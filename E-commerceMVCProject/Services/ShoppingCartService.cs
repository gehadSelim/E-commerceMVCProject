using E_commerceMVCProject.Models;
using E_commerceMVCProject.Repository;
using Microsoft.EntityFrameworkCore;

namespace E_commerceMVCProject.Services
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly IRepository<ShoppingCart> _cartRepository;

        public ShoppingCartService(IRepository<ShoppingCart> cartRepository)
        {
            _cartRepository = cartRepository;
        }
        public void AddCart(ShoppingCart cart)
        {
            _cartRepository.Insert(cart);
        }

        public void DeletefromCart(int id)
        {
            _cartRepository.Delete(id);
        }

        public ShoppingCart GetCartById(int id)
        {
            return _cartRepository.GetAll().Include(c => c.Product).FirstOrDefault(c => c.Id == id);
        }

        public ShoppingCart GetCartByProductandUserId(int productId, string userId)
        {
            return _cartRepository.GetAll().Include(c => c.Product).FirstOrDefault(c => c.ProductId == productId && c.UserId == userId);
        }

        public List<ShoppingCart> GetCartByUserId(string userId)
        {
            return _cartRepository.GetAll().Include(c => c.Product).Where(c => c.UserId == userId).ToList();
        }

        public void UpdateCart(ShoppingCart cart)
        {
            _cartRepository.Update(cart);
        }
    }
}

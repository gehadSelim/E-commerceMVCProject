using E_commerceMVCProject.Models;
using E_commerceMVCProject.Repository;
using Microsoft.EntityFrameworkCore;

namespace E_commerceMVCProject.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _productRepository;

        public ProductService(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public List<Product> GetAllProducts()
        {
            return _productRepository.GetAll().Include(p=>p.Images).ToList();
        }

        public Product GetProductById(int id)
        {
            return _productRepository.GetAll().Include(p => p.Images).FirstOrDefault(p=>p.Id == id);
        }

        public void AddProduct(Product product)
        {
            _productRepository.Insert(product);
        }

        public void UpdateProduct(Product product)
        {
            _productRepository.Update(product);
        }

        public void DeleteProduct(int id)
        {
            _productRepository.Delete(id);
        }
    }
}

using E_commerceMVCProject.Models;
using E_commerceMVCProject.Repository;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace E_commerceMVCProject.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _productRepository;
        private readonly IRepository<OrderDetail> _orderDetailRepository;

        public ProductService(IRepository<Product> productRepository, IRepository<OrderDetail> orderDetailRepository)
        {
            _productRepository = productRepository;
            _orderDetailRepository = orderDetailRepository;
        }

        public List<Product> GetAllProducts()
        {
            return _productRepository.GetAll().ToList().Where(p => p.StockCount != 0).ToList();
        }

        public Product? GetProductById(int id)
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

        public List<Product> GetBestSellingProducts()
        {
            var topSellingProducts = _orderDetailRepository.GetAll()
                    .GroupBy(d => d.ProductId)
                    .Select(g => new { ProductId = g.Key, Quantity = g.Sum(d => d.Quantity) })
                    .OrderByDescending(p => p.Quantity)
                    .Take(10)
                    .ToList();

            List<Product> products = _productRepository.GetAll()
                    .Where(p => topSellingProducts.Any(tp => tp.ProductId == p.Id))
                    .ToList();

            return products;
        }

        public List<Product> GetBestProfitProducts()
        {
            var topProfitProducts = _orderDetailRepository.GetAll()
                    .GroupBy(d => d.ProductId)
                    .Select(g => new { ProductId = g.Key, Profit = g.Sum(d => d.Profit) })
                    .OrderByDescending(p => p.Profit)
                    .Take(10)
                    .ToList();

            List<Product> products = _productRepository.GetAll()
                    .Where(p => topProfitProducts.Any(tp => tp.ProductId == p.Id))
                    .ToList();

            return products;

        }

        public List<Product> GetByCategoryId(int CategoryId)
        {
            return _productRepository.GetAll().Where(p => p.CategoryId == CategoryId).ToList();
        }

        public List<Product> GetByBrandId(int BrandId)
        {
            return _productRepository.GetAll().Where(p => p.BrandId == BrandId).ToList();
        }
        public List<Product> FilterByName(string searchName)
        {
            return _productRepository.GetAll().Where(p => p.Name.Contains(searchName)).ToList();
        }
        public List<Product> FilterByPrice(int low, int high)
        {
            return _productRepository.GetAll().Where(p => (p.SellingPrice >= low && p.SellingPrice <= high)).ToList();
        }
    }
}

using E_commerceMVCProject.Models;
using E_commerceMVCProject.viewmodels;

namespace E_commerceMVCProject.Services
{
    public interface IProductService
    {
        public List<ProductVM> GetAllProducts();
        ProductVM? GetProductById(int id);
        ProductVM GetProductByIDNoTracking(int id);
        void AddProduct(ProductVM productVM);
        void UpdateProduct(ProductVM productVM);
        void DeleteProduct(int id);
        List<Product> GetByCategoryId(int CategoryId);
        List<Product> GetByBrandId(int BrandId);
        List<Product> GetBestSellingProducts();
        List<Product> GetBestProfitProducts();
        List<Product> FilterByName(string searchName);
        List<Product> FilterByPrice(int low, int high);
    }
}

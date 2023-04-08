using E_commerceMVCProject.Models;

namespace E_commerceMVCProject.Services
{
    public interface IProductService
    {
        List<Product> GetAllProducts();
        Product GetProductById(int id);
        void AddProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(int id);
        List<Product> GetBestSellingProducts();
        List<Product> GetBestProfitProducts();
    }
}

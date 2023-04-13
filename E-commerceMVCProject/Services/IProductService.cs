using E_commerceMVCProject.Models;
using E_commerceMVCProject.viewmodels;

namespace E_commerceMVCProject.Services
{
    public interface IProductService
    {
        List<ProductVM> GetAllProducts();
        int? GetLastId();
        ProductVM? GetProductById(int id);
        ProductVM GetProductByIDNoTracking(int id);
        ProductVM AddProduct(ProductVM productVM);
        ProductVM UpdateProduct(ProductVM productVM);
        void DeleteProduct(int id);
        List<ProductVM> GetByCategoryId(int CategoryId);
        List<ProductVM> GetByBrandId(int BrandId);
        List<ProductVM> GetBestSellingProducts();
        List<ProductVM> GetBestProfitProducts();
        List<ProductVM> FilterByName(string searchName);
        List<ProductVM> FilterByPrice(int low, int high);
        List<List<ProductVM>> FilterbyBrands(List<int> BrandsIds);

    }
}

using E_commerceMVCProject.Models;

namespace E_commerceMVCProject.Services
{
    public interface IProductBrandService
    {
        List<ProductBrand> GetAllBrands();
        ProductBrand? GetBrandById(int id);
        void AddBrand(ProductBrand brand);
        void UpdateBrand(ProductBrand brand);
        void DeleteBrand(int id);
    }
}

using E_commerceMVCProject.Models;

namespace E_commerceMVCProject.Services
{
    public interface IProductCategoryService
    {
        List<ProductCategory> GetAllCategories();
        ProductCategory? GetCategoryById(int id);
        void AddCategory(ProductCategory category);
        void UpdateCategory(ProductCategory category);
        void DeleteCategory(int id);
    }
}

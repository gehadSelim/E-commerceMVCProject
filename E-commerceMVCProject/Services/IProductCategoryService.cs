using E_commerceMVCProject.Models;
using E_commerceMVCProject.viewmodels;

namespace E_commerceMVCProject.Services
{
    public interface IProductCategoryService
    {
        List<CategoryVM> GetAllCategories();
        CategoryVM GetCategoryByID(int id);
        CategoryVM GetCategoryByIDNoTracking(int id);
        CategoryVM AddCategory(CategoryVM CategoryVM);
        CategoryVM UpdateCategory(CategoryVM CategoryVM);
        void DeleteCategory(int id);
    }
}

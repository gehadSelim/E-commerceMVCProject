using E_commerceMVCProject.Models;
using E_commerceMVCProject.Repository;

namespace E_commerceMVCProject.Services
{
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly IRepository<ProductCategory> _categoryRepository;

        public ProductCategoryService(IRepository<ProductCategory> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public void AddCategory(ProductCategory category)
        {
            _categoryRepository.Insert(category);
        }

        public void DeleteCategory(int id)
        {
            _categoryRepository.Delete(id);
        }

        public List<ProductCategory> GetAllCategories()
        {
            return _categoryRepository.GetAll().ToList();
        }

        public ProductCategory? GetCategoryById(int id)
        {
            return _categoryRepository.GetAll().FirstOrDefault(category => category.Id == id);
        }

        public void UpdateCategory(ProductCategory category)
        {
            _categoryRepository.Update(category);
        }
    }
}

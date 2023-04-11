using AutoMapper;
using E_commerceMVCProject.Models;
using E_commerceMVCProject.Repository;
using E_commerceMVCProject.viewmodels;
using Microsoft.EntityFrameworkCore;

namespace E_commerceMVCProject.Services
{
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly IRepository<ProductCategory> _CategoryRepository;
        private readonly IMapper _mapper;
        public ProductCategoryService(IRepository<ProductCategory> CategoryRepository, IMapper mapper)
        {
            _CategoryRepository = CategoryRepository;
            _mapper = mapper;
        }
        public List<CategoryVM> GetAllCategories()
        {
            var bransList = _CategoryRepository.GetAll().ToList();
            var CategoryVMList = _mapper.Map<List<ProductCategory>, List<CategoryVM>>(bransList);
            return CategoryVMList;
        }
        public CategoryVM GetCategoryByID(int id)
        {
            var Category = _CategoryRepository.GetAll().FirstOrDefault(Category => Category.Id == id);
            var CategoryVM = _mapper.Map<ProductCategory, CategoryVM>(Category);
            return CategoryVM;
        }
        public CategoryVM GetCategoryByIDNoTracking(int id)
        {
            var Category = _CategoryRepository.GetAll().Where(Category => Category.Id == id).AsNoTracking().ToList().FirstOrDefault();
            var CategoryVM = _mapper.Map<ProductCategory, CategoryVM>(Category);
            return CategoryVM;
        }
        public CategoryVM AddCategory(CategoryVM CategoryVM)
        {
            var Category = _mapper.Map<CategoryVM, ProductCategory>(CategoryVM);
            _CategoryRepository.Insert(Category);
            return CategoryVM;
        }
        public CategoryVM UpdateCategory(CategoryVM CategoryVM)
        {
            var Category = _mapper.Map<CategoryVM, ProductCategory>(CategoryVM);
            _CategoryRepository.Update(Category);
            return CategoryVM;
        }
        public void DeleteCategory(int id)
        {
            _CategoryRepository.Delete(id);
        }
    }
}

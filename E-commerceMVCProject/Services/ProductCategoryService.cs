using AutoMapper;
using E_commerceMVCProject.Models;
using E_commerceMVCProject.Repository;
using E_commerceMVCProject.viewmodels;
using MailKit.Search;
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
            List<ProductCategory> categories = _CategoryRepository.GetAll().ToList();
            return _mapper.Map<List<CategoryVM>>(categories);
        }
        public CategoryVM GetCategoryByID(int id)
        {
            ProductCategory category = _CategoryRepository.GetById(id);
            return _mapper.Map<CategoryVM>(category);
        }
        public CategoryVM GetCategoryByIDNoTracking(int id)
        {
            ProductCategory category = _CategoryRepository.GetAll().Where(category => category.Id == id).AsNoTracking().ToList().FirstOrDefault();
            return _mapper.Map<CategoryVM>(category);
        }
        public void AddCategory(CategoryVM CategoryVM)
        {
            ProductCategory category = _mapper.Map<ProductCategory>(CategoryVM);
            _CategoryRepository.Insert(category);
        }
        public void UpdateCategory(CategoryVM CategoryVM)
        {
            ProductCategory category = _mapper.Map<ProductCategory>(CategoryVM);
            _CategoryRepository.Update(category);
        }
        public void DeleteCategory(int id)
        {
            _CategoryRepository.Delete(id);
        }
    }
}

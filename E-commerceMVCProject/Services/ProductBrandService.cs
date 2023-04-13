using AutoMapper;
using E_commerceMVCProject.Models;
using E_commerceMVCProject.Repository;
using E_commerceMVCProject.viewmodels;
using Microsoft.EntityFrameworkCore;

namespace E_commerceMVCProject.Services
{
    public class ProductBrandService : IProductBrandService
    {
        private readonly IRepository<ProductBrand> _brandRepository;
        private readonly IMapper _mapper;
        public ProductBrandService(IRepository<ProductBrand> brandRepository, IMapper mapper)
        {
            _brandRepository = brandRepository;
            _mapper = mapper;
        }
        public List<BrandVM> GetAllBrands()
        {
            List<ProductBrand> brands = _brandRepository.GetAll().ToList();
            return _mapper.Map<List<BrandVM>>(brands);
        }
        public BrandVM GetBrandByID(int id)
        {
            ProductBrand brand = _brandRepository.GetById(id);
            return _mapper.Map<BrandVM>(brand);
        }
        public BrandVM GetBrandByIDNoTracking(int id)
        {
            ProductBrand brand = _brandRepository.GetAll().Where(brand => brand.Id == id).AsNoTracking().ToList().FirstOrDefault();
            return _mapper.Map<BrandVM>(brand);
        }
        public void AddBrand(BrandVM brandVM)
        {
            var brand = _mapper.Map<BrandVM, ProductBrand>(brandVM);
            _brandRepository.Insert(brand);
        }
        public void UpdateBrand(BrandVM brandVM)
        {
            var brand = _mapper.Map<ProductBrand>(brandVM);
            _brandRepository.Update(brand);
        }
        public void DeleteBrand(int id)
        {
            _brandRepository.Delete(id);
        }
    }
}

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
            var bransList = _brandRepository.GetAll().ToList();
            var brandVMList = _mapper.Map<List<ProductBrand>, List<BrandVM>>(bransList);
            return brandVMList;
        }
        public BrandVM GetBrandByID(int id)
        {
            var brand = _brandRepository.GetAll().FirstOrDefault(brand => brand.Id == id);
            var brandVM = _mapper.Map<ProductBrand, BrandVM>(brand);
            return brandVM;
        }
        public BrandVM GetBrandByIDNoTracking(int id)
        {
            var brand = _brandRepository.GetAll().Where(brand => brand.Id == id).AsNoTracking().ToList().FirstOrDefault();
            var brandVM = _mapper.Map<ProductBrand, BrandVM>(brand);
            return brandVM;
        }
        public BrandVM AddBrand(BrandVM brandVM)
        {
            var brand = _mapper.Map<BrandVM, ProductBrand>(brandVM);
            _brandRepository.Insert(brand);
            return brandVM;
        }
        public BrandVM UpdateBrand(BrandVM brandVM)
        {
            var brand = _mapper.Map<BrandVM, ProductBrand>(brandVM);
            _brandRepository.Update(brand);
            return brandVM;
        }
        public void DeleteBrand(int id)
        {
            _brandRepository.Delete(id);
        }
    }
}

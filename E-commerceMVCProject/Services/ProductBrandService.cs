using E_commerceMVCProject.Models;
using E_commerceMVCProject.Repository;

namespace E_commerceMVCProject.Services
{
    public class ProductBrandService : IProductBrandService
    {
        private readonly IRepository<ProductBrand> _brandRepository;

        public ProductBrandService(IRepository<ProductBrand> brandRepository)
        {
            _brandRepository = brandRepository;
        }
        public void AddBrand(ProductBrand brand)
        {
            _brandRepository.Insert(brand);
        }

        public void DeleteBrand(int id)
        {
            _brandRepository.Delete(id);
        }

        public List<ProductBrand> GetAllBrands()
        {
            return _brandRepository.GetAll().ToList();
        }

        public ProductBrand? GetBrandById(int id)
        {
            return _brandRepository.GetAll().FirstOrDefault(brand => brand.Id == id);
        }

        public void UpdateBrand(ProductBrand brand)
        {
            _brandRepository.Update(brand);
        }
    }
}

using AutoMapper;
using E_commerceMVCProject.Models;
using E_commerceMVCProject.Repository;
using E_commerceMVCProject.viewmodels;

namespace E_commerceMVCProject.Services
{
    public interface IProductBrandService
    {
        List<BrandVM> GetAllBrands();
        BrandVM GetBrandByID(int id);
        BrandVM GetBrandByIDNoTracking(int id);
        BrandVM AddBrand(BrandVM brandVM);
        BrandVM UpdateBrand(BrandVM brandVM);
        void DeleteBrand(int id);
    }
}

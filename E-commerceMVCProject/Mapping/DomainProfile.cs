using AutoMapper;
using E_commerceMVCProject.Models;
using E_commerceMVCProject.viewmodels;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace E_commerceMVCProject.Mapping
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<ProductCategory, CategoryVM>().ReverseMap();
            CreateMap<ProductBrand, BrandVM>().ReverseMap();
        }
    }
}

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
            CreateMap<Product, ProductVM>().ReverseMap();
            CreateMap<ProductCategory, CategoryVM>().ReverseMap();
            CreateMap<ProductBrand, BrandVM>().ReverseMap();
            CreateMap<Order, OrderVM>().ReverseMap();
            CreateMap<ShoppingCart, ShoppingCartVM>()
                .ForMember(dest => dest.Product, opt => opt.MapFrom(src => src.Product))
                .ReverseMap();
            CreateMap<ApplicationUser, RegisterVM>()
               .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
               .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
               .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName))
               .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.BirthDate))
               .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender))
               .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
               .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.PasswordHash))
               .ReverseMap();
        }
    }
}

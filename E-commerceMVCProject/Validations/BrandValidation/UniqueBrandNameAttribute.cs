using E_commerceMVCProject.Models;
using E_commerceMVCProject.Services;
using E_commerceMVCProject.viewmodels;
using System.ComponentModel.DataAnnotations;

namespace E_commerceMVCProject.Validations.BrandValidation
{
    public class UniqueBrandNameAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var brandService = validationContext.GetService<IProductBrandService>();
            BrandVM? brand = brandService?.GetAllBrands().FirstOrDefault(brand => brand.Name == value?.ToString());
            return (brand == null) ? ValidationResult.Success : new ValidationResult("Brand Name is Used Before");
        }
    }
}

using E_commerceMVCProject.Models;
using E_commerceMVCProject.Services;
using System.ComponentModel.DataAnnotations;

namespace E_commerceMVCProject.Validations.ProductValidation
{
    public class UniqueProductNameAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var productService = validationContext.GetService<IProductService>();
            Product? product = productService?.GetAllProducts().FirstOrDefault(product => product.Name == value?.ToString());
            return product == null ? ValidationResult.Success : new ValidationResult("Product Name is Used Before");
        }
    }
}

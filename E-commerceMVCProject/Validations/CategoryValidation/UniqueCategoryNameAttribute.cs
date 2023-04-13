namespace E_commerceMVCProject.Validations.CategoryValidation
{
    public class UniqueCategoryNameAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var categoryService = validationContext.GetService<IProductCategoryService>();
            CategoryVM? category = categoryService?.GetAllCategories().FirstOrDefault(category => category.Name == value?.ToString());
            return (category == null) ? ValidationResult.Success : new ValidationResult("Category Name is Used Before");
        }
    }
}

using E_commerceMVCProject.Validations.CategoryValidation;
using System.ComponentModel.DataAnnotations;

namespace E_commerceMVCProject.viewmodels
{
    public class CategoryVM
    {
        public int Id { get; set; }
        [Required]
        [UniqueCategoryName]
        public string Name { get; set; }
    }
}

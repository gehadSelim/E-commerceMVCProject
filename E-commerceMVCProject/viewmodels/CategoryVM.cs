using E_commerceMVCProject.Models;
using E_commerceMVCProject.Validations;
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

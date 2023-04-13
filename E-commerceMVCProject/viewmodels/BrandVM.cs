using E_commerceMVCProject.Models;
using E_commerceMVCProject.Validations;
using System.ComponentModel.DataAnnotations;

namespace E_commerceMVCProject.viewmodels
{
    public class BrandVM
    {
        public int Id { get; set; }
        [Required]
        [UniqueBrandName]
        public string Name { get; set; }

    }
}

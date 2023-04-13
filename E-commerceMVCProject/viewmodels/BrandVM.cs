using E_commerceMVCProject.Validations.BrandValidation;
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

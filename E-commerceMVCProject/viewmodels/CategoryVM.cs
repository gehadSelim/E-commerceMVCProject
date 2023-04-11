using E_commerceMVCProject.Models;
using E_commerceMVCProject.Validations;
using System.ComponentModel.DataAnnotations;

namespace E_commerceMVCProject.viewmodels
{
    public class CategoryVM
    {
        public int Id { get; set; }

        [MinLength(2, ErrorMessage = "Min Length is 2 Letters")]
        [MaxLength(20, ErrorMessage = "Max Length is 20 Letters")]
        public string Name { get; set; }
    }
}

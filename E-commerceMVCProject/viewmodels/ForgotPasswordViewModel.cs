using System.ComponentModel.DataAnnotations;

namespace E_commerceMVCProject.viewmodels
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}

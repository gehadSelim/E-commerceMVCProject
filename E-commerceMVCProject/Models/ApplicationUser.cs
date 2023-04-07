using Microsoft.AspNetCore.Identity;

namespace E_commerceMVCProject.Models
{
    public class ApplicationUser:IdentityUser
    {
        public bool IsAdmin { get; set; }
    }
}
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace E_commerceMVCProject.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public virtual ICollection<CartItem>? CartItems { get; set; }
        public virtual IdentityUser? User { get; set; }
    }
}

using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace E_commerceMVCProject.Models
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        public int Quantity { get; set; } = 0;
        public int ProductId { get; set; }
        public virtual Product? Product { get; set; }
        public string UserId { get; set; }
    }
}

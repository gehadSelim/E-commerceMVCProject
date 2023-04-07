using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_commerceMVCProject.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public decimal TotalPrice { get; set; } = 0; //=> OrderDetails.Sum(od => od.TotalSellingPrice);
        public DateTime OrderDate { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual IdentityUser User { get; set; }
    }
}

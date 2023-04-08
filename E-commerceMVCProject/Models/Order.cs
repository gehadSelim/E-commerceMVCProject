using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_commerceMVCProject.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public decimal TotalPrice { get; set; } = 0;
        public DateTime OrderDate { get; set; }
        public bool IsDeleted { get; set; } = false;
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}

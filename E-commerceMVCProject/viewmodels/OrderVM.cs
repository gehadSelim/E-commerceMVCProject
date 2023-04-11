using E_commerceMVCProject.Models;

namespace E_commerceMVCProject.viewmodels
{
    public class OrderVM
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public decimal TotalPrice { get; set; } = 0;
        public decimal TaxVal { get; set; } = 0;
        public decimal TotalPriceAfterTax { get; set; } = 0;
        public DateTime OrderDate { get; set; }
        public bool IsDeleted { get; set; } = false;
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}

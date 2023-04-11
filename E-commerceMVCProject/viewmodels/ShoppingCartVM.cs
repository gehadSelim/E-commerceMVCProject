using E_commerceMVCProject.Models;

namespace E_commerceMVCProject.viewmodels
{
    public class ShoppingCartVM
    {
        public int Id { get; set; }
        public int Quantity { get; set; } = 0;
        public int ProductId { get; set; }
        public virtual Product? Product { get; set; }
        public string UserId { get; set; }
    }
}

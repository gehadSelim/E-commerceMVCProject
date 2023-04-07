using System.ComponentModel.DataAnnotations.Schema;

namespace E_commerceMVCProject.Models
{
    public class CartItem
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int ProductId { get; set; }        
        public virtual Product? Product { get; set; }
        public int ShoppingCartId { get; set; }
        public virtual ShoppingCart? Cart { get; set; }
    }
}
namespace E_commerceMVCProject.Models
{
    public class Product
    {
        public virtual ICollection<OrderDetail>? OrderDetails { get; set; }

    }
}
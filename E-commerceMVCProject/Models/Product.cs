namespace E_commerceMVCProject.Models
{
    public class Product
    {
        public int Id { get; set; }
        public int StockCount { get; set; }
        public virtual ICollection<OrderDetail>? OrderDetails { get; set; }

    }
}
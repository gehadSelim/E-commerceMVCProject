namespace E_commerceMVCProject.Models
{
    public class Product
    {
        public int Id { get; set; }
        public int StockCount { get; set; }
        public virtual ICollection<OrderDetail>? OrderDetails { get; set; }
        public virtual ICollection<ProductImage> Images { get; set; }
        public decimal SellingPrice { get; set; }
        public decimal BuyingPrice { get; set; }

    }
}
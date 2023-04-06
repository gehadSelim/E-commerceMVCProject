namespace E_commerceMVCProject.Models
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public decimal SellingPrice { get; set; }
        public decimal TotalSellingPrice { get; set; }
        public decimal BuyingPrice { get; set; }
        public decimal TotalBuyingPrice { get; set; }
        public decimal Profit { get; set; }
        public int ProductId { get; set; }
        public virtual Product? Product { get; set; }
        public int OrderId { get; set; }
        public virtual Order? Order { get; set; }
    }
}
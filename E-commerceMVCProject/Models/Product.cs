using System.ComponentModel.DataAnnotations.Schema;

namespace E_commerceMVCProject.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal StockCount { get; set; }
        public virtual ICollection<OrderDetail>? OrderDetails { get; set; }
        public virtual ICollection<ProductImage> Images { get; set; }
        public decimal SellingPrice { get; set; }
        public decimal BuyingPrice { get; set; }
        public int CategoryId { get; set; }
        public virtual ProductCategory ProductCategory { get; set; }
        public int BrandId { get; set; }
        public virtual ProductBrand ProductBrand { get; set; }
    }
}
using E_commerceMVCProject.Models;
using E_commerceMVCProject.Validations;
using System.ComponentModel.DataAnnotations;

namespace E_commerceMVCProject.viewmodels
{
    public class ProductVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal StockCount { get; set; }
        public decimal SellingPrice { get; set; }
        public decimal BuyingPrice { get; set; }
        public int CategoryId { get; set; }
        public int BrandId { get; set; }
        public IFormFileCollection ImagesFiles { get; set; }
        public virtual ICollection<ProductImage> Images { get; set; }
        public ICollection<CategoryVM> Categories { get; set; }
        public ICollection<BrandVM> Brands { get; set; }
    }
}

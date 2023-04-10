using E_commerceMVCProject.Models;
using E_commerceMVCProject.Validations;
using System.ComponentModel.DataAnnotations;

namespace E_commerceMVCProject.viewmodels
{
    public class NewProductVM
    {
        public int Id { get; set; }

        [MinLength(2, ErrorMessage = "Min Length is 2 Letters")]
        [MaxLength(20, ErrorMessage = "Max Length is 20 Letters")]
        [UniqueName]
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal StockCount { get; set; }
        public decimal SellingPrice { get; set; }
        public decimal BuyingPrice { get; set; }
        public int CategoryId { get; set; }
        public int BrandId { get; set; }
        public virtual ICollection<ProductImage> Images { get; set; }
        public ICollection<ProductCategory> Categories { get; set; }
        public ICollection<ProductBrand> Brands { get; set; }
    }
}

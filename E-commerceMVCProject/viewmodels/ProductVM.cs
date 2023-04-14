using E_commerceMVCProject.Models;
using E_commerceMVCProject.Validations.ImageValidation;
using E_commerceMVCProject.Validations.ProductValidation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace E_commerceMVCProject.viewmodels
{
    public class ProductVM
    {
        public int Id { get; set; }

        [UniqueProductName]
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal StockCount { get; set; }
        public decimal SellingPrice { get; set; }
        public decimal BuyingPrice { get; set; }
        public virtual ProductCategory ProductCategory { get; set; }
        public virtual ProductBrand ProductBrand { get; set; }

        [DisplayName("Category Name")]
        public int CategoryId { get; set; }

        [DisplayName("Brand Name")]
        public int? BrandId { get; set; }

        [Required(ErrorMessage = "Please select a file.")]
        [DataType(DataType.Upload)]
        [ValidateFile]
        public IFormFileCollection ImagesFiles { get; set; }
        public virtual ICollection<ProductImage>? Images { get; set; }
        public ICollection<CategoryVM>? Categories { get; set; }
        public ICollection<BrandVM>? Brands { get; set; }
    }
}

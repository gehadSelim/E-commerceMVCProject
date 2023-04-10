using System.ComponentModel;

namespace E_commerceMVCProject.Models
{
    public class ProductBrand
    {
        public int Id { get; set; }

        [DisplayName("Product Type")]
        public string Name { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}

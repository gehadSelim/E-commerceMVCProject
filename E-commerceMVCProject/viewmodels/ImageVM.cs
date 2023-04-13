using E_commerceMVCProject.Models;

namespace E_commerceMVCProject.viewmodels
{
    public class ImageVM
    {
        public int ProductImageId { get; set; }
        public string ImageName { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}

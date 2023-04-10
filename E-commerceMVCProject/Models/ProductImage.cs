using System.ComponentModel.DataAnnotations;

namespace E_commerceMVCProject.Models
{
    public class ProductImage
    {
        public int ProductImageId { get; set; }
        public byte[] ImageData { get; set; }

        [RegularExpression(@"\w*\.(png|jpg|gif)"
                            , ErrorMessage = "Image must be with extension jpg ,gif or png")]
        public string ImageMimeType { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}

namespace E_commerceMVCProject.Models
{
    public class ProductImage
    {
        public int ProductImageId { get; set; }
        public byte[] ImageData { get; set; }
        public string ImageMimeType { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}

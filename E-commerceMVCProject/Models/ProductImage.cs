﻿using System.ComponentModel.DataAnnotations;

namespace E_commerceMVCProject.Models
{
    public class ProductImage
    {
        public int ProductImageId { get; set; }
        public string ImageName { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}

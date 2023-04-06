﻿using System.ComponentModel.DataAnnotations.Schema;

namespace E_commerceMVCProject.Models
{
    public class CartItem
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int ProductId { get; set; }        
        public virtual Product? Product { get; set; }
        public int CartId { get; set; }
        public virtual Cart? Cart { get; set; }
    }
}
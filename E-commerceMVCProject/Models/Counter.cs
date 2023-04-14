using E_commerceMVCProject.Services;
using System.Drawing.Printing;

namespace E_commerceMVCProject.Models
{
    public class Counter
    {
        private readonly IShoppingCartService _cartService;
        public Counter(IShoppingCartService cartService)
        {
            _cartService = cartService;
        }
        public static int count = 0; 
        
    }
}

using E_commerceMVCProject.Models;
using E_commerceMVCProject.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using System.Security.Claims;

namespace E_commerceMVCProject.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IShoppingCartService _cartService;
        private readonly IProductService _productService;
        public ShoppingCartController(IShoppingCartService cartService, IProductService productService)
        {
            _cartService = cartService;
            _productService = productService;
        }

        public IActionResult Index()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            List<ShoppingCart> carts = _cartService.GetCartByUserId(userId);
            return View(carts);
        }
        public IActionResult AddtoCart(int productId)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            
            ShoppingCart existedCartProduct = _cartService.GetCartByProductandUserId(productId, userId);
            if(existedCartProduct == null)
            {
                ShoppingCart cart = new ShoppingCart();
                cart.ProductId = productId;
                cart.UserId = userId;
                cart.Quantity=1;
                _cartService.AddCart(cart);
            }
            else
            {
                if(existedCartProduct.Quantity < existedCartProduct.Product.StockCount)
                {
                    existedCartProduct.Quantity += 1;
                    _cartService.UpdateCart(existedCartProduct);
                }
                else
                {
                    // out of stock
                }
            }
            return View();
        }

        public IActionResult PlusCart(int cartId)
        {
            ShoppingCart cart = _cartService.GetCartById(cartId);

            if (cart.Quantity < cart.Product.StockCount)
            {
                cart.Quantity += 1;
                _cartService.UpdateCart(cart);
            }
            else
            {
                // out of stock
            }
            return View();
        }

        public IActionResult MinusCart(int cartId)
        {
            ShoppingCart cart = _cartService.GetCartById(cartId);

            if (cart.Quantity > 1)
            {
                cart.Quantity -= 1;
                _cartService.UpdateCart(cart);
            }
            else
            {
                _cartService.DeletefromCart(cartId);
            }
            return View();
        }

        public IActionResult RemoveFromCart(int cartId)
        {           
                _cartService.DeletefromCart(cartId);
            return View();
        }
    }
}

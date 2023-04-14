using AutoMapper;
using E_commerceMVCProject.Models;
using E_commerceMVCProject.Services;
using E_commerceMVCProject.viewmodels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using System.Data;
using System.Security.Claims;

namespace E_commerceMVCProject.Controllers
{
    [Authorize(Roles = "Customer")]
    public class ShoppingCartController : Controller
    {
        private readonly IShoppingCartService _cartService;

        public ShoppingCartController(IShoppingCartService cartService)
        {
            _cartService = cartService;

        }

        public IActionResult Index()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            List<ShoppingCartVM> carts = _cartService.GetCartByUserId(userId);
            return View(carts);
        }
        public IActionResult AddtoCart(int id)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            ShoppingCartVM existedCartProduct = _cartService.GetCartByProductandUserId(id, userId);
            if (existedCartProduct == null)
            {
                ShoppingCartVM cart = new ShoppingCartVM();
                cart.ProductId = id;
                cart.UserId = userId;
                cart.Quantity = 1;
                _cartService.AddCart(cart);
                ++Counter.count;
                HttpContext.Session.SetInt32("cartCount", Counter.count);
            }
            else
            {
                if (existedCartProduct.Quantity < existedCartProduct.Product.StockCount)
                {
                    existedCartProduct.Quantity += 1;
                    _cartService.UpdateCart(existedCartProduct);
                }
                else
                {
                    // out of stock
                }
            }
            //return RedirectToAction("Index", "Home");
            return Json(Counter.count);
        }

        public IActionResult PlusCart(int id)
        {
            ShoppingCartVM cart = _cartService.GetCartById(id);

            if (cart.Quantity < cart.Product.StockCount)
            {
                cart.Quantity += 1;
                _cartService.UpdateCart(cart);
            }
            else
            {
                // out of stock
            }
            return Json(cart.Quantity);
            // return RedirectToAction("Index");
        }

        public IActionResult MinusCart(int id)
        {
            ShoppingCartVM cart = _cartService.GetCartById(id);

            if (cart.Quantity > 1)
            {
                cart.Quantity -= 1;
                _cartService.UpdateCart(cart);
            }
            else
            {
                --Counter.count;
                cart.Quantity = 0;
                //HttpContext.Session.SetInt32("cartCount", Counter.count);
                _cartService.DeletefromCart(id);
            }
            return Json(cart.Quantity);
            //return RedirectToAction("Index");
        }

        public IActionResult RemoveFromCart(int id)
        {
            --Counter.count;
            HttpContext.Session.SetInt32("cartCount", Counter.count);
            _cartService.DeletefromCart(id);
            return Json("");
            //return RedirectToAction("Index");
        }
    }
}

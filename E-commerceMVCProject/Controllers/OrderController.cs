﻿using E_commerceMVCProject.Models;
using E_commerceMVCProject.Services;
using E_commerceMVCProject.viewmodels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Security.Claims;

namespace E_commerceMVCProject.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IShoppingCartService _shoppingCartServics;
        private readonly IProductService _productService;
        public OrderController(IOrderService orderService, IShoppingCartService shoppingCartServics, IProductService productService)
        {
            _orderService = orderService;
            _shoppingCartServics = shoppingCartServics;
            _productService = productService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Customer")]
        [HttpPost]
        public IActionResult CheckOut()
        {
            String userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            List<ShoppingCartVM> shoppingCarts = _shoppingCartServics.GetCartByUserId(userId);
            Order order = new Order();
            order.UserId = userId;
            decimal TotalPrice = 0;
            order.OrderDetails = new List<OrderDetail>();
            foreach (ShoppingCartVM cart in shoppingCarts)
            {
                order.OrderDetails
                    .Add(new OrderDetail()
                    {
                        Quantity = cart.Quantity,
                        ProductId = cart.ProductId
                    ,
                        SellingPrice = cart.Product.SellingPrice,
                        BuyingPrice = cart.Product.BuyingPrice
                    });
                ProductVM product = _productService.GetProductByIDNoTracking(cart.ProductId);
                product.StockCount -= cart.Quantity;
                _productService.UpdateProduct(product);
                TotalPrice += cart.Quantity * cart.Product.SellingPrice;
                _shoppingCartServics.DeletefromCart(cart.Id);
            }
            decimal Taxes = TotalPrice * 0.15M;
            order.TaxVal = Taxes;
            order.TotalPrice = TotalPrice;
            order.TotalPriceAfterTax = Taxes + TotalPrice;
            _orderService.CreateOrder(order);
            Counter.count = 0;
            return RedirectToAction("Index", "Home");
        }
    }
}

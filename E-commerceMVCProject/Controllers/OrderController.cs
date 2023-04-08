using E_commerceMVCProject.Models;
using E_commerceMVCProject.Services;
using Microsoft.AspNetCore.Mvc;
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


        [HttpPost]

        public IActionResult CheckOut()
        {
            String userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            List<ShoppingCart> shoppingCarts = _shoppingCartServics.GetCartByUserId(userId);
            Order order = new Order();
            order.UserId = userId;
            decimal TotalPrice = 0;
            foreach (ShoppingCart cart in shoppingCarts)
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
                cart.Product.StockCount -= cart.Quantity;
                _productService.UpdateProduct(cart.Product);
                TotalPrice += cart.Quantity * cart.Product.SellingPrice;
                _shoppingCartServics.DeletefromCart(cart.Id);
            }
            decimal Taxes = TotalPrice * 0.15M;
            order.TaxVal = Taxes;
            order.TotalPrice = TotalPrice;
            order.TotalPriceAfterTax = Taxes + TotalPrice;
            _orderService.CreateOrder(order);
            return View();
        }
    }
}

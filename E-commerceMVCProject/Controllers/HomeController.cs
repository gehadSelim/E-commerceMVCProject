using E_commerceMVCProject.Models;
using E_commerceMVCProject.Services;
using E_commerceMVCProject.viewmodels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace E_commerceMVCProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService _productService;
        private readonly IProductImageService _productImageService;
        private readonly IProductCategoryService _productCategoryService;
        private readonly IProductBrandService _productBrandService;
        public HomeController(ILogger<HomeController> logger,
                              IProductService productService, 
                              IProductImageService productImageService, 
                              IProductCategoryService productCategoryService, 
                              IProductBrandService productBrandService)
        {
            _logger = logger;
             _productService = productService;
            _productImageService = productImageService;
            _productCategoryService = productCategoryService;
            _productBrandService = productBrandService;
        }
 
        public IActionResult Index()
        {
            List<ProductVM>? Products = _productService.GetAllProducts();
            List<CategoryVM> categories = _productCategoryService.GetAllCategories();
            ViewData["categoryList"] = categories;
            return View(Products);
        }
        public IActionResult Shop()
        {
            List<ProductVM>? Products = _productService.GetAllProducts();
            List<CategoryVM> categories = _productCategoryService.GetAllCategories();
            List<BrandVM> brands = _productBrandService.GetAllBrands();

            ViewData["categoryList"] = categories;
            ViewData["brandList"] = brands;

            return View(Products);
        }
        public IActionResult FilterByBrands(List<int> brandsIds)
        {
            var filteredProducts = _productService.FilterbyBrands(brandsIds);
            List<ProductVM> flattenedList = filteredProducts.SelectMany(d => d).ToList();
            return View("index", flattenedList);
        }

        public IActionResult FilterByPrice(int minPrice, int maxPrice)
        {
            var filteredProducts = _productService.FilterByPrice(minPrice, maxPrice);
            return View("index", filteredProducts);
        }
        public IActionResult FilterByCategory(int id)
        {
            var filteredProducts = _productService.GetByCategoryId(id);
            return View("index", filteredProducts);
        }

        public IActionResult FilterByName(string searchName)
        {
            var filteredProducts = _productService.FilterByName(searchName);
            return View("index", filteredProducts);
        }
        public IActionResult Details(int id)
        {
            ProductVM? product = _productService.GetProductById(id);
            return View(product);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
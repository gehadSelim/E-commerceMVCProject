using E_commerceMVCProject.Models;
using E_commerceMVCProject.Services;
using E_commerceMVCProject.viewmodels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NuGet.Protocol.Core.Types;

namespace E_commerceMVCProject.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IProductCategoryService _productCategoryService;
        private readonly IProductBrandService _productBrandService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductController(IProductService productService, IProductCategoryService productCategoryService, IProductBrandService productBrandService, IWebHostEnvironment webHostEnvironment)
        {
            _productService = productService;
            _productCategoryService = productCategoryService;
            _productBrandService = productBrandService;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            List<Product>? Products = _productService.GetAllProducts();
            return View(Products);

        }
        public IActionResult Details(int id)
        {
            Product? product = _productService.GetProductById(id);
            return View(product);
        }
        public IActionResult New()
        {
            NewProductVM ProductFormModel = new()
            {
                Categories = _productCategoryService.GetAllCategories(),
                Brands = _productBrandService.GetAllBrands(),
            };
            return View(ProductFormModel);
        }
        [HttpPost]
        public IActionResult Save(NewProductVM newProduct, IFormFile Image)
        {
            if (ModelState.IsValid)
            {
                UploadImage(Image);
                _productService.AddProduct(new Product()
                {
                    Id = newProduct.Id,
                    Name = newProduct.Name,
                    Description = newProduct.Description,
                    StockCount = newProduct.StockCount,
                    SellingPrice = newProduct.SellingPrice,
                    BuyingPrice = newProduct.BuyingPrice,
                    CategoryId = newProduct.CategoryId,
                    BrandId = newProduct.BrandId,
                    Images = newProduct.Images,
                });
                return RedirectToAction("Index");
            }
            return View(newProduct);
        }
        public IActionResult Edit(int id)
        {
            Product? oldProduct = _productService.GetProductById(id);
            if (oldProduct == null)
            {
                return NotFound();
            }
            NewProductVM ProductFormModel = new()
            {
                Id = oldProduct.Id,
                Name = oldProduct.Name,
                Description = oldProduct.Description,
                StockCount = oldProduct.StockCount,
                SellingPrice = oldProduct.SellingPrice,
                BuyingPrice = oldProduct.BuyingPrice,
                CategoryId = oldProduct.CategoryId,
                BrandId = oldProduct.BrandId,
                Images = oldProduct.Images,
                Categories = _productCategoryService.GetAllCategories(),
                Brands = _productBrandService.GetAllBrands(),
            };
            return View("New", ProductFormModel);
        }
        [HttpPost]
        public IActionResult Edit(NewProductVM Edited)
        {
            Product? oldProduct = _productService.GetProductById(Edited.Id);
            if (oldProduct == null)
            {
                return NotFound();
            }
            else if (ModelState.IsValid)
            {
                oldProduct.Id = Edited.Id;
                oldProduct.Name = Edited.Name;
                oldProduct.Description = Edited.Description;
                oldProduct.StockCount = Edited.StockCount;
                oldProduct.SellingPrice = Edited.SellingPrice;
                oldProduct.BuyingPrice = Edited.BuyingPrice;
                oldProduct.Images = Edited.Images ?? oldProduct.Images;
                oldProduct.CategoryId = Edited.CategoryId;
                oldProduct.BrandId = Edited.BrandId;

                _productService.UpdateProduct(oldProduct);
                return RedirectToAction("Index");
            }
            return View("New", Edited);
        }
        public IActionResult Delete(int id)
        {
            Product? deletedProduct = _productService.GetProductById(id);
            if (deletedProduct == null)
                return NotFound();

            _productService.DeleteProduct(deletedProduct.Id);
            return RedirectToAction("Index");
        }
        private void UploadImage(IFormFile Image)
        {
            if(Image != null)
            {
                string rootPath = Path.Combine(_webHostEnvironment.WebRootPath + "Images");
                string imageName = Guid.NewGuid().ToString() + "_" + Image.FileName;
                string filePath = Path.Combine(rootPath, imageName);
                using (FileStream fileStream = new(filePath, FileMode.Create))
                {
                    Image.CopyTo(fileStream);
                }
            }

        }
    }
}

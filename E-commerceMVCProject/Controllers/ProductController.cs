using E_commerceMVCProject.Models;
using E_commerceMVCProject.Services;
using E_commerceMVCProject.viewmodels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NuGet.Protocol.Core.Types;
using System.Drawing.Imaging;

namespace E_commerceMVCProject.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IProductImageService _productImageService;
        private readonly IProductCategoryService _productCategoryService;
        private readonly IProductBrandService _productBrandService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ProductController(IProductService productService, IProductImageService productImageService, IProductCategoryService productCategoryService, IProductBrandService productBrandService, IWebHostEnvironment webHostEnvironment)
        {
            _productService = productService;
            _productImageService = productImageService;
            _productCategoryService = productCategoryService;
            _productBrandService = productBrandService;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index(List<ProductVM>? filteredProducts)
        {
            if (filteredProducts?.Count != 0)
            {
                return View(filteredProducts);
            }
            List<ProductVM>? Products = _productService.GetAllProducts();
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
        public IActionResult FilterByCategory(int categoryId)
        {
            var filteredProducts = _productService.GetByCategoryId(categoryId);
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
        public IActionResult New()
        {
            ProductVM ProductFormModel = new()
            {
                Categories = _productCategoryService.GetAllCategories(),
                Brands = _productBrandService.GetAllBrands(),
            };
            return View(ProductFormModel);
        }
        [HttpPost]
        public IActionResult New(ProductVM newProduct)
        {
            if (ModelState.IsValid)
            {
                if (newProduct.ImagesFiles != null)
                {
                    ProductVM recentlyAddedProduct = _productService.AddProduct(newProduct);
                    int productId = recentlyAddedProduct.Id;
                    //int productId = (int)_productService.GetLastId();
                    foreach (IFormFile file in newProduct.ImagesFiles)
                    {
                        if (file != null)
                        {
                            string imageName = UploadImage(file, newProduct.Name);
                            //store image name in database
                            StoreImage(productId, imageName);
                        }
                    }
                }
                return RedirectToAction("Index");
            }
            newProduct = new ProductVM()
            {
                Categories = _productCategoryService.GetAllCategories(),
                Brands = _productBrandService.GetAllBrands(),
            };
            return View(newProduct);
        }
        public IActionResult Edit(int id)
        {
            ProductVM? oldProduct = _productService.GetProductById(id);
            if (oldProduct == null)
            {
                return NotFound();
            }
            oldProduct.Categories = _productCategoryService.GetAllCategories();
            oldProduct.Brands = _productBrandService.GetAllBrands();
            return View("New", oldProduct);
        }
        [HttpPost]
        public IActionResult Edit(ProductVM edited)
        {
            ProductVM? oldProduct = _productService.GetProductByIDNoTracking(edited.Id);
            if (oldProduct == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                if (edited.ImagesFiles != null)
                {
                    foreach (IFormFile file in edited.ImagesFiles)
                    {
                        if (file != null)
                        {
                            string imageName = UploadImage(file, edited.Name);
                            //store image name in database
                            StoreImage(edited.Id, imageName);
                        }
                    }
                }
                _productService.UpdateProduct(edited);
                return RedirectToAction("Index");
            }
            edited.Categories = _productCategoryService.GetAllCategories();
            edited.Brands = _productBrandService.GetAllBrands();
            return View("New", edited);
        }
        public IActionResult Delete(int id)
        {
            ProductVM? deletedProduct = _productService.GetProductById(id);
            if (deletedProduct == null)
                return NotFound();

            _productService.DeleteProduct(deletedProduct.Id);
            return RedirectToAction("Index");
        }

        private string UploadImage(IFormFile image, string productName)
        {
            string uploads = Path.Combine(_webHostEnvironment.WebRootPath, "images", productName);
            Directory.CreateDirectory(uploads);
            string filename = Guid.NewGuid().ToString() + "_" + image.FileName;
            string fullpath = Path.Combine(uploads, filename);
            image.CopyTo(new FileStream(fullpath, FileMode.Create));
            return filename;
        }
        private void StoreImage(int productId, string imageName)
        {
            ImageVM productImage = new()
            {
                ProductId = productId,
                ImageName = imageName
            };
            _productImageService.AddImage(productImage);
        }
    }
}

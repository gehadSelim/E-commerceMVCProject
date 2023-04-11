using AutoMapper;
using E_commerceMVCProject.Models;
using E_commerceMVCProject.Services;
using E_commerceMVCProject.viewmodels;
using Microsoft.AspNetCore.Mvc;

namespace E_commerceMVCProject.Controllers
{
    public class BrandController : Controller
    {
        private readonly IProductBrandService _productBrandService;
        public BrandController(IProductBrandService productBrandService)
        {
            _productBrandService = productBrandService;
        }
        public IActionResult Index()
        {
            List<BrandVM>? brands = _productBrandService.GetAllBrands();
            return View(brands);
        }
        [HttpGet]
        public IActionResult Create()
        {
            BrandVM model = new BrandVM();
            return View(model);
        }
        [HttpPost]
        public IActionResult Create(BrandVM model)
        {
            if (ModelState.IsValid)
            {
                _productBrandService.AddBrand(model);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
        public IActionResult Edit(int id)
        {
            BrandVM? oldBrand = _productBrandService.GetBrandByID(id);
            if (oldBrand == null)
                return NotFound();

            BrandVM BrandFormModel = new()
            {
                Name = oldBrand.Name,
            };
            return View("New", BrandFormModel);
        }
        [HttpPost]
        public IActionResult Edit(BrandVM Edited)
        {
            var oldBrand = _productBrandService.GetBrandByIDNoTracking(Edited.Id);

            if (oldBrand == null)
                return NotFound();

            if (ModelState.IsValid)
            {
                Edited.Name = Edited.Name;
                return RedirectToAction("Index");
            }
            return View("New", Edited);
        }

        public IActionResult Delete(int id)
        {
            BrandVM? deletedBrand = _productBrandService.GetBrandByID(id);
            if (deletedBrand == null)
                return NotFound();

            _productBrandService.DeleteBrand(deletedBrand.Id);
            return RedirectToAction("Index");
        }
    }
}

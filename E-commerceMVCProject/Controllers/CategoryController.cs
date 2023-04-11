using E_commerceMVCProject.Models;
using E_commerceMVCProject.Services;
using E_commerceMVCProject.viewmodels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Differencing;
using Microsoft.Extensions.Hosting.Internal;

namespace E_commerceMVCProject.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IProductCategoryService _productCategoryService;
        public CategoryController(IProductCategoryService productCategoryService)
        {
            _productCategoryService = productCategoryService;
        }
        public IActionResult Index()
        {
            List <CategoryVM>? Categories = _productCategoryService.GetAllCategories();
            return View(Categories);
        }
        [HttpGet]
        public IActionResult Create()
        {
            CategoryVM model = new CategoryVM();
            return View(model);
        }
        [HttpPost]
        public IActionResult Create(CategoryVM model)
        {
            if (ModelState.IsValid)
            {
                _productCategoryService.AddCategory(model);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
        public IActionResult Edit(int id)
        {
            CategoryVM? oldCategory = _productCategoryService.GetCategoryByID(id);
            if (oldCategory == null)
                return NotFound();

            CategoryVM CategoryFormModel  = new()
            {
                Name = oldCategory.Name,
            };
            return View("New", CategoryFormModel);
        }
        [HttpPost]
        public IActionResult Edit(CategoryVM Edited)
        {
            CategoryVM oldCategory = _productCategoryService.GetCategoryByIDNoTracking(Edited.Id);

            if (oldCategory == null)
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
            CategoryVM? deletedCategory = _productCategoryService.GetCategoryByID(id);
            if (deletedCategory == null)
                return NotFound();

            _productCategoryService.DeleteCategory(deletedCategory.Id);
            return RedirectToAction("Index");
        }
    }
}

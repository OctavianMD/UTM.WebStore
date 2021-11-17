using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using CommonLayer.ViewModels;
using ServiceLayer.Interfaces;

namespace FrontOffice.MVC.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _categoryService.GetAllCategories());
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(CategoryViewModel model)
        {
            await _categoryService.AddCategory(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            return View(await _categoryService.GetCategory(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CategoryViewModel model)
        {
            await _categoryService.EditCategory(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await _categoryService.DeleteCategory(id);
            return RedirectToAction("Index");
        }
    }
}

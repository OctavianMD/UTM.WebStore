using System.Threading.Tasks;
using BusinessLayer.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace FrontOffice.MVC.Controllers
{
    public class BaseCategoryController : Controller
    {
        private readonly BaseCategoryHelper _baseCategoryHelper;

        public BaseCategoryController(BaseCategoryHelper baseCategoryHelper)
        {
            _baseCategoryHelper = baseCategoryHelper;
        }

        public async Task<IActionResult> Index()
        {
            return View(await  _baseCategoryHelper.GetAll());
        }
    }
}

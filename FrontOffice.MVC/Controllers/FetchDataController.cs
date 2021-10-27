using System.Threading.Tasks;
using FrontOffice.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Interfaces;

namespace FrontOffice.MVC.Controllers
{
    public class FetchDataController : Controller
    {
        private readonly IFetchDataService _fetchDataService;

        public FetchDataController(IFetchDataService fetchDataService)
        {
            _fetchDataService = fetchDataService;
        }

        public IActionResult Index()
        {
            return View(new FetchDataModel());
        }
        
        [HttpPost]
        public async Task<IActionResult> FetchBaseCategories()
        {
            var result = await _fetchDataService.FetchBaseCategories();
            return View("Index", new FetchDataModel
            {
                IsFetched = true,
                Message = $"Successfully fetched {result} base categories"
            });
        }

        [HttpPost]
        public async Task<IActionResult> FetchCategories()
        {
            var result = await _fetchDataService.FetchBaseCategories();
            return View("Index", new FetchDataModel
            {
                IsFetched = true,
                Message = $"Successfully fetched {result} base categories"
            });
        }

        [HttpPost]
        public async Task<IActionResult> FetchProducts()
        {
            var result = await _fetchDataService.FetchBaseCategories();
            return View("Index", new FetchDataModel
            {
                IsFetched = true,
                Message = $"Successfully fetched {result} base categories"
            });
        }
    }
}

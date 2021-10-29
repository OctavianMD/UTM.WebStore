using System.Threading.Tasks;
using BusinessLayer.Helpers;
using ServiceLayer.Interfaces;

namespace ServiceLayer.Services
{
    public class FetchDataService: IFetchDataService
    {
        private readonly IFetchDataHttpClient _fetchDataClient;
        private readonly BaseCategoryHelper _baseCategoryHelper;
        private readonly CategoryHelper _categoryHelper;
        private readonly ProductHelper _productHelper;

        public FetchDataService(IFetchDataHttpClient fetchDataClient, BaseCategoryHelper baseCategoryHelper, CategoryHelper categoryHelper, ProductHelper productHelper)
        {
            _fetchDataClient = fetchDataClient;
            _baseCategoryHelper = baseCategoryHelper;
            _categoryHelper = categoryHelper;
            _productHelper = productHelper;
        }

        public async Task<int> FetchBaseCategories()
        {
            var results = await _fetchDataClient.FetchBaseCategories();
            return await _baseCategoryHelper.ProcessFetchedData(results);
        }

        public async Task<int> FetchCategories()
        {
            var results = await _fetchDataClient.FetchCategories();
            return await _categoryHelper.ProcessFetchedData(results);
        }

        public async Task<int> FetchProducts()
        {
            var results = await _fetchDataClient.FetchProducts();
            return await _productHelper.ProcessFetchedData(results);
        }
    }
}

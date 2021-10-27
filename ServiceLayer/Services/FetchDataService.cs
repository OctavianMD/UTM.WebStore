using System.Threading.Tasks;
using ServiceLayer.Interfaces;

namespace ServiceLayer.Services
{
    public class FetchDataService: IFetchDataService
    {
        private readonly IFetchDataHttpClient _fetchDataClient;

        public FetchDataService(IFetchDataHttpClient fetchDataClient)
        {
            _fetchDataClient = fetchDataClient;
        }

        public async Task<int> FetchBaseCategories()
        {
            var results = await _fetchDataClient.FetchBaseCategories();
            return 1;
        }

        public async Task<int> FetchCategories()
        {
            var results = await _fetchDataClient.FetchCategories();
            return 1;
        }

        public async Task<int> FetchProducts()
        {
            var results = await _fetchDataClient.FetchProducts();
            return 1;
        }
    }
}

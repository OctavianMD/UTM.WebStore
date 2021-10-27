using System;
using System.Net.Http;
using System.Threading.Tasks;
using CommonLayer;
using ServiceLayer.Interfaces;

namespace ServiceLayer.Services
{
    public class FetchDataHttpClient: IFetchDataHttpClient
    {
        private readonly HttpClient _httpClient;

        private static readonly string BaseCategoryEndpoint = "https://localhost:44354/api/seed/basecategories";
        private static readonly string CategoryEndpoint = "https://localhost:44354/api/seed/categories";
        private static readonly string ProductsEndpoint = "https://localhost:44354/api/seed/products";


        public FetchDataHttpClient(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient(Constants.FetchDataHttpClientName);
        }

        public async Task<string> FetchBaseCategories()
        {
            var response = await _httpClient.SendAsync(new HttpRequestMessage(HttpMethod.Get, BaseCategoryEndpoint));
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> FetchCategories()
        {
            var response = await _httpClient.SendAsync(new HttpRequestMessage(HttpMethod.Get, CategoryEndpoint));
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> FetchProducts()
        {
            var response = await _httpClient.SendAsync(new HttpRequestMessage(HttpMethod.Get, ProductsEndpoint));
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }
}
